@echo off

set TOW_HOME=C:\TOW
set TOW_NAME=TOW (TracOnWindows)
set TOW_VERSION=0.2.2
rem en, ko
set TOW_LANG=ko
rem base, std
set TOW_PACKAGE=base
set TOW_AUTHOR=Jinwoo Min (yeoupooh at gmail dot com)
set TOW_SITE=http://sourceforge.net/projects/traconwindows
set TOW_LICENSE=http://creativecommons.org/licenses/by-sa/2.0/

call lang

set SVN_HOME=%TOW_HOME%\Subversion
set PYTHON_HOME=%TOW_HOME%\Python
set PYTHONPATH=%PYTHON_HOME%;%PYTHON_HOME%\DLLs;%PYTHON_HOME%\Scripts;%PYTHON_HOME%\Lib;
rem additional python path (not used)
rem set PYTHONPATH=%PYTHONPATH%;%PYTHON_HOME%\Lib\lib-tk;%PYTHON_HOME%\Lib\site-packages;%PYTHON_HOME%\Lib\site-packages\mod_python
set APACHE_HOME=%TOW_HOME%\Apache
set SQLITE_HOME=%TOW_HOME%\SQLite

set TOW_SVN_REPO=%TOW_HOME%\SvnRepo
set TOW_TRAC_REPO=%TOW_HOME%\TracRepo

set TOW_SVN_PRJ=%TOW_SVN_REPO%\Projects
set TOW_TRAC_PRJ=%TOW_TRAC_REPO%\Projects

if not "%TOW_SET_PATH%"=="" goto skip
set TOW_SET_PATH=TRUE
set PATH=%SVN_HOME%\bin;%PYTHONPATH%;%APACHE_HOME%\bin;%APACHE_HOME%\modules;%SQLITE_HOME%;%PATH%
:skip

echo TOW_HOME=%TOW_HOME%
echo PATH=%PATH%
echo.
