@echo off

if "%3"=="" goto usage

call set-tow.bat

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission remove %2 %3 %4 %5 %6 %7 %8 %9

goto end

:usage
call lang ADD_REMOVE_PERM_USAGE %0

:end
