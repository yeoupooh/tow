<?cs include "header.cs"?>
<?cs include "macros.cs"?>

<div id="ctxtnav" class="nav">
 <ul>
  <li class="first"><a href="<?cs var:browser.restr_changeset_href ?>">
   마지막 변경</a></li>
  <li class="last"><a href="<?cs var:browser.log_href ?>">
   리비전 로그</a></li>
 </ul>
</div>


<div id="searchable">
<div id="content" class="browser">
 <h1><?cs call:browser_path_links(browser.path, browser) ?></h1>

 <div id="jumprev">
  <form action="" method="get">
   <div>
    <label for="rev">다음 리비전 보기:</label>
    <input type="text" id="rev" name="rev" value="<?cs
       var:browser.revision ?>" size="4" />
   </div>
  </form>
 </div>

 <?cs def:sortable_th(order, desc, class, title, href) ?>
 <th class="<?cs var:class ?><?cs if:order == class ?> <?cs
   if:desc ?>desc<?cs else ?>asc<?cs /if ?><?cs /if ?>">
  <a title="<?cs var:class ?> 순으로 정렬<?cs
    if:order == class && !desc ?> (내림차순으로)<?cs /if ?>" 
     href="<?cs var:href[class] ?>"><?cs var:title ?></a>
 </th>
 <?cs /def ?>

 <?cs if:browser.is_dir ?>
  <table class="listing" id="dirlist">
   <thead>
    <tr><?cs 
     call:sortable_th(browser.order, browser.desc, 'name', '이름', browser.order_href) ?><?cs 
     call:sortable_th(browser.order, browser.desc, 'size', '크기', browser.order_href) ?>
     <th class="rev">리비전</th><?cs 
     call:sortable_th(browser.order, browser.desc, 'date', '기간', browser.order_href) ?>
     <th class="change">마지막 변경사항</th>
    </tr>
   </thead>
   <tbody>
    <?cs if:len(chrome.links.up) ?>
     <tr class="even">
      <td class="name" colspan="5">
       <a class="parent" title="Parent Directory" href="<?cs
         var:chrome.links.up.0.href ?>">../</a>
      </td>
     </tr>
    <?cs /if ?>
    <?cs each:item = browser.items ?>
     <?cs set:change = browser.changes[item.rev] ?>
     <tr class="<?cs if:name(item) % #2 ?>even<?cs else ?>odd<?cs /if ?>">
      <td class="name"><?cs
       if:item.is_dir ?>
        <a class="dir" title="디렉토리 보기" href="<?cs
          var:item.browser_href ?>"><?cs var:item.name ?></a><?cs
       else ?>
        <a class="file" title="파일 보기" href="<?cs
          var:item.browser_href ?>"><?cs var:item.name ?></a><?cs
       /if ?>
      </td>
      <td class="size"><?cs var:item.size ?></td>
      <td class="rev"><?cs if:item.permission != '' ?><a title="리비전 로그 보기" href="<?cs
        var:item.log_href ?>"><?cs var:item.rev ?></a><?cs else ?><?cs var:item.rev ?><?cs /if ?></td>
      <td class="age"><span title="<?cs var:browser.changes[item.rev].date ?>"><?cs
        var:browser.changes[item.rev].age ?></span></td>
      <td class="change">
       <span class="author"><?cs var:browser.changes[item.rev].author ?>:</span>
       <span class="change"><?cs var:browser.changes[item.rev].message ?></span>
      </td>
     </tr>
    <?cs /each ?>
   </tbody>
  </table><?cs
 /if ?><?cs

 if:len(browser.props) || !browser.is_dir ?>
  <table id="info" summary="Revision info"><?cs
   if:!browser.is_dir ?><tr>
    <th scope="col">
     리비전 <a href="<?cs var:file.changeset_href ?>"><?cs var:file.rev ?></a>, <?cs var:file.size ?>
     (<?cs var:file.author ?>에 의해 체크인됨, <?cs var:file.age ?> 전)
    </th></tr><tr>
    <td class="message"><?cs var:file.message ?></td>
   </tr><?cs /if ?><?cs
   if:len(browser.props) ?><tr>
    <td colspan="2"><ul class="props"><?cs
     each:prop = browser.props ?>
      <li><strong><?cs var:prop.name ?></strong> 속성이 <em><code><?cs
      var:prop.value ?></code></em> (으)로 설정되어있습니다.</li><?cs
     /each ?>
    </ul></td></tr><?cs
   /if ?>
  </table><?cs
 /if ?><?cs
 
 if:!browser.is_dir ?>
  <div id="preview"><?cs
   if:file.preview ?><?cs
    var:file.preview ?><?cs
   elif:file.max_file_size_reached ?>
    <strong>HTML 미리보기가 지원되지 않습니다.</strong> 파일 사이즈가 
    <?cs var:file.max_file_size ?> 바이트를 넘습니다. 대신에 파일을 <a href="<?cs
    var:file.raw_href ?>">다운로드</a>하십시오.<?cs
   else ?><strong>HTML 미리보기가 지원되지 않습니다.</strong> 파일을 보기 위해서는, 파일을 <a href="<?cs
    var:file.raw_href ?>">다운로드</a>하십시오.<?cs
   /if ?>
  </div><?cs
 /if ?>

 <div id="help">
  <strong>참고:</strong> 소스 브라우저를 사용하면서 도움이 필요하다면, <a href="<?cs var:trac.href.wiki
  ?>/TracBrowser">TracBrowser</a>를 참고하십시오.
 </div>

  <div id="anydiff">
   <form action="<?cs var:browser.anydiff_href ?>" method="get">
    <div class="buttons">
     <input type="hidden" name="new_path" value="<?cs var:browser.path ?>" />
     <input type="hidden" name="old_path" value="<?cs var:browser.path ?>" />
     <input type="hidden" name="new_rev" value="<?cs var:browser.revision ?>" />
     <input type="hidden" name="old_rev" value="<?cs var:browser.revision ?>" />
     <input type="submit" value="차이점들 보기..." title="Prepare an Arbitrary Diff" />
    </div>
   </form>
  </div>

</div>
</div>
<?cs include:"footer.cs"?>
