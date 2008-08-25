@echo off

call set-tow.bat

if "%1"=="" goto usage

rem trac-admin
rem initenv <projectname> <db> <repostype> <repospath>
rem         -- Create and initialize a new environment from arguments

rem set environment variables
set _PROJECTNAME=%1
set _DB=sqlite:db/trac.db
set _REPOSTYPE=svn
set _REPOSPATH="%TOW_SVN_PRJ%\%1"

rem display environment variables
echo PROJECTNAME=%_PROJECTNAME%
echo DB=%_DB%
echo REPOSTYPE=%_REPOSTYPE%
echo REPOSPATH=%_REPOSPATH%

rem init trac environent
call trac-admin %1 initenv %_PROJECTNAME% %_DB% %_REPOSTYPE% %_REPOSPATH%
call lang TRAC_REPO_CREATED %TOW_SVN_PRJ%\%1

rem copy trac.ini file
%PYTHONHOME%\python rep-copy.py %_PROJECTNAME% %TOW_SETUP_HOME%\TracRepo\Projects\%TOW_TEST_PROJECT%\conf\trac-%TOW_PACKAGE%-%TOW_LANG%.ini.tpl "%TOW_TRAC_PRJ%\%1\conf\trac.ini"
call lang TRAC_INI_COPIED

rem copy logo image
copy "%TOW_SETUP_HOME%\TracRepo\Projects\%TOW_TEST_PROJECT%\htdocs\tow-logo.png" "%TOW_TRAC_PRJ%\%1\htdocs"
call lang TRAC_BANNER_COPIED

rem grant permissions to admin account
call trac-admin %_PROJECTNAME% permission add admin TRAC_ADMIN
call lang TRAC_ADMIN_PERM_ADDED

if "%TOW_PACKAGE%"=="base" goto end
call trac-admin %_PROJECTNAME% permission add admin XML_RPC
call lang XML_RPC_PERM_ADDED

goto end

:usage
call lang CREATE_TRAC_REPO_USAGE %0

:end
