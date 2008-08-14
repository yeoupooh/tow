@echo off

call set-tow.bat

if "%1"=="" goto usage

rem --pre-1.4-compatible for svn 1.4 client
"%SVN_HOME%\bin\svnadmin" create --pre-1.4-compatible --fs-type fsfs "%TOW_SVN_PRJ%\%1"
call lang SVN_REPO_CREATED "%TOW_SVN_PRJ%\%1"

"%SVN_HOME%\bin\svn" import %TOW_HOME%\SvnTemplate file:///C:/TOW/SvnRepo/Projects/%1 -m "initial import"
call lang SVN_REPO_IMPORTED

goto end

:usage
call lang CREATE_SVN_REPO_USAGE %0

:end
