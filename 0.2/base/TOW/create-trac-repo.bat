@echo off

call set-tow.bat

if "%1"=="" goto usage

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

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" initenv %_PROJECTNAME% %_DB% %_REPOSTYPE% %_REPOSPATH% %_TEMPLATEPATH%
call lang TRAC_REPO_CREATED %TOW_SVN_PRJ%\%1

%PYTHON_HOME%\python rep-copy.py %_PROJECTNAME% %TOW_SETUP_HOME%\TracRepo\Projects\%TOW_TEST_PROJECT%\conf\trac-%TOW_PACKAGE%-%TOW_LANG%.ini.tpl "%TOW_TRAC_PRJ%\%1\conf\trac.ini"
call lang TRAC_INI_COPIED

if "%TOW_PACKAGE%"=="base" goto end
%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission add admin TRAC_ADMIN
%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission add admin XML_RPC
call lang TRAC_ADMIN_SET

goto end

:usage
call lang CREATE_TRAC_REPO_USAGE %0

:end
