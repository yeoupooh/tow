@echo off

if "%1"=="" goto usage

call set-tow.bat

"%SVN_HOME%\bin\svnadmin" create --fs-type=fsfs "%TOW_SVN_PRJ%\%1"
echo Subversion repository[%TOW_SVN_PRJ%\%1] created.

"%SVN_HOME%\bin\svn" import %TOW_HOME%\SvnTemplate file:///C:/TOW/SvnRepo/Projects/%1 -m "initial import"
echo Initial contents imported.

goto end

:usage
echo Usage: %0 ^<ProjectName^>

:end
