@echo off

set TOW_RES_LANG_NAME=Enlish

set TOW_RES_NAME=Name
set TOW_RES_VERSION=Version
set TOW_RES_PACKAGE=Package
set TOW_RES_PACKAGE_BASE=Base
set TOW_RES_PACKAGE_STD=Standard
set TOW_RES_LANGUAGE=Language
set TOW_RES_AUTHOR=Author
set TOW_RES_SITE=Site
set TOW_RES_LICENSE=License

if "%1"=="INIT_TOW_USAGE" echo [TOW] WARNING: This script is for TOW Developer.

if "%1"=="LAUNCHED" echo [TOW] %2 Launched.
if "%1"=="TEST_HERE" echo [TOW] Now, you can test in %2

if "%1"=="SVN_REPO_CREATED" echo [TOW] Subversion repository[%2] created.
if "%1"=="SVN_REPO_IMPORTED" echo [TOW] Initial contents imported.
if "%1"=="CREATE_SVN_REPO_USAGE" echo [TOW] Usage: %2 ^<ProjectName^>

if "%1"=="TRAC_REPO_CREATED" echo [TOW] Trac repository[%2] created.
if "%1"=="TRAC_INI_COPIED" echo [TOW] Initial trac.ini copied.
if "%1"=="TRAC_ADMIN_SET" echo [TOW] Gave TRAC_ADMIN, XML_RPC permissions to admin account.
if "%1"=="CREATE_TRAC_REPO_USAGE" echo [TOW] Usage: %2 ^<ProjectName^>

if "%1"=="TRAC_ADMIN_USAGE" echo [TOW] Usage: %2 ^<ProjectName^> ^<Commands^>

if "%1"=="ADD_USER_USAGE" echo [TOW] Usage: %2 ^<UserName^> ^<Password^>

if "%1"=="ADD_REMOVE_PERM_USAGE" echo [TOW] Usage: %2 ^<ProjectName^> ^<UserName^> ^<Permissions^>
if "%1"=="LIST_PERM_USAGE" echo [TOW] Usage: %2 ^<ProjectName^> ^[UserName^]

if "%1"=="ADD_PROJECT_USAGE" echo [TOW] Usage: %2 ^<ProjectName^>
