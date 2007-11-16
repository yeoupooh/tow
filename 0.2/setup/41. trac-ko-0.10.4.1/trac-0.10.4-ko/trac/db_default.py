# -*- coding: utf-8 -*-
#
# Copyright (C) 2003-2006 Edgewall Software
# Copyright (C) 2003-2005 Daniel Lundin <daniel@edgewall.com>
# All rights reserved.
#
# This software is licensed as described in the file COPYING, which
# you should have received as part of this distribution. The terms
# are also available at http://trac.edgewall.org/wiki/TracLicense.
#
# This software consists of voluntary contributions made by many
# individuals. For the exact contribution history, see the revision
# history and logs, available at http://trac.edgewall.org/log/.
#
# Author: Daniel Lundin <daniel@edgewall.com>

from trac.db import Table, Column, Index

# Database version identifier. Used for automatic upgrades.
db_version = 20

def __mkreports(reports):
    """Utility function used to create report data in same syntax as the
    default data. This extra step is done to simplify editing the default
    reports."""
    result = []
    for report in reports:
        result.append((None, report[0], report[2], report[1]))
    return result


##
## Database schema
##

schema = [
    # Common
    Table('system', key='name')[
        Column('name'),
        Column('value')],
    Table('permission', key=('username', 'action'))[
        Column('username'),
        Column('action')],
    Table('auth_cookie', key=('cookie', 'ipnr', 'name'))[
        Column('cookie'),
        Column('name'),
        Column('ipnr'),
        Column('time', type='int')],
    Table('session', key=('sid', 'authenticated'))[
        Column('sid'),
        Column('authenticated', type='int'),
        Column('last_visit', type='int'),
        Index(['last_visit']),
        Index(['authenticated'])],
    Table('session_attribute', key=('sid', 'authenticated', 'name'))[
        Column('sid'),
        Column('authenticated', type='int'),
        Column('name'),
        Column('value')],

    # Attachments
    Table('attachment', key=('type', 'id', 'filename'))[
        Column('type'),
        Column('id'),
        Column('filename'),
        Column('size', type='int'),
        Column('time', type='int'),
        Column('description'),
        Column('author'),
        Column('ipnr')],

    # Wiki system
    Table('wiki', key=('name', 'version'))[
        Column('name'),
        Column('version', type='int'),
        Column('time', type='int'),
        Column('author'),
        Column('ipnr'),
        Column('text'),
        Column('comment'),
        Column('readonly', type='int'),
        Index(['time'])],

    # Version control cache
    Table('revision', key='rev')[
        Column('rev'),
        Column('time', type='int'),
        Column('author'),
        Column('message'),
        Index(['time'])],
    Table('node_change', key=('rev', 'path', 'change_type'))[
        Column('rev'),
        Column('path'),
        Column('node_type', size=1),
        Column('change_type', size=1),
        Column('base_path'),
        Column('base_rev'),
        Index(['rev'])],

    # Ticket system
    Table('ticket', key='id')[
        Column('id', auto_increment=True),
        Column('type'),
        Column('time', type='int'),
        Column('changetime', type='int'),
        Column('component'),
        Column('severity'),
        Column('priority'),
        Column('owner'),
        Column('reporter'),
        Column('cc'),
        Column('version'),
        Column('milestone'),
        Column('status'),
        Column('resolution'),
        Column('summary'),
        Column('description'),
        Column('keywords'),
        Index(['time']),
        Index(['status'])],    
    Table('ticket_change', key=('ticket', 'time', 'field'))[
        Column('ticket', type='int'),
        Column('time', type='int'),
        Column('author'),
        Column('field'),
        Column('oldvalue'),
        Column('newvalue'),
        Index(['ticket']),
        Index(['time'])],
    Table('ticket_custom', key=('ticket', 'name'))[
        Column('ticket', type='int'),
        Column('name'),
        Column('value')],
    Table('enum', key=('type', 'name'))[
        Column('type'),
        Column('name'),
        Column('value')],
    Table('component', key='name')[
        Column('name'),
        Column('owner'),
        Column('description')],
    Table('milestone', key='name')[
        Column('name'),
        Column('due', type='int'),
        Column('completed', type='int'),
        Column('description')],
    Table('version', key='name')[
        Column('name'),
        Column('time', type='int'),
        Column('description')],

    # Report system
    Table('report', key='id')[
        Column('id', auto_increment=True),
        Column('author'),
        Column('title'),
        Column('query'),
        Column('description')],
]


##
## Default Reports
##

