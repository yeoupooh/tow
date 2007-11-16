# Post installation script for the Windows installer
# This script is needed to create the trac/siteconfig.py file containing various
# global default directories

import os.path
import sys
from distutils import sysconfig
import trac

def install():
    print 'Setting up default directories...'
    site_packages = os.path.join(sysconfig.get_config_var('BINLIBDEST'),
                                 'site-packages')
    prefix = sysconfig.get_config_var('prefix')

    conf_dir = os.path.join(prefix, 'share', 'trac', 'conf')
    templates_dir = os.path.join(prefix, 'share', 'trac', 'templates')
    htdocs_dir = os.path.join(prefix, 'share', 'trac', 'htdocs')
    plugins_dir = os.path.join(prefix, 'share', 'trac', 'plugins')
    wiki_dir = os.path.join(prefix, 'share', 'trac', 'wiki-default')
    macros_dir = os.path.join(prefix, 'share', 'trac', 'wiki-macros')

    siteconfig = os.path.join(site_packages, 'trac', 'siteconfig.py')
    fd = open(siteconfig, 'w')
    fd.write("""
# PLEASE DO NOT EDIT THIS FILE!
# This file was autogenerated when installing Trac %(version)s.
#
__default_conf_dir__ = %(conf)r
__default_templates_dir__ = %(templates)r
__default_htdocs_dir__ = %(htdocs)r
__default_wiki_dir__ = %(wiki)r
__default_macros_dir__ = %(macros)r
__default_plugins_dir__ = %(plugins)r

""" % {'version': trac.__version__, 'conf': conf_dir,
       'templates': templates_dir, 'htdocs': htdocs_dir, 'wiki': wiki_dir,
       'macros': macros_dir, 'plugins': plugins_dir})
    fd.close()

    file_created(siteconfig)
    print 'Done.'

def remove():
    pass


if __name__ == '__main__':
    mode = sys.argv[1]
    if mode == '-install':
        install()
    elif mode == '-remove':
        remove()