@echo off

call set-tow.bat

echo 이름     = %TOW_NAME%
echo 버전     = %TOW_VERSION%
echo 개발자   = %TOW_AUTHOR%
echo 홈페이지 = %TOW_SITE%
echo 저작권   = %TOW_LICENSE%
echo.
echo TOW_HOME    = %TOW_HOME%
echo PYTHON_HOME = %PYTHON_HOME%
echo APACHE_HOME = %APACHE_HOME%
echo SVN_HOME    = %SVN_HOME%
echo SQLITE_HOME = %SQLITE_HOME%
echo.
echo %TOW_NAME% 실행하였습니다.
echo http://localhost:8080/projects/HelloTOW 로 접속해서 테스트 해보십시오.

%APACHE_HOME%\bin\httpd

pause
