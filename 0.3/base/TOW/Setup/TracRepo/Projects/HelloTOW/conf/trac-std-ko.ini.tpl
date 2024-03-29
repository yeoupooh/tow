# -*- coding: utf-8 -*-

[account-manager]
password_file = c:\TOW\SvnRepo\Projects\trac.htpasswd
password_store = HtPasswdStore

[attachment]
max_size = 262144
render_unsafe_content = false

[browser]
color_scale = True
downloadable_paths = /trunk, /branches/*, /tags/*
hide_properties = svk:merge
intermediate_color = 
intermediate_point = 
newest_color = (255, 136, 136)
oldest_color = (136, 136, 255)
oneliner_properties = trac:summary
render_unsafe_content = false
wiki_properties = trac:description

[changeset]
max_diff_bytes = 10000000
max_diff_files = 0
wiki_format_messages = true

[components]
acct_mgr.admin.accountmanageradminpage = enabled
acct_mgr.api.accountmanager = enabled
acct_mgr.db.sessionstore = disabled
acct_mgr.htfile.abstractpasswordfilestore = disabled
acct_mgr.htfile.htdigeststore = disabled
acct_mgr.htfile.htpasswdstore = enabled
acct_mgr.http.httpauthstore = enabled
acct_mgr.pwhash.htdigesthashmethod = disabled
acct_mgr.pwhash.htpasswdhashmethod = disabled
acct_mgr.web_ui.accountmodule = enabled
acct_mgr.web_ui.loginmodule = disabled
acct_mgr.web_ui.registrationmodule = enabled
iniadmin.iniadmin.iniadminplugin = enabled
trac.web.auth.loginmodule = enabled
tracnav.* = enabled
tracrpc.* = enabled
tracrpcext.* = enabled
tractoc.* = enabled
tracwysiwyg.* = enabled
webadmin.* = enabled

[header_logo]
alt = %PROJECT_NAME%
height = -1
link = http://traconwindows.wordpress.com/
src = site/tow-logo.png
width = -1

[inherit]
plugins_dir = 
templates_dir = 

[logging]
log_file = trac.log
log_level = DEBUG
log_type = none

[milestone]
stats_provider = DefaultTicketGroupStatsProvider

[mimeviewer]
enscript_modes = text/x-dylan:dylan:4
enscript_path = enscript
max_preview_size = 262144
mime_map = text/x-dylan:dylan,text/x-idl:ice,text/x-ada:ads:adb
php_path = php
tab_width = 8

[notification]
admit_domains = 
always_notify_owner = false
always_notify_reporter = false
always_notify_updater = true
ignore_domains = 
mime_encoding = base64
smtp_always_bcc = 
smtp_always_cc = 
smtp_default_domain = 
smtp_enabled = false
smtp_from = trac@localhost
smtp_from_name = 
smtp_password = 
smtp_port = 25
smtp_replyto = trac@localhost
smtp_server = localhost
smtp_subject_prefix = __default__
smtp_user = 
ticket_subject_template = $prefix #$ticket.id: $summary
use_public_cc = false
use_short_addr = false
use_tls = false

[project]
admin = admin
descr = %PROJECT_NAME% project
footer = Visit the Trac open source project at<br /><a href="http://trac.edgewall.org/">http://trac.edgewall.org/</a>
icon = common/trac.ico
name = %PROJECT_NAME%
url = http://traconwindows.wordpress.com/
[query]
default_anonymous_query = status!=closed&cc~=$USER
default_query = status!=closed&owner=$USER
items_per_page = 100

[report]
items_per_page = 100
items_per_page_rss = 0

[revisionlog]
default_log_limit = 100

[roadmap]
stats_provider = DefaultTicketGroupStatsProvider

[search]
min_query_length = 3

[svn]
branches = trunk,branches/*
tags = tags/*

[ticket]
default_component = 
default_milestone = 
default_priority = major
default_resolution = fixed
default_type = defect
default_version = 
max_description_size = 262144
preserve_newlines = default
restrict_owner = false
workflow = ConfigurableTicketWorkflow

[ticket-workflow]
accept = new,assigned,accepted,reopened -> accepted
accept.operations = set_owner_to_self
accept.permissions = TICKET_MODIFY
leave = * -> *
leave.default = 1
leave.operations = leave_status
reassign = new,assigned,accepted,reopened -> assigned
reassign.operations = set_owner
reassign.permissions = TICKET_MODIFY
reopen = closed -> reopened
reopen.operations = del_resolution
reopen.permissions = TICKET_CREATE
resolve = new,assigned,accepted,reopened -> closed
resolve.operations = set_resolution
resolve.permissions = TICKET_MODIFY

[timeline]
abbreviated_messages = true
changeset_collapse_events = false
changeset_long_messages = false
changeset_show_files = 0
default_daysback = 30
max_daysback = 90
newticket_formatter = oneliner
ticket_show_details = false

[trac]
authz_file = 
authz_module_name = 
auto_reload = False
base_url = 
check_auth_ip = true
database = sqlite:db/trac.db
default_charset = euc-kr
htdocs_location = 
ignore_auth_case = false
mainnav = wiki,timeline,roadmap,browser,tickets,newticket,search
metanav = login,logout,prefs,help,about
permission_policies = DefaultPermissionPolicy, LegacyAttachmentPolicy
permission_store = DefaultPermissionStore
repository_dir = C:\\TOW\\SvnRepo\\Projects\\%PROJECT_NAME%
repository_type = svn
show_email_addresses = false
timeout = 20
use_base_url_for_redirect = False

[wiki]
ignore_missing_pages = false
render_unsafe_content = false
split_page_names = false