def get_reports(db):
    owner = db.concat('owner', "' *'")
    return (
(u'활성화된 티켓들',
u"""
 * 우선 순위별로 정렬된 모든 활성화된 티켓들.
 * 각 행의 색깔은 우선순위를 의미합니다.
 * 만약 티켓이 수락되었다면, 소유주 이름 뒤에 '*'가 추가됩니다.
""",
"""
SELECT p.value AS __color__,
   id AS ticket, summary, component, version, milestone, t.type AS type, 
   (CASE status WHEN 'assigned' THEN %s ELSE owner END) AS owner,
   time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status IN ('new', 'assigned', 'reopened') 
  ORDER BY p.value, milestone, t.type, time
""" % owner),
#----------------------------------------------------------------------------
 (u'버전에 따른 활성화된 티켓들',
u"""
이 리포트는 버전에 따라 그룹화된 결과에 대해서 우선순위에 따라 어떻게 색깔을 지정하는지를 보여줍니다.

유용한 RSS 결과물을 위해서 마지막 수정시간, 상세설명 그리고 작성자 필드는 숨겨진 필드로 포함되게 됩니다.
""",
"""
SELECT p.value AS __color__,
   version AS __group__,
   id AS ticket, summary, component, version, t.type AS type, 
   (CASE status WHEN 'assigned' THEN %s ELSE owner END) AS owner,
   time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status IN ('new', 'assigned', 'reopened') 
  ORDER BY (version IS NULL),version, p.value, t.type, time
""" % owner),
#----------------------------------------------------------------------------
(u'마일스톤에 따른 활성화된 티켓들',
u"""
이 리포트는 마일스톤에 따라 그룹화된 결과에 대해서 우선순위에 따라 어떻게 색깔을 지정하는지를 보여줍니다.

유용한 RSS 결과물을 위해서 마지막 수정시간, 상세설명 그리고 작성자 필드는 숨겨진 필드로 포함되게 됩니다.
""",
"""
SELECT p.value AS __color__,
   %s AS __group__,
   id AS ticket, summary, component, version, t.type AS type, 
   (CASE status WHEN 'assigned' THEN %s ELSE owner END) AS owner,
   time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status IN ('new', 'assigned', 'reopened') 
  ORDER BY (milestone IS NULL),milestone, p.value, t.type, time
""" % (db.concat('milestone', "' Release'"), owner)),
#----------------------------------------------------------------------------
(u'활성화된 티켓중 소유자별로 할당된 티켓들',
u"""
할당된 티켓들을 소유자별로 그룹화하고, 우선순위별로 정렬해서 보여줍니다.
""",
"""

SELECT p.value AS __color__,
   owner AS __group__,
   id AS ticket, summary, component, milestone, t.type AS type, time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status = 'assigned'
  ORDER BY owner, p.value, t.type, time
"""),
#----------------------------------------------------------------------------
(u'활성화된 티켓중 소유자별로 할당된 티켓들 (상세 설명 포함)',
u"""
할당된 티켓들을 소유자별로 그룹화하여 보여줍니다.
이 리포트는 전체 행 표시를 어떻게 사용하는지를 보여줍니다.
""",
"""
SELECT p.value AS __color__,
   owner AS __group__,
   id AS ticket, summary, component, milestone, t.type AS type, time AS created,
   description AS _description_,
   changetime AS _changetime, reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status = 'assigned'
  ORDER BY owner, p.value, t.type, time
"""),
#----------------------------------------------------------------------------
(u'마일스톤에 따른 모든 티켓들 (닫혀진 것을 포함해서)',
u"""
좀 더 진보된 리포트를 어떻게 만드는지를 보여주는 더 복잡한 예제입니다.
""",
"""
SELECT p.value AS __color__,
   t.milestone AS __group__,
   (CASE status 
      WHEN 'closed' THEN 'color: #777; background: #ddd; border-color: #ccc;'
      ELSE 
        (CASE owner WHEN $USER THEN 'font-weight: bold' END)
    END) AS __style__,
   id AS ticket, summary, component, status, 
   resolution,version, t.type AS type, priority, owner,
   changetime AS modified,
   time AS _time,reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  ORDER BY (milestone IS NULL), milestone DESC, (status = 'closed'), 
        (CASE status WHEN 'closed' THEN modified ELSE (-1)*p.value END) DESC
"""),
#----------------------------------------------------------------------------
(u'나에게 할당된 티켓들',
u"""
이 리포트는 실행될 때 로그온한 사용자이름으로 자동으로 변경되는, USER 동적 변수의 사용 방법을 보여줍니다.
""",
"""
SELECT p.value AS __color__,
   (CASE status WHEN 'assigned' THEN 'Assigned' ELSE 'Owned' END) AS __group__,
   id AS ticket, summary, component, version, milestone,
   t.type AS type, priority, time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE t.status IN ('new', 'assigned', 'reopened') AND owner = $USER
  ORDER BY (status = 'assigned') DESC, p.value, milestone, t.type, time
"""),
#----------------------------------------------------------------------------
(u'활성화된 티켓, 나에게 할당된 티켓들을 먼저 보여줍니다',
u"""
 * 우선순위별로 활성화된 모든 티켓들을 보여줍니다.
 * 로그인한 사용자가 소유한 티켓들을 먼저 보여줍니다.
""",
u"""
SELECT p.value AS __color__,
   (CASE owner 
     WHEN $USER THEN '내 티켓들' 
     ELSE '활성화된 티켓들' 
    END) AS __group__,
   id AS ticket, summary, component, version, milestone, t.type AS type, 
   (CASE status WHEN 'assigned' THEN %s ELSE owner END) AS owner,
   time AS created,
   changetime AS _changetime, description AS _description,
   reporter AS _reporter
  FROM ticket t
  LEFT JOIN enum p ON p.name = t.priority AND p.type = 'priority'
  WHERE status IN ('new', 'assigned', 'reopened') 
  ORDER BY (owner = $USER) DESC, p.value, milestone, t.type, time
""" % owner))


