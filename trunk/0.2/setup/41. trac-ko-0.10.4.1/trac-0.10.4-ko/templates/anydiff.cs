<?cs include "header.cs"?>

<div id="ctxtnav" class="nav"></div>

<div id="content" class="changeset">
 <div id="title">
    <h1>차이점을 비교하기 위한 시작과 끝을 선택하십시오.:</h1>
 </div>

 <div id="anydiff">
  <form action="<?cs var:anydiff.changeset_href ?>" method="get">
   <table>
    <tr>
     <th><label for="old_path">시작:</label></th>
     <td>
      <input type="text" id="old_path" name="old_path" value="<?cs
         var:anydiff.old_path ?>" size="44" />
      <label for="old_rev">리비전:</label>
      <input type="text" id="old_rev" name="old" value="<?cs
         var:anydiff.old_rev ?>" size="4" />
     </td>
    </tr>
    <tr>
     <th><label for="new_path">끝:</label></th>
     <td>
      <input type="text" id="new_path" name="new_path" value="<?cs
         var:anydiff.new_path ?>" size="44" />
      <label for="new_rev">리비전:</label>
      <input type="text" id="new_rev" name="new" value="<?cs
         var:anydiff.new_rev ?>" size="4" />
     </td>
    </tr>
   </table>
   <div class="buttons">
      <input type="submit" value="차이점 보기" />
   </div>
  </form>
 </div>
 <div id="help">
  <strong>참고:</strong> 임의의 리비전을 비교하는 기능을 사용하면서 도움이 필요하다면, <a href="<?cs var:trac.href.wiki
  ?>/TracChangeset#ExaminingDifferencesBetweenBranches">TracChangeset</a> 페이지를 참고하십시오.
 </div>
</div>

<?cs include "footer.cs"?>
