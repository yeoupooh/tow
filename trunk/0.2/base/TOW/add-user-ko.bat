@echo off

if "%2"=="" goto usage

call set-tow.bat

%APACHE_HOME%\bin\htpasswd -b %TOW_SVN_PRJ%\trac.htpasswd %1 %2

goto end

:usage
echo ����: %0 ^<�����ID^> ^<��й�ȣ^>

:end
