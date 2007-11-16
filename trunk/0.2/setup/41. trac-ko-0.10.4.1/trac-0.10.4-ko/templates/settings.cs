<?cs include "header.cs"?>
<?cs include "macros.cs"?>

<div id="ctxtnav" class="nav"></div>

<div id="content" class="settings">

 <h1>환경설정 및 세션 관리</h1>

 <h2>사용자 환경설정</h2>
 <p>
 이 페이지에서 Trac에 대한 설정을 개인적으로 다르게 설정할 수
 있습니다.  세션 설정은 서버에 저장되며, 브라우저의 쿠키에서 '세션
 키'를 사용해서 구분되어 질 수 있습니다. 쿠키는 Trac에 대해 설정한
 셋팅을 복구할 수 있게 해줍니다.
 </p>
 <form method="post" action="">
 <div>
  <h3>개인적인 정보</h3>
  <div>
   <input type="hidden" name="action" value="save" />
   <label for="name">사용자이름:</label>
   <input type="text" id="name" name="name" class="textwidget" size="30"
          value="<?cs var:settings.name ?>" />
  </div>
  <div>
   <label for="email">이메일:</label>
   <input type="text" id="email" name="email" class="textwidget" size="30"
          value="<?cs var:settings.email ?>" />
  </div><?cs
  if:settings.session_id ?>
   <h3>세션</h3>
   <div>
    <label for="newsid">세션 키:</label>
    <input type="text" id="newsid" name="newsid" class="textwidget" size="30"
           value="<?cs var:settings.session_id ?>" />
    <p>세션 키는 서버에 저장된 개인적인 설정과 세션 데이타를 구분하는데
    사용됩니다. 기본적으로 자동적으로 생성되며, 만약 다른 웹 브라우저에서
    설정했던 사항을 사용하고 싶다면 언제든지 쉽게 변경할 수가 있습니다.</p>
   </div><?cs
  /if ?>
  <div>
   <br />
   <input type="submit" value="변경사항 적용하기" />
  </div >
 </div>
</form><?cs
if:settings.session_id ?>
 <hr />
 <h2>세션 로드하기</h2>
 <p>아래에 적당한 세션 키를 입력하고 '복구하기'를 누르면 이전에 생성했던 세션을
 로드할 수 있습니다. 이 기능은 Trac에 대해 설정한 셋팅을 여러 컴퓨터와 웹
 브라우저에서 공유할 수 있게 합니다.</p>
 <form method="post" action="">
  <div>
   <input type="hidden" name="action" value="load" />
   <label for="loadsid">존재하는 세션 키:</label>
   <input type="text" id="loadsid" name="loadsid" class="textwidget" size="30"
          value="" />
   <input type="submit" value="복구하기" />
  </div>
 </form><?cs
/if ?>

</div>
<?cs include:"footer.cs"?>
