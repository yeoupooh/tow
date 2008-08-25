@echo off

call set-tow.bat

if "%3"=="" goto usage

call trac-admin %1 permission add %2 %3 %4 %5 %6 %7 %8 %9

goto end

:usage
call lang ADD_REMOVE_PERM_USAGE %0

:end
