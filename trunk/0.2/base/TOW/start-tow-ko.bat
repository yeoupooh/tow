@echo off

call set-tow.bat

echo �̸�     = %TOW_NAME%
echo ����     = %TOW_VERSION%
echo ������   = %TOW_AUTHOR%
echo Ȩ������ = %TOW_SITE%
echo ���۱�   = %TOW_LICENSE%
echo.
echo TOW_HOME    = %TOW_HOME%
echo PYTHON_HOME = %PYTHON_HOME%
echo APACHE_HOME = %APACHE_HOME%
echo SVN_HOME    = %SVN_HOME%
echo SQLITE_HOME = %SQLITE_HOME%
echo.
echo %TOW_NAME% �����Ͽ����ϴ�.
echo http://localhost:8080/projects/HelloTOW �� �����ؼ� �׽�Ʈ �غ��ʽÿ�.

%APACHE_HOME%\bin\httpd

pause
