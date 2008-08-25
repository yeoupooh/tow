@echo off

call set-tow.bat

if "%2"=="" goto usage

%PYTHONHOME%\python "%PYTHONHOME%\Scripts\trac-admin-script.py" "%TOW_TRAC_PRJ%\%1" %2 %3 %4 %5 %6

goto end

:usage
call lang TRAC_ADMIN_USAGE %0

:end
