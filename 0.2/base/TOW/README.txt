= Welcome to TOW (Trac On Windows) =
 * Project Site: [http://sourceforge.net/projects/traconwindows]
 * Author: Jinwoo Min (yeoupooh at gmail dot com)
 * License: http://creativecommons.org/licenses/by-sa/2.0/
 
== TOW 0.2 Base package includes ==
 * python 2.4.4
 * trac 0.10.4
 * clearsilver 0.9.14
 * apache 2.2.6
 * mod_python 3.3.1
 * subversion 1.4.5
 * svn-python 1.4.5
 * sqlite 3.5.2
 * pysqlite 2.3.5
 * easy_install
 
= TOW Installation =

== Installation ==
 * Unzip TOW-*.zip to C:\ (not available in other folders)
 * Run start-tow.bat
{{{
C:\TOW>start-tow.bat
}}}
 * That's it!

== Test ==
 * Go http://localhost:8080/projects/HelloTOW

= TOW Administration =
 * Default admin user is admin/towadmin

== Add New User ==
{{{
C:\TOW>add-user.bat <UserName> <Password>
}}}

== Add New Project ==
{{{
C:\TOW>create-svn-repo.bat <ProjectName>
C:\TOW>create-trac-repo.bat <ProjectName>
}}}
 
== How to run trac-admin ==
{{{
C:\TOW>trac-admin.bat <ProjectName> <Commands>
}}}
 * More details in [http://trac.edgewall.org/wiki/TracAdmin TracAdmin]
 
== How to run easy_install ==
{{{
C:\TOW>easy_install.bat <Arguments>
}}}
 * More details in [http://peak.telecommunity.com/DevCenter/EasyInstall EasyInstall]
