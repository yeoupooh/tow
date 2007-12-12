@echo off

call set-tow.bat

if "%2"=="" goto usage

%APACHE_HOME%\bin\htpasswd -b %TOW_SVN_PRJ%\trac.htpasswd %1 %2

goto end

:usage
call lang ADD_USER_USAGE %0

:end
