@echo off

set TOW_RES_LANG_NAME=한글판

set TOW_RES_NAME=이름
set TOW_RES_VERSION=버전
set TOW_RES_PACKAGE=패키지
set TOW_RES_PACKAGE_BASE=기본
set TOW_RES_PACKAGE_STD=표준
set TOW_RES_LANGUAGE=언어
set TOW_RES_AUTHOR=개발자
set TOW_RES_SITE=홈페이지
set TOW_RES_LICENSE=저작권

if "%1"=="INIT_TOW_USAGE" echo [TOW] 경고: 이 배치파일은 TOW 개발자만 사용합니다.

if "%1"=="LAUNCHED" echo [TOW] %2 를 실행하였습니다.
if "%1"=="TEST_HERE" echo [TOW] %2 로 접속해서 테스트 해보십시오.

if "%1"=="SVN_REPO_CREATED" echo [TOW] Subversion 저장소 [%2] 가 만들어졌습니다.
if "%1"=="SVN_REPO_IMPORTED" echo [TOW] 초기 컨텐츠를 올렸습니다.
if "%1"=="CREATE_SVN_REPO_USAGE" echo [TOW] 사용법: %2 ^<프로젝트명^>

if "%1"=="TRAC_REPO_CREATED" echo [TOW] Trac 저장소 [%2] 가 만들어졌습니다.
if "%1"=="TRAC_INI_COPIED" echo [TOW] 기본적으로 설정된 trac.ini 를 복사했습니다.
if "%1"=="TRAC_ADMIN_SET" echo [TOW] admin 계정에 TRAC_ADMIN, XML_RPC 권한을 부여했습니다.
if "%1"=="CREATE_TRAC_REPO_USAGE" echo [TOW] 사용법: %2 ^<프로젝트명^>

if "%1"=="TRAC_ADMIN_USAGE" echo [TOW] 사용법: %2 ^<프로젝트명^> ^<명령어^>

if "%1"=="ADD_USER_USAGE" echo [TOW] 사용법: %2 ^<사용자이름^> ^<비밀번호^>

if "%1"=="ADD_REMOVE_PERM_USAGE" echo [TOW] 사용법: %2 ^<프로젝트명^> ^<사용자이름^> ^<권한들^>
if "%1"=="LIST_PERM_USAGE" echo [TOW] 사용법: %2 ^<프로젝트명^> ^[사용자이름^]
