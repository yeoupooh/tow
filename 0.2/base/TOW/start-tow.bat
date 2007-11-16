@echo off

call set-tow.bat

echo Name    = %TOW_NAME%
echo Version = %TOW_VERSION%
echo Author  = %TOW_AUTHOR%
echo Site    = %TOW_SITE%
echo License = %TOW_LICENSE%
echo.
echo TOW_HOME    = %TOW_HOME%
echo PYTHON_HOME = %PYTHON_HOME%
echo APACHE_HOME = %APACHE_HOME%
echo SVN_HOME    = %SVN_HOME%
echo SQLITE_HOME = %SQLITE_HOME%
echo.
echo %TOW_NAME% launched.
echo Now, you can test in http://localhost:8080/projects/HelloTOW

%APACHE_HOME%\bin\httpd



pause
