@echo off

if "%1"=="" goto usage

call set-tow.bat

"%SVN_HOME%\bin\svnadmin" create --fs-type=fsfs "%TOW_SVN_PRJ%\%1"
echo Subversion 저장소 [%TOW_SVN_PRJ%\%1] 가 만들어졌습니다.

"%SVN_HOME%\bin\svn" import %TOW_HOME%\SvnTemplate file:///C:/TOW/SvnRepo/Projects/%1 -m "initial import"
echo 초기 컨텐츠를 올렸습니다.

goto end

:usage
echo 사용법: %0 ^<프로젝트명^>

:end
