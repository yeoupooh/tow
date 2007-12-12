@echo off

if "%3"=="" goto usage

call set-tow.bat

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission add %2 %3 %4 %5 %6 %7 %8 %9

goto end

:usage
echo Usage: %0 ^<ProjectName^> ^<UserName^> ^<Permissions^>

:end
