@echo off

if "%2"=="" goto usage

call set-tow.bat

"%PYTHON_HOME%\python" "%PYTHON_HOME%\Scripts\trac-admin" "%TOW_TRAC_PRJ%\%1" %2 %3 %4 %5 %6

goto end

:usage
echo Usage: %0 ^<project name^> ^<commands^>

:end
