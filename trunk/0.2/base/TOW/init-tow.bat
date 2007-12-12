@echo off

if not "%1"=="start" goto usage

copy %APACHE_HOME%\conf\httpd-%TOW_LANG%.conf %APACHE_HOME%\conf\httpd.conf
copy %TOW_HOME%\TracTemplate\wiki-default\WikiStart-%TOW_LANG% %PYTHON_HOME%\share\trac\wiki-default\WikiStart

goto end

:usage
call lang INIT_TOW_USAGE

:end
