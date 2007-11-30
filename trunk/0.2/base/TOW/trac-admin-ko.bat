@echo off

if "%2"=="" goto usage

call set-tow.bat

"%PYTHON_HOME%\python" "%PYTHON_HOME%\Scripts\trac-admin" "%TOW_TRAC_PRJ%\%1" %2 %3 %4 %5 %6

goto end

:usage
echo 사용법: %0 ^<프로젝트명^> ^<명령어^>

:end
