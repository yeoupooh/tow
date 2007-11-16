<?cs include "header.cs"?>
<?cs include "macros.cs"?>

<div id="ctxtnav" class="nav"></div>

<div id="content" class="roadmap">
 <h1>로드맵</h1>

 <form id="prefs" method="get" action="">
  <div>
   <input type="checkbox" id="showall" name="show" value="all"<?cs
    if:roadmap.showall ?> checked="checked"<?cs /if ?> />
   <label for="showall">이미 완료된 마일스톤들도 보기</label>
  </div>
  <div class="buttons">
   <input type="submit" value="갱신하기" />
  </div>
 </form>

 <ul class="milestones"><?cs each:milestone = roadmap.milestones ?>
  <li class="milestone">
   <div class="info">
    <h2><a href="<?cs var:milestone.href ?>">마일스톤: <em><?cs
      var:milestone.name ?></em></a></h2>
    <p class="date"<?cs
     if:milestone.completed_date ?> title="<?cs var:milestone.completed_date ?>">
      <?cs var:milestone.completed_delta ?> 전에 완료되었습니다.<?cs
     elif:milestone.due_date ?> title="<?cs var:milestone.due_date ?>"><?cs
      if:milestone.late ?>
       <strong><?cs var:milestone.due_delta ?>의 기간이 늦어졌습니다.</strong><?cs
      else ?>
       <?cs var:milestone.due_delta ?>의 기간이 남았습니다<?cs
      /if ?> (<?cs var:milestone.due_date ?>)<?cs
     else ?>>
      기한이 정해지지 않았습니다<?cs
     /if ?>
    </p><?cs
    with:stats = milestone.stats ?><?cs
     if:#stats.total_tickets > #0 ?>
      <table class="progress">
       <tr>
        <td class="closed" style="width: <?cs
          var:#stats.percent_closed ?>%"><a href="<?cs
          var:milestone.queries.closed_tickets ?>" title="<?cs
          var:#stats.total_tickets ?>개중에 <?cs
          var:#stats.closed_tickets ?>개의 티켓<?cs
          if:#stats.total_tickets != #1 ?>들<?cs /if ?>이 닫혔습니다."></a></td>
        <td class="open" style="width: <?cs
          var:#stats.percent_active ?>%"><a href="<?cs
          var:milestone.queries.active_tickets ?>" title="<?cs
          var:#stats.total_tickets ?>개중에 <?cs
          var:#stats.active_tickets ?>개의 티켓<?cs
          if:#stats.total_tickets != #1 ?>들<?cs /if ?>이 활성화되어있습니다."></a></td>
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
   <div class="description"><?cs var:milestone.description ?></div>
  </li><?cs
 /each ?></ul><?cs
 if:trac.acl.MILESTONE_CREATE ?>
  <div class="buttons">
   <form method="get" action="<?cs var:trac.href.milestone ?>"><div>
    <input type="hidden" name="action" value="new" />
    <input type="submit" value="새로운 마일스톤 추가하기" />
   </div></form>
  </div><?cs
 /if ?>

 <div id="help">
  <strong>참고:</strong> 로드맵을 사용하면서 도움이 필요하다면, <a href="<?cs
    var:trac.href.wiki ?>/TracRoadmap">TracRoadmap</a>을 참고하십시오.
 </div>

</div>
<?cs include:"footer.cs"?>
