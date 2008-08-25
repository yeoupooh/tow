@echo off

call set-tow.bat

if not "%1"=="start" goto usage

copy %TOW_SETUP_HOME%\README-%TOW_LANG%.txt %TOW_HOME%\README.txt

copy %TOW_SETUP_HOME%\Apache\conf\httpd-%TOW_LANG%.conf %APACHE_HOME%\conf\httpd.conf
copy %TOW_SETUP_HOME%\Apache\logs\*.* %APACHE_HOME%\logs

copy %TOW_SETUP_HOME%\Python\Lib\site-packages\trac\wiki\default-pages\WikiStart-%TOW_LANG% %PYTHONHOME%\Lib\site-packages\trac\wiki\default-pages\WikiStart

if exist "%TOW_SVN_PRJ%\%TOW_TEST_PROJECT%" rd /S /Q "%TOW_SVN_PRJ%\%TOW_TEST_PROJECT%"
if exist "%TOW_TRAC_PRJ%\%TOW_TEST_PROJECT%" rd /S /Q "%TOW_TRAC_PRJ%\%TOW_TEST_PROJECT%"

call create-svn-repo %TOW_TEST_PROJECT%
call create-trac-repo %TOW_TEST_PROJECT%

goto end

:usage
call lang INIT_TOW_USAGE

:end
