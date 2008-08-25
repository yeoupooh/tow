@echo off

call set-tow.bat

echo %TOW_RES_NAME%: %TOW_NAME%
echo %TOW_RES_VERSION%: %TOW_VERSION%
if "%TOW_PACKAGE%"=="base" set _TOW_PACKAGE_NAME=%TOW_RES_PACKAGE_BASE%
if "%TOW_PACKAGE%"=="std" set _TOW_PACKAGE_NAME=%TOW_RES_PACKAGE_STD%
echo %TOW_RES_PACKAGE%: %_TOW_PACKAGE_NAME%
echo %TOW_RES_LANGUAGE%: %TOW_RES_LANG_NAME%
echo %TOW_RES_AUTHOR%: %TOW_AUTHOR%
echo %TOW_RES_SITE%: %TOW_SITE%
echo %TOW_RES_LICENSE%: %TOW_LICENSE%
echo.
echo TOW_HOME    = %TOW_HOME%
echo PYTHONHOME  = %PYTHONHOME%
echo APACHE_HOME = %APACHE_HOME%
echo SVN_HOME    = %SVN_HOME%
echo SQLITE_HOME = %SQLITE_HOME%
echo.

call lang LAUNCHED %TOW_NAME%
call lang TEST_TRAC_HERE http://localhost:8080/projects/HelloTOW
call lang TEST_SVN_HERE http://localhost:8080/svn/HelloTOW

%APACHE_HOME%\bin\httpd

pause
