@echo off

set TOW_RES_LANG_NAME=�ѱ���

set TOW_RES_NAME=�̸�
set TOW_RES_VERSION=����
set TOW_RES_PACKAGE=��Ű��
set TOW_RES_PACKAGE_BASE=�⺻
set TOW_RES_PACKAGE_STD=ǥ��
set TOW_RES_LANGUAGE=���
set TOW_RES_AUTHOR=������
set TOW_RES_SITE=Ȩ������
set TOW_RES_LICENSE=���۱�

if "%1"=="INIT_TOW_USAGE" echo ���: �� ��ġ������ TOW �����ڸ� ����մϴ�.

if "%1"=="LAUNCHED" echo %2 �� �����Ͽ����ϴ�.
if "%1"=="TEST_HERE" echo %2 �� �����ؼ� �׽�Ʈ �غ��ʽÿ�.

if "%1"=="SVN_REPO_CREATED" echo Subversion ����� [%2] �� ����������ϴ�.
if "%1"=="SVN_REPO_IMPORTED" echo �ʱ� �������� �÷Ƚ��ϴ�.
if "%1"=="CREATE_SVN_REPO_USAGE" echo ����: %2 ^<������Ʈ��^>

if "%1"=="TRAC_REPO_CREATED" echo Trac ����� [%2] �� ����������ϴ�.
if "%1"=="TRAC_INI_COPIED" echo �⺻������ ������ trac.ini �� �����߽��ϴ�.
if "%1"=="TRAC_ADMIN_SET" echo admin ������ TRAC_ADMIN, XML_RPC ������ �ο��߽��ϴ�.
if "%1"=="CREATE_TRAC_REPO_USAGE" echo ����: %2 ^<������Ʈ��^>

if "%1"=="TRAC_ADMIN_USAGE" echo ����: %2 ^<������Ʈ��^> ^<��ɾ�^>

if "%1"=="ADD_USER_USAGE" echo ����: %2 ^<������̸�^> ^<��й�ȣ^>

if "%1"=="ADD_REMOVE_PERM_USAGE" echo ����: %2 ^<������Ʈ��^> ^<������̸�^> ^<���ѵ�^>
if "%1"=="LIST_PERM_USAGE" echo ����: %2 ^<������Ʈ��^> ^[������̸�^]
