<?cs include:"header.cs"?>
<?cs include:"macros.cs"?>

<div id="ctxtnav" class="nav"></div>

<div id="content" class="milestone">
 <?cs if:milestone.mode == "new" ?>
 <h1>새로운 마일스톤 추가하기</h1>
 <?cs elif:milestone.mode == "edit" ?>
 <h1>"<?cs var:milestone.name ?>" 마일스톤 수정하기</h1>
 <?cs elif:milestone.mode == "delete" ?>
 <h1>"<?cs var:milestone.name ?>" 마일스톤 삭제하기</h1>
 <?cs else ?>
 <h1>"<?cs var:milestone.name ?>" 마일스톤</h1>
 <?cs /if ?>

 <?cs if:milestone.mode == "edit" || milestone.mode == "new" ?>
  <script type="text/javascript">
    addEvent(window, 'load', function() {
      document.getElementById('name').focus();
    });
  </script>
  <form id="edit" action="<?cs var:milestone.href ?>" method="post">
   <input type="hidden" name="id" value="<?cs var:milestone.name ?>" />
   <input type="hidden" name="action" value="edit" />
   <div class="field">
    <label>마일스톤 이름:<br />
    <input type="text" id="name" name="name" size="32" value="<?cs
      var:milestone.name ?>" /></label>
   </div>
   <fieldset>
    <legend>스케줄</legend>
    <label>완료할 날짜:<br />
     <input type="text" id="duedate" name="duedate" size="<?cs
       var:len(milestone.date_hint) ?>" value="<?cs
       var:milestone.due_date ?>" title="형식: <?cs var:milestone.date_hint ?>" />
     <em>형식: <?cs var:milestone.date_hint ?></em>
    </label>
    <div class="field">
     <label>
      <input type="checkbox" id="completed" name="completed"<?cs
        if:milestone.completed ?> checked="checked"<?cs /if ?> />
      완료된 날짜:<br />
     </label>
     <label>
      <input type="text" id="completeddate" name="completeddate" size="<?cs
        var:len(milestone.date_hint) ?>" value="<?cs
        alt:milestone.completed_date ?><?cs
         var:milestone.datetime_now ?><?cs
        /alt ?>" title="형식: <?cs
        var:milestone.datetime_hint ?>" />
      <em>형식: <?cs var:milestone.datetime_hint ?></em>
     </label><?cs
     if:len(milestones) ?>
     <br/>
     <input type="checkbox" id="retarget" name="retarget" checked="checked"
            onclick="enableControl('target', this.checked)"/>
     <label>
      닫혀지지 않은 티켓들을 마일스톤
      <select id="target" name="target">
       <option value="">None</option><?cs
       each:name = milestones ?>
       <option><?cs var:name ?></option><?cs
       /each ?>
      </select>
      (으)로 이동시킵니다.
     </label><?cs
     /if ?>
     <script type="text/javascript">
       var completed = document.getElementById("completed");
       var retarget = document.getElementById("retarget");
       var enableCompletedDate = function() {
         enableControl("completeddate", completed.checked);
         enableControl("retarget", completed.checked);
         enableControl("target", completed.checked && retarget.checked);
       };
       addEvent(window, "load", enableCompletedDate);
       addEvent(completed, "click", enableCompletedDate);
     </script>
    </div>
   </fieldset>
   <div class="field">
    <fieldset class="iefix">
     <label for="description">상세한 설명 (여기에서 <a tabindex="42" href="<?cs
       var:trac.href.wiki ?>/WikiFormatting">WikiFormatting</a>을 사용할 수 있습니다.):</label>
     <p><textarea id="description" name="description" class="wikitext" rows="10" cols="78">
<?cs var:milestone.description_source ?></textarea></p>
    </fieldset>
   </div>
   <div class="buttons">
    <?cs if:milestone.mode == "new"
     ?><input type="submit" value="새 마일스톤 추가하기" /><?cs
    else
     ?><input type="submit" value="변경사항 적용하기" /><?cs
    /if ?>
    <input type="submit" name="cancel" value="취소" />
   </div>
   <script type="text/javascript" src="<?cs
     var:htdocs_location ?>js/wikitoolbar.js"></script>
  </form>
 <?cs elif:milestone.mode == "delete" ?>
  <form action="<?cs var:milestone.href ?>" method="post">
   <input type="hidden" name="id" value="<?cs var:milestone.name ?>" />
   <input type="hidden" name="action" value="delete" />
   <p><strong>이 마일스톤을 정말로 삭제하시겠습니까??</strong></p>
   <input type="checkbox" id="retarget" name="retarget" checked="checked"
       onclick="enableControl('target', this.checked)"/>
   <label for="target">이 마일스톤과 연결된 티켓들을 </label>
   <select name="target" id="target">
    <option value="">None</option><?cs
     each:other = milestones ?><?cs if:other != milestone.name ?>
      <option><?cs var:other ?></option><?cs 
     /if ?><?cs /each ?>
   </select>
   <label for="target">마일스톤에 다시 연결하기 </label>
   <div class="buttons">
    <input type="submit" name="cancel" value="취소" />
    <input type="submit" value="마일스톤 삭제하기" />
   </div>
  </form>
 <?cs else ?>
 <?cs if:milestone.mode == "view" ?>
  <div class="info">
   <p class="date"><?cs
    if:milestone.completed_date ?>
     <?cs var:milestone.completed_delta ?> 전에 완료되었습니다. (<?cs var:milestone.completed_date ?>)<?cs
    elif:milestone.due_date ?><?cs
     if:milestone.late ?>
      <strong><?cs var:milestone.due_delta ?>의 기간이 늦어졌습니다.</strong><?cs
     else ?>
      <?cs var:milestone.due_delta ?>의 기간이 남았습니다.<?cs
     /if ?> (<?cs var:milestone.due_date ?>)<?cs
    else ?>
     기한이 정해지지 않았습니다<?cs
    /if ?>
   </p><?cs
   with:stats = milestone.stats ?><?cs
    if:#stats.total_tickets > #0 ?>
     <table class="progress">
      <tr>
      <td class="closed" style="width: <?cs
        var:#stats.percent_closed ?>%">
        <a href="<?cs
        var:milestone.queries.closed_tickets ?>" title="<?cs
        var:#stats.total_tickets ?>개중에 <?cs
        var:#stats.closed_tickets ?>개의 티켓<?cs
        if:#stats.total_tickets != #1 ?>들<?cs /if ?>이 닫혔습니다."></a></td>
      <td class="open" style="width: <?cs
        var:#stats.percent_active ?>%">
        <a href="<?cs
        var:milestone.queries.active_tickets ?>" title="<?cs
	var:#stats.total_tickets ?>개중에 <?cs
	var:#stats.active_tickets ?>개의 티켓<?cs
	if:#stats.total_tickets != #1 ?>들<?cs /if ?>이 활성화되어있습니다."></a>
      </tr>
     </table>
     <p class="percent"><?cs var:#stats.percent_closed ?>%</p>
     <dl>
      <dt>닫혀진 티켓들:</dt>
      <dd><a href="<?cs var:milestone.queries.closed_tickets ?>"><?cs
        var:stats.closed_tickets ?></a></dd>
      <dt>활성화된 티켓들:</dt>
      <dd><a href="<?cs var:milestone.queries.active_tickets ?>"><?cs
        var:stats.active_tickets ?></a></dd>
     </dl><?cs
    /if ?><?cs
   /with ?>
  </div>
  <form id="stats" action="" method="get">
   <fieldset>
    <legend>
     <select id="by" name="by" onchange="this.form.submit()"><?cs
     each:group = milestone.stats.available_groups ?>
      <option value="<?cs var:group.name ?>" <?cs
        if:milestone.stats.grouped_by == group.name ?> selected="selected"<?cs
        /if ?>><?cs var:group.label ?></option><?cs
     /each ?></select>
     <label for="by">에 따른 티켓의 상태</label>
     <noscript><input type="submit" value="갱신하기" /></noscript>
    </legend>
    <table summary="Shows the milestone completion status grouped by <?cs
      var:milestone.stats.grouped_by ?>"><?cs
     each:group = milestone.stats.groups ?>
      <tr>
       <th scope="row"><a href="<?cs
         var:group.queries.all_tickets ?>"><?cs var:group.name ?></a></th>
       <td style="white-space: nowrap"><?cs if:#group.total_tickets ?>
        <table class="progress" style="width: <?cs
          var:#group.percent_total * #80 / #milestone.stats.max_percent_total ?>%">
         <tr>
          <td class="closed" style="width: <?cs
            var:#group.percent_closed ?>%"><a href="<?cs
            var:group.queries.closed_tickets ?>" title="<?cs
           var:group.total_tickets ?>개중에 <?cs
           var:group.closed_tickets ?>개의 티켓<?cs
           if:group.total_tickets != #1 ?>들<?cs /if ?>이 닫혔습니다."></a>
          </td>
          <td class="open" style="width: <?cs
            var:#group.percent_active ?>%"><a href="<?cs
            var:group.queries.active_tickets ?>" title="<?cs
           var:group.total_tickets ?>개중에 <?cs
           var:group.active_tickets ?>개의 티켓<?cs
           if:group.total_tickets != 1 ?>들<?cs /if ?>이 활성화되어있습니다."></a>
          </td>
         </tr>
        </table>
        <p class="percent"><?cs var:group.closed_tickets ?>/<?cs
         var:group.total_tickets ?></p>
       <?cs /if ?></td>
      </tr><?cs
     /each ?>
    </table><?cs /if ?>
   </fieldset>
  </form>
  <div class="description"><?cs var:milestone.description ?></div><?cs
  if:trac.acl.MILESTONE_MODIFY || trac.acl.MILESTONE_DELETE ?>
   <div class="buttons"><?cs
    if:trac.acl.MILESTONE_MODIFY ?>
     <form method="get" action=""><div>
      <input type="hidden" name="action" value="edit" /><?cs
      if:milestone.id_param ?>
       <input type="hidden" name="id" value="<?cs var:milestone.name ?>" /><?cs
      /if ?>
      <input type="submit" value="마일스톤 정보 수정하기" accesskey="e" />
     </div></form><?cs
    /if ?><?cs
    if:trac.acl.MILESTONE_DELETE ?>
     <form method="get" action=""><div>
      <input type="hidden" name="action" value="delete" /><?cs
      if:milestone.id_param ?>
       <input type="hidden" name="id" value="<?cs var:milestone.name ?>" /><?cs
      /if ?>
      <input type="submit" value="마일스톤 삭제하기" />
     </div></form><?cs
    /if ?>
   </div><?cs
  /if ?><?cs
 /if ?>

 <div id="help">
  <strong>참고:</strong> 로드맵을 사용하면서 도움이 필요하다면, <a href="<?cs
    var:trac.href.wiki ?>/TracRoadmap">TracRoadmap</a> 페이지를 참고하십시오.
 </div>

</div>
<?cs include:"footer.cs"?>
