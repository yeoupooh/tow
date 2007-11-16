"""
Updates list of tag the current entry is in.

Downshot: updates database every time.
"""

from StringIO import StringIO
import re
import string

def execute(hdf, args, env):
    db = env.get_db_cnx()
    cursor = db.cursor()
    categories = args.split(',')

    current = hdf.getValue('wiki.page_name', '')

    sql = 'DELETE FROM wiki_namespace where name = \'%s\' ' % current
    cursor.execute(sql)

    buf = StringIO()

    for category in categories:
	if (category != ""):
           sql = 'INSERT INTO wiki_namespace(name,namespace) values(\'%s\',\'%s\')' % (current,category)
           cursor.execute(sql)

    db.commit()

    buf.write('SELECT namespace FROM wiki_namespace WHERE wiki_namespace.name=\'%s\' ORDER by namespace' % current)

    cursor.execute(buf.getvalue())

    msg = StringIO()
    msg.write("Tags:")

    count = 0;

    while 1:
        row = cursor.fetchone()
        if row == None:
            break

        tag = row[0]
        (linktext,title,desc) = getInfo(db,tag)

        link = env.href.wiki(tag)

        count = count + 1
        msg.write('<a title="%s" href="%s">' % (title, link))
        msg.write(linktext)
        msg.write('</a> \n')

    if (count > 0):
        return (msg.getvalue()[0:-2] + ('.'))
    else:
	return ""

def getInfo(db,tag):
    cs = db.cursor()
    desc = tag
    # Get the latest revision only.
    cs.execute('SELECT text from wiki where name = \'%s\' order by version desc limit 1' % tag)
    csrow = cs.fetchone()
    prefix = ''

    if csrow != None:
        text = csrow[0]
        m  = re.search('=+\s([^=]*)=+',text)
        if m != None:
            desc = string.strip(m.group(1))
    else:
        prefix = "Create "

    title = StringIO()
    title.write("%s%s"%(prefix, desc))
    if prefix != '' or desc == tag:
       desc = ''

    return (tag,title.getvalue(),desc)
