= TOW (Trac On Windows) 설치에 성공하였습니다. =
 * 프로젝트 블로그: [http://traconwindows.wordpress.com]
 * 프로젝트 사이트: [http://sourceforge.net/projects/traconwindows]
 * 개발자: Jinwoo Min (yeoupooh at gmail dot com)
 * 저작권: http://creativecommons.org/licenses/by-sa/2.0/
 
== TOW 0.2 기본 패키지 (한글판)에 설치되는 것 ==
 * python 2.4.4
 * trac-ko 0.10.4
 * clearsilver 0.9.14
 * apache 2.2.6
 * mod_python 3.3.1
 * subversion 1.4.5
 * svn-python 1.4.5
 * sqlite 3.5.2
 * pysqlite 2.3.5
 * easy_install
 
== TOW 0.2 표준 패키지 (한글판)에 설치되는 것 ==
 * TOW 0.2 기본 패키지 (한글판) 포함
 * admin 계정에 TRAC_ADMIN 권한이 생김.
 * 플러그인
   * Web Admin Plugin !r6060
   * Account Manager Plugin !r2548
   * XML-RPC Plugin !r2800
   * Eclipse Trac Integration !r2801
   * WYSIWYG Editor Plugin !r2820
   * trac.ini Admin Plugin !r2825
   * !TracNav 3.92
 * 매크로
   * TOC Macro !r2828
  
= TOW 설치 =

== 설치 절차 ==
 * 이미 Subversion이나 Python이 설치되어 있다면 지우십시오. TOW와 충돌할 수 있습니다.
 * TOW-*.zip 파일을 C:\ 에 풉니다. (다른 디렉토레 풀면 실행이 안될겁니다.) 
 * start-tow.bat 실행합니다.
{{{
C:\TOW>start-tow.bat
}}}
 * 설치 끝!

== 설치 테스트 ==
 * http://localhost:8080/projects/HelloTOW 에 접속합니다.

= TOW 관리 =
 * admin 계정의 기본 비밀번호는 towadmin 입니다. 반드시 변경하시기 바랍니다.

== 사용자 추가 ==
{{{
C:\TOW>add-user.bat <사용자ID> <비밀번호>
}}}

== 프로젝트 추가 ==
{{{
C:\TOW>create-svn-repo.bat <프로젝트명>
C:\TOW>create-trac-repo.bat <프로젝트명>
}}}

=== 플러그인 활성화하기 (표준 패키지 사용자들만 해당됩니다.) ===
 * 프로젝트별로 trac.ini 파일에 아래의 내용을 덧붙이거나 수정합니다. (C:\TOW\!TracRepo\Projects\<!프로젝트명>\conf\trac.ini)
{{{
[components]
acct_mgr.web_ui.loginmodule = enabled
acct_mgr.web_ui.registrationmodule = enabled
iniadmin.iniadmin.iniadminplugin = enabled
trac.web.auth.loginmodule = disabled
tracnav.* = enabled
tracrpc.* = enabled
tracrpcext.* = enabled
tractoc.* = enabled
tracwysiwyg.* = enabled
webadmin.* = enabled
}}}
 
== trac-admin 실행하기 ==
{{{
C:\TOW>trac-admin.bat <ProjectName> <Commands>
}}}
 * [http://trac.edgewall.org/wiki/TracAdmin TracAdmin]
 
== easy_install 실행하기 ==
{{{
C:\TOW>easy_install.bat <Arguments>
}}}
 * [http://peak.telecommunity.com/DevCenter/EasyInstall EasyInstall]
