= TOW (Trac On Windows) ��ġ�� �����Ͽ����ϴ�. =
 * ������Ʈ ��α�: [http://traconwindows.wordpress.com]
 * ������Ʈ ����Ʈ: [http://sourceforge.net/projects/traconwindows]
 * ������: Jinwoo Min (yeoupooh at gmail dot com)
 * ���۱�: http://creativecommons.org/licenses/by-sa/2.0/
 
== TOW 0.2 �⺻ ��Ű�� (�ѱ���)�� ��ġ�Ǵ� �� ==
 * python 2.4.4
 * trac-ko 0.10.4
 * clearsilver 0.9.14
 * apache 2.2.6
 * mod_python 3.3.1
 * subversion 1.4.5
 * svn-python 1.4.5
 * sqlite 3.5.2
 * pysqlite 2.3.5
 * easy_install
 
== TOW 0.2 ǥ�� ��Ű�� (�ѱ���)�� ��ġ�Ǵ� �� ==
 * TOW 0.2 �⺻ ��Ű�� (�ѱ���) ����
 * admin ������ TRAC_ADMIN ������ ����.
 * �÷�����
   * Web Admin Plugin !r6060
   * Account Manager Plugin !r2548
   * XML-RPC Plugin !r2800
   * Eclipse Trac Integration !r2801
   * WYSIWYG Editor Plugin !r2820
   * trac.ini Admin Plugin !r2825
   * !TracNav 3.92
 * ��ũ��
   * TOC Macro !r2828
  
= TOW ��ġ =

== ��ġ ���� ==
 * �̹� Subversion�̳� Python�� ��ġ�Ǿ� �ִٸ� ����ʽÿ�. TOW�� �浹�� �� �ֽ��ϴ�.
 * TOW-*.zip ������ C:\ �� Ǳ�ϴ�. (�ٸ� ���䷹ Ǯ�� ������ �ȵɰ̴ϴ�.) 
 * start-tow.bat �����մϴ�.
{{{
C:\TOW>start-tow.bat
}}}
 * ��ġ ��!

== ��ġ �׽�Ʈ ==
 * http://localhost:8080/projects/HelloTOW �� �����մϴ�.

= TOW ���� =
 * admin ������ �⺻ ��й�ȣ�� towadmin �Դϴ�. �ݵ�� �����Ͻñ� �ٶ��ϴ�.

== ����� �߰� ==
{{{
C:\TOW>add-user.bat <�����ID> <��й�ȣ>
}}}

== ������Ʈ �߰� ==
{{{
C:\TOW>create-svn-repo.bat <������Ʈ��>
C:\TOW>create-trac-repo.bat <������Ʈ��>
}}}

=== �÷����� Ȱ��ȭ�ϱ� (ǥ�� ��Ű�� ����ڵ鸸 �ش�˴ϴ�.) ===
 * ������Ʈ���� trac.ini ���Ͽ� �Ʒ��� ������ �����̰ų� �����մϴ�. (C:\TOW\!TracRepo\Projects\<!������Ʈ��>\conf\trac.ini)
{{{
[components]
acct_mgr.web_ui.loginmodule = enabled
acct_mgr.web_ui.registrationmodule = enabled
iniadmin.iniadmin.iniadminplugin = enabled
trac.web.auth.loginmodule = disabled
tracnav.* = enabled
tracrpc.* = enabled
tracrpcext.* = enabled
tractoc.* = enabled
tracwysiwyg.* = enabled
webadmin.* = enabled
}}}
 
== trac-admin �����ϱ� ==
{{{
C:\TOW>trac-admin.bat <ProjectName> <Commands>
}}}
 * [http://trac.edgewall.org/wiki/TracAdmin TracAdmin]
 
== easy_install �����ϱ� ==
{{{
C:\TOW>easy_install.bat <Arguments>
}}}
 * [http://peak.telecommunity.com/DevCenter/EasyInstall EasyInstall]
