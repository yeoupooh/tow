@echo off

call set-tow.bat

if "%1"=="" goto usage

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission list %2

goto end

:usage
call lang LIST_PERM_USAGE %0

:end
