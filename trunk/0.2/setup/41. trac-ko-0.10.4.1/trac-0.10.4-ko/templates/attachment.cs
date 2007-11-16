<?cs include "header.cs" ?>
<?cs include "macros.cs" ?>

<div id="ctxtnav" class="nav"></div>

<div id="content" class="attachment">

<?cs if:attachment.mode == 'new' ?>
 <h1><a href="<?cs var:attachment.parent.href?>"><?cs
   var:attachment.parent.name ?></a>에 첨부파일 추가하기</h1>
 <form id="attachment" method="post" enctype="multipart/form-data" action="">
  <div class="field">
   <label>첨부파일 경로:<br /><input type="file" name="attachment" /></label>
  </div>
  <fieldset>
   <legend>첨부파일에 대한 정보</legend>
   <?cs if:trac.authname == "anonymous" ?>
    <div class="field">
     <label>Your email or username:<br />
     <input type="text" name="author" size="30" value="<?cs
       var:attachment.author?>" /></label>
    </div>
   <?cs /if ?>
   <div class="field">
    <label>이 파일에 대한 설명 (부가정보):<br />
    <input type="text" name="description" size="60" /></label>
   </div>
   <br />
   <div class="options">
    <label><input type="checkbox" name="replace" />
    같은 이름을 가진 이미 존재하는 첨부파일 대체하기</label>
   </div>
   <br />
  </fieldset>
  <div class="buttons">
   <input type="hidden" name="action" value="new" />
   <input type="hidden" name="type" value="<?cs var:attachment.parent.type ?>" />
   <input type="hidden" name="id" value="<?cs var:attachment.parent.id ?>" />
   <input type="submit" value="첨부파일 추가하기" />
   <input type="submit" name="cancel" value="취소" />
  </div>
 </form>
<?cs elif:attachment.mode == 'delete' ?>
 <h1><a href="<?cs var:attachment.parent.href ?>"><?cs
   var:attachment.parent.name ?></a>: <?cs var:attachment.filename ?></h1>
 <p><strong>이 첨부파일을 정말로 삭제하시겠습니까?</strong><br />
 이 동작은 되돌릴 수가 없습니다.</p>
 <div class="buttons">
  <form method="post" action=""><div id="delete">
   <input type="hidden" name="action" value="delete" />
   <input type="submit" name="cancel" value="취소" />
   <input type="submit" value="첨부파일 삭제하기" />
  </div></form>
 </div>
<?cs elif:attachment.mode == 'list' ?>
 <h1><a href="<?cs var:attachment.parent.href ?>"><?cs
   var:attachment.parent.name ?></a></h1><?cs
  call:list_of_attachments(attachment.list, attachment.attach_href) ?>
<?cs else ?>
 <h1><a href="<?cs var:attachment.parent.href ?>"><?cs
   var:attachment.parent.name ?></a>: <?cs var:attachment.filename ?></h1>
 <table id="info" summary="Description"><tbody><tr>
   <th scope="col">
    File <?cs var:attachment.filename ?>, <?cs var:attachment.size ?> 
    (added by <?cs var:attachment.author ?>,  <?cs var:attachment.age ?> ago)
   </th></tr><tr>
   <td class="message"><?cs var:attachment.description ?></td>
  </tr>
 </tbody></table>
 <div id="preview"><?cs
  if:attachment.preview ?>
   <?cs var:attachment.preview ?><?cs
  elif:attachment.max_file_size_reached ?>
   <strong>HTML 미리보기가 지원되지 않습니다.</strong> 파일 사이즈가 
   <?cs var:attachment.max_file_size  ?> 바이트를 넘습니다. 대신에 파일을 <a href="<?cs
     var:attachment.raw_href ?>">다운로드</a>하십시오.<?cs
  else ?>
   <strong>HTML 미리보기가 지원되지 않습니다.</strong> 파일을 보기 위해서는,
   <a href="<?cs var:attachment.raw_href ?>">파일을 다운로드 하십시오.</a>.<?cs
  /if ?>
 </div>
 <?cs if:attachment.can_delete ?><div class="buttons">
  <form method="get" action=""><div id="delete">
   <input type="hidden" name="action" value="delete" />
   <input type="submit" value="첨부파일 삭제하기" />
  </div></form>
 </div><?cs /if ?>
<?cs /if ?>

</div>
<?cs include "footer.cs"?>