##
## Default database values
##

# (table, (column1, column2), ((row1col1, row1col2), (row2col1, row2col2)))
def get_data(db):
   return (('component',
             ('name', 'owner'),
               ((u'콤포넌트1', 'somebody'),
                (u'콤포넌트2', 'somebody'))),
           ('milestone',
             ('name', 'due', 'completed'),
               ((u'마일스톤1', 0, 0),
                (u'마일스톤2', 0, 0),
                (u'마일스톤3', 0, 0),
                (u'마일스톤4', 0, 0))),
           ('version',
             ('name', 'time'),
               (('1.0', 0),
                ('2.0', 0))),
           ('enum',
             ('type', 'name', 'value'),
               (('status', 'new', 1),
                ('status', 'assigned', 2),
                ('status', 'reopened', 3),
                ('status', 'closed', 4),
                ('resolution', u'문제가 고쳐짐', 1),
                ('resolution', u'유효하지 않음', 2),
                ('resolution', u'고칠 필요 없음', 3),
                ('resolution', u'다른 티켓과 중복됨', 4),
                ('resolution', u'여기서는 발생하지 않음', 5),
                ('priority', u'매우 심각한', 1),
                ('priority', u'심각한', 2),
                ('priority', u'보통', 3),
                ('priority', u'사소한', 4),
                ('priority', u'매우 사소한', 5),
                ('ticket_type', u'문제점', 1),
                ('ticket_type', u'개선사항', 2),
                ('ticket_type', u'해야할 일', 3))),
           ('permission',
             ('username', 'action'),
               (('anonymous', 'LOG_VIEW'),
                ('anonymous', 'FILE_VIEW'),
                ('anonymous', 'WIKI_VIEW'),
                ('anonymous', 'WIKI_CREATE'),
                ('anonymous', 'WIKI_MODIFY'),
                ('anonymous', 'SEARCH_VIEW'),
                ('anonymous', 'REPORT_VIEW'),
                ('anonymous', 'REPORT_SQL_VIEW'),
                ('anonymous', 'TICKET_VIEW'),
                ('anonymous', 'TICKET_CREATE'),
                ('anonymous', 'TICKET_MODIFY'),
                ('anonymous', 'BROWSER_VIEW'),
                ('anonymous', 'TIMELINE_VIEW'),
                ('anonymous', 'CHANGESET_VIEW'),
                ('anonymous', 'ROADMAP_VIEW'),
                ('anonymous', 'MILESTONE_VIEW'))),
           ('system',
             ('name', 'value'),
               (('database_version', str(db_version)),
                ('youngest_rev', ''))),
           ('report',
             ('author', 'title', 'query', 'description'),
               __mkreports(get_reports(db))))


default_components = ('trac.About', 'trac.attachment',
                      'trac.db.mysql_backend', 'trac.db.postgres_backend',
                      'trac.db.sqlite_backend',
                      'trac.mimeview.enscript', 'trac.mimeview.patch',
                      'trac.mimeview.php', 'trac.mimeview.rst',
                      'trac.mimeview.silvercity', 'trac.mimeview.txtl',
                      'trac.scripts.admin',
                      'trac.Search', 'trac.Settings',
                      'trac.ticket.query', 'trac.ticket.report',
                      'trac.ticket.roadmap', 'trac.ticket.web_ui',
                      'trac.Timeline',
                      'trac.versioncontrol.web_ui',
                      'trac.versioncontrol.svn_fs',
                      'trac.wiki.macros', 'trac.wiki.web_ui',
                      'trac.web.auth')
