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
echo Trac ����� [%TOW_SVN_PRJ%\%1] �� ����������ϴ�.

copy %TOW_HOME%\TracTemplate\conf\trac.ini "%TOW_TRAC_PRJ%\%1\conf"
echo �⺻���� ������ trac.ini �� �����߽��ϴ�.

%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission add admin TRAC_ADMIN
%PYTHON_HOME%\python %PYTHON_HOME%\Scripts\trac-admin "%TOW_TRAC_PRJ%\%1" permission add admin XML_RPC
echo admin ������ TRAC_ADMIN, XML_RPC ������ �ο��߽��ϴ�.

goto end

:usage
echo ����: %0 ^<������Ʈ��^>

:end
