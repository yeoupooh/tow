@echo off

if "%1"=="" goto usage

call set-tow.bat

"%SVN_HOME%\bin\svnadmin" create --fs-type=fsfs "%TOW_SVN_PRJ%\%1"
echo Subversion ����� [%TOW_SVN_PRJ%\%1] �� ����������ϴ�.

"%SVN_HOME%\bin\svn" import %TOW_HOME%\SvnTemplate file:///C:/TOW/SvnRepo/Projects/%1 -m "initial import"
echo �ʱ� �������� �÷Ƚ��ϴ�.

goto end

:usage
echo ����: %0 ^<������Ʈ��^>

:end
