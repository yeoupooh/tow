@echo off

if "%1"=="" goto usage

call set-tow.bat

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission list %2

goto end

:usage
echo Usage: %0 ^<ProjectName^> ^[UserName^]

:end
