@echo off

if "%2"=="" goto usage

call set-tow.bat

%APACHE_HOME%\bin\htpasswd -b %TOW_SVN_PRJ%\trac.htpasswd %1 %2

goto end

:usage
echo 사용법: %0 ^<사용자ID^> ^<비밀번호^>

:end
