@echo off

if "%2"=="" goto usage

call set-tow.bat

"%PYTHON_HOME%\python" "%PYTHON_HOME%\Scripts\trac-admin" "%TOW_TRAC_PRJ%\%1" %2 %3 %4 %5 %6

goto end

:usage
call lang TRAC_ADMIN_USAGE %0

:end
