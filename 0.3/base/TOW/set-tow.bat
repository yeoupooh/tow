@echo off

set TOW_HOME=C:\TOW
set TOW_NAME=TOW (TracOnWindows)
set TOW_VERSION=0.3.0 alpha 2
rem en, ko
set TOW_LANG=en
rem base, std
set TOW_PACKAGE=base
set TOW_AUTHOR=Jinwoo Min (yeoupooh at gmail dot com)
set TOW_SITE=http://sourceforge.net/projects/traconwindows
set TOW_LICENSE=http://creativecommons.org/licenses/by-sa/2.0/

call lang

set SVN_HOME=%TOW_HOME%\Subversion
set APR_ICONV_PATH=%SVN_HOME%\iconv
set PYTHONHOME=%TOW_HOME%\Python
set PYTHONPATH=%PYTHONHOME%;%PYTHONHOME%\DLLs;%PYTHONHOME%\Scripts;%PYTHONHOME%\Lib;
rem additional python path (not used)
rem set PYTHONPATH=%PYTHONPATH%;%PYTHONHOME%\Lib\lib-tk;%PYTHONHOME%\Lib\site-packages;%PYTHONHOME%\Lib\site-packages\mod_python
set APACHE_HOME=%TOW_HOME%\Apache
set SQLITE_HOME=%TOW_HOME%\SQLite

set TOW_SETUP_HOME=%TOW_HOME%\Setup
set TOW_TEST_PROJECT=HelloTOW

set TOW_SVN_REPO=%TOW_HOME%\SvnRepo
set TOW_TRAC_REPO=%TOW_HOME%\TracRepo

set TOW_SVN_PRJ=%TOW_SVN_REPO%\Projects
set TOW_TRAC_PRJ=%TOW_TRAC_REPO%\Projects

if not "%TOW_SET_PATH%"=="" goto skip
set TOW_SET_PATH=TRUE
set PATH=%SVN_HOME%\bin;%PYTHONPATH%;%APACHE_HOME%\bin;%APACHE_HOME%\modules;%SQLITE_HOME%;%PATH%
:skip

rem echo TOW_HOME=%TOW_HOME%
rem echo PATH=%PATH%
rem echo.
