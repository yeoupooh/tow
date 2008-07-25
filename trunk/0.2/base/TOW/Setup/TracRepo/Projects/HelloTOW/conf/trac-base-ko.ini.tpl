# -*- coding: utf-8 -*-

[attachment]
max_size = 262144
render_unsafe_content = false

[browser]
downloadable_paths = /trunk, /branches/*, /tags/*
hide_properties = svk:merge
render_unsafe_content = false

[changeset]
max_diff_bytes = 10000000
max_diff_files = 0
wiki_format_messages = true

[header_logo]
alt = %PROJECT_NAME%
height = -1
link = http://traconwindows.wordpress.com/
src = common/trac_banner.png
width = -1

[logging]
log_level = DEBUG
log_type = eventlog

[mimeviewer]
enscript_modes = text/x-dylan:dylan:4
enscript_path = enscript
max_preview_size = 262144
mime_map = text/x-dylan:dylan,text/x-idl:ice,text/x-ada:ads:adb
php_path = php
silvercity_modes = 
tab_width = 8

[notification]
always_notify_owner = false
always_notify_reporter = false
always_notify_updater = true
mime_encoding = base64
smtp_always_bcc = 
smtp_always_cc = 
smtp_default_domain = 
smtp_enabled = false
smtp_from = trac@localhost
smtp_password = 
smtp_port = 25
smtp_replyto = trac@localhost
smtp_server = localhost
smtp_subject_prefix = __default__
smtp_user = 
use_public_cc = false
use_short_addr = false
use_tls = false

[project]
descr = %PROJECT_NAME% project
footer = Visit the Trac open source project at<br /><a href="http://trac.edgewall.org/">http://trac.edgewall.org/</a>
icon = common/trac.ico
name = %PROJECT_NAME%
url = http://traconwindows.wordpress.com/

[search]
min_query_length = 3

[ticket]
default_component = 
default_milestone = 
default_priority = major
default_type = defect
default_version = 
restrict_owner = false

[timeline]
changeset_long_messages = false
changeset_show_files = 0
default_daysback = 30
ticket_show_details = false

[trac]
authz_file = 
authz_module_name = 
base_url = 
check_auth_ip = true
database = sqlite:db/trac.db
default_charset = euc-kr
default_handler = WikiModule
htdocs_location = 
ignore_auth_case = false
mainnav = wiki,timeline,roadmap,browser,tickets,newticket,search
metanav = login,logout,settings,help,about
permission_store = DefaultPermissionStore
repository_dir = C:\\TOW\\SvnRepo\\Projects\\%PROJECT_NAME%
repository_type = svn
templates_dir = C:\\TOW\\Python\\share\\trac\\templates
timeout = 20

[wiki]
ignore_missing_pages = false
render_unsafe_content = false
split_page_names = false

