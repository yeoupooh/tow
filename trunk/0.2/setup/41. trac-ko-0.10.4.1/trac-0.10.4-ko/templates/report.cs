<?cs include "header.cs" ?>
<?cs include "macros.cs" ?>

<div id="ctxtnav" class="nav">
 <h2>Report Navigation</h2>
 <ul><li class="first"><?cs
   if:chrome.links.up.0.href ?><a href="<?cs
    var:chrome.links.up.0.href ?>">이용 가능한 리포트들</a><?cs
   else ?>이용 가능한 리포트들<?cs
  /if ?></li><?cs
  if:report.query_href ?><li class="last"><a href="<?cs
   var:report.query_href ?>">맞춤형 쿼리</a></li><?cs
  /if ?></ul>
</div>

<div id="content" class="report">

 <?cs def:report_hdr(header) ?>
   <?cs if $header ?>
     <?cs if idx > 0 ?>
       </table>
     <?cs /if ?>
   <?cs /if ?>
   <?cs if:header ?><h2><?cs var:header ?></h2><?cs /if ?>
   <?cs if $report.id == -1 ?>
     <table class="listing reports">
   <?cs else ?>
     <table class="listing tickets">
   <?cs /if ?>
    <thead>
     <tr>
       <?cs set numcols = #0 ?>
       <?cs each header = report.headers ?>
         <?cs if $header.fullrow ?>
           </tr><tr><th colspan="100"><?cs var:header ?></th>
         <?cs else ?>
           <?cs if $report.sorting.enabled ?>
             <?cs set vars='' ?>
             <?cs each arg = report.var ?>
               <?cs set vars = vars + '&amp;' + name(arg) + '=' + arg ?>
             <?cs /each ?>
             <?cs set sortValue = '' ?>
             <?cs if $header.asc == '1' ?>
               <?cs set sortValue = '?sort='+$header.real+'&amp;asc=0' ?>
             <?cs else ?>
               <?cs set sortValue = '?sort='+$header.real+'&amp;asc=1' ?>
             <?cs /if ?>
             <?cs if $header ?>
             <th><a href="<?cs var:sortValue ?><?cs var:vars ?>"><?cs var:header ?></a></th>
             <?cs /if ?>
           <?cs elif $header ?>
             <th><?cs var:header ?></th>
           <?cs /if ?>
           <?cs if $header.breakrow ?>
              </tr><tr>
           <?cs /if ?>
         <?cs /if ?>
         <?cs set numcols = numcols + #1 ?>
       <?cs /each ?>
     </tr>
    </thead>
 <?cs /def ?>
 
 <?cs def:report_cell(class,contents) ?>
   <?cs if $cell.fullrow ?>
     </tr><tr class="<?cs var:row_class ?>" style="<?cs var: row_style ?>;border: none; padding: 0;">
      <td class="fullrow" colspan="100">
       <?cs var:$contents ?><hr />
      </td>
   <?cs else ?>
   <td <?cs if $cell.breakrow || $col == $numcols ?>colspan="100" <?cs /if
 ?>class="<?cs var:$class ?>"><?cs if $contents ?><?cs var:$contents ?><?cs /if ?></td>
 
 <?cs if $cell.breakafter ?>
     </tr><tr class="<?cs var: row_class ?>" style="<?cs var: row_style ?>;border: none; padding: 0">
 <?cs /if ?>
   <?cs /if ?>
   <?cs set col = $col + #1 ?>
 <?cs /def ?>
 
 <?cs set idx = #0 ?>
 <?cs set group = '' ?>
 
 <?cs if:report.mode == "list" ?>
  <h1><?cs var:title ?><?cs
   if:report.numrows && report.id != -1 ?><span class="numrows"> (<?cs
    var:report.numrows ?>개의 항목이 일치합니다)</span><?cs
   /if ?></h1><?cs
   if:report.description ?><div id="description"><?cs
    var:report.description ?></div><?cs
   /if ?><?cs
   if:report.id != -1 ?><?cs
    if:report.can_create || report.can_modify || report.can_delete ?>
     <div class="buttons"><?cs
      if:report.can_modify ?><form action="" method="get"><div>
       <input type="hidden" name="action" value="edit" />
       <input type="submit" value="리포트 편집하기" accesskey="e" />
      </div></form><?cs /if ?><?cs
      if:report.can_create ?><form action="" method="get"><div>
       <input type="hidden" name="action" value="copy" />
       <input type="submit" value="리포트 복사하기" />
      </div></form><?cs /if ?><?cs
      if:report.can_delete ?><form action="" method="get"><div>
       <input type="hidden" name="action" value="delete" />
       <input type="submit" value="리포트 삭제하기" />
      </div></form><?cs /if ?>
     </div><?cs
    /if ?><?cs
   /if ?>

     <?cs each row = report.items ?>
       <?cs if group != row.__group__ || idx == #0 ?>
         <?cs if:idx != #0 ?></tbody><?cs /if ?>
         <?cs set group = row.__group__ ?>
         <?cs call:report_hdr(group) ?>
         <tbody>
       <?cs /if ?>

       <?cs if row.__color__ ?>
         <?cs set rstem='color'+$row.__color__ +'-' ?>
       <?cs else ?>
        <?cs set rstem='' ?>
       <?cs /if ?>
       <?cs if idx % #2 ?>
         <?cs set row_class=$rstem+'even' ?>
       <?cs else ?>
         <?cs set row_class=$rstem+'odd' ?>
       <?cs /if ?>

       <?cs set row_style='' ?>
       <?cs if row.__bgcolor__ ?>
         <?cs set row_style='background: ' + row.__bgcolor__ + ';' ?>
       <?cs /if ?>
       <?cs if row.__fgcolor__ ?>
         <?cs set row_style=$row_style + 'color: ' + row.__fgcolor__ + ';' ?>
       <?cs /if ?>
       <?cs if row.__style__ ?>
         <?cs set row_style=$row_style + row.__style__ + ';' ?>
       <?cs /if ?>

       <tr class="<?cs var: row_class ?>" style="<?cs var: row_style ?>">
       <?cs set idx = idx + #1 ?>
       <?cs set col = #0 ?>
       <?cs each cell = row ?>
         <?cs if cell.hidden || cell.hidehtml ?>
         <?cs elif name(cell) == "ticket" || name(cell) == "id" ?>
           <?cs call:report_cell('ticket',
                                 '<a title="티켓 보기" href="'+
                                 $cell.ticket_href+'">#'+$cell+'</a>') ?>
         <?cs elif name(cell) == "summary" && cell.ticket_href ?>
           <?cs call:report_cell('summary', '<a title="티켓 보기" href="'+
                                 $cell.ticket_href+'">'+$cell+'</a>') ?>
         <?cs elif name(cell) == "report" ?>
           <?cs call:report_cell('report',
                '<a title="리포트 보기" href="'+$cell.report_href+'">{'+$cell+'}</a>') ?>
           <?cs set:report_href=$cell.report_href ?>
         <?cs elif name(cell) == "time" ?>
           <?cs call:report_cell('date', $cell.date) ?>
         <?cs elif name(cell) == "date" || name(cell) == "created" || name(cell) == "modified" ?>
           <?cs call:report_cell('date', $cell.date) ?>
         <?cs elif name(cell) == "datetime"  ?>
           <?cs call:report_cell('date', $cell.datetime) ?>
         <?cs elif name(cell) == "description" ?>
           <?cs call:report_cell('', $cell.parsed) ?>
         <?cs elif name(cell) == "title" && $report.id == -1 ?>
           <?cs call:report_cell('title',
                                 '<a  title="리포트 보기" href="'+
                                 $report_href+'">'+$cell+'</a>') ?>
         <?cs else ?>
           <?cs call:report_cell(name(cell), $cell) ?>
         <?cs /if ?>
       <?cs /each ?>
       </tr>
     <?cs /each ?>
    </tbody>
   </table><?cs
   if:report.id == -1 && report.can_create?><div class="buttons">
    <form action="" method="get"><div>
     <input type="hidden" name="action" value="new" />
     <input type="submit" value="새로운 리포트 만들기" />
    </div></form></div><?cs
   /if ?><?cs
   if report.message ?>
    <div class="system-message"><?cs var report.message ?></div><?cs
   elif:idx == #0 ?>
    <div id="report-notfound">일치하는 항목이 없습니다.</div><?cs
   /if ?>

 <?cs elif:report.mode == "delete" ?>

  <h1><?cs var:title ?></h1>
  <form action="<?cs var:report.href ?>" method="post">
   <input type="hidden" name="id" value="<?cs var:report.id ?>" />
   <input type="hidden" name="action" value="delete" />
   <p><strong>이 리포트를 정말로 삭제하시겠습니까?</strong></p>
   <div class="buttons">
    <input type="submit" name="cancel" value="취소" />
    <input type="submit" value="리포트 삭제하기" />
   </div>
  </form>
 
 <?cs elif:report.mode == "edit" ?>
 
   <h1><?cs var:title ?></h1>
   <form action="<?cs var:report.href ?>" method="post">
    <div>
     <input type="hidden" name="action" value="<?cs var:report.action ?>" />
     <div class="field">
      <label for="title">리포트 이름:</label><br />
      <input type="text" id="title" name="title"
             value="<?cs var:report.title ?>" size="50" /><br />
     </div>
     <div class="field">
      <label for="description">
       이 리포트에 대한 상세한 설명:</label> (여기에서 <a tabindex="42" href="<?cs
         var:$trac.href.wiki ?>/WikiFormatting">WikiFormatting</a>을 사용할 수 있습니다)
      </label><br />
      <textarea id="description" name="description" class="wikitext" rows="10" cols="78">
<?cs var:report.description ?></textarea>
     </div>
     <div class="field">
      <label for="query">
       이 리포트에 대한 SQL 쿼리:</label><br />
      <textarea id="query" name="query" cols="85" rows="20"><?cs
        var:report.sql ?></textarea>
     </div>
     <div class="buttons">
      <input type="submit" value="리포트 저장하기" />
      <input type="submit" name="cancel" value="취소" />
     </div>
    </div>
    <script type="text/javascript" src="<?cs
      var:htdocs_location ?>js/wikitoolbar.js"></script>
   </form>
 <?cs /if?>
 
 <div id="help">
  <strong>참고:</strong> 리포트를 만들고 사용하면서 도움이 필요하다면, <a href="<?cs
    var:trac.href.wiki ?>/TracReports">TracReports</a> 페이지를 참고하십시오.
 </div>
 
</div>
<?cs include "footer.cs" ?>
