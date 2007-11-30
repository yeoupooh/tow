@echo off

if "%1"=="" goto usage

call set-tow.bat

rem trac-admin
rem initenv <projectname> <db> <repostype> <repospath> <templatepath>
rem         -- Create and initialize a new environment from arguments

set _PROJECTNAME=%1
set _DB=sqlite:db/trac.db
set _REPOSTYPE=svn
set _REPOSPATH="%TOW_SVN_PRJ%\%1"
set _TEMPLATEPATH="%PYTHON_HOME%\share\trac\templates"

echo PROJECTNAME=%_PROJECTNAME%
echo DB=%_DB%
echo REPOSTYPE=%_REPOSTYPE%
echo REPOSPATH=%_REPOSPATH%
echo TEMPLATEPATH=%_TEMPLATEPATH%

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin	"%TOW_TRAC_PRJ%\%1" initenv %_PROJECTNAME% %_DB% %_REPOSTYPE% %_REPOSPATH% %_TEMPLATEPATH%
echo Trac 저장소 [%TOW_SVN_PRJ%\%1] 가 만들어졌습니다.

goto end

:usage
echo 사용법: %0 ^<프로젝트명^>

:end
