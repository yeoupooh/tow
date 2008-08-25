@echo off

call set-tow.bat

if "%1"=="" goto usage

call trac-admin %1 permission list %2 %3 %4 %5 %6 %7 %8 %9

goto end

:usage
call lang LIST_PERM_USAGE %0

:end
