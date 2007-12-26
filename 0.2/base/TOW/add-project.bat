@echo off

call set-tow.bat

if "%1"=="" goto usage

call create-svn-repo.bat %1
call create-trac-repo.bat %1

goto end

:usage
call lang ADD_PROJECT_USAGE %0

:end
