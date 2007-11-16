"""
If no parameters are listed, gets list of all tags used.
If parameters are listed, find elements the match the specified parameter list.
Parameter list syntax example: "tag,tag2,tag3"
Also, "." used in place of a tag is equivelant to specifying the current wiki.
"""

import re
import string
from StringIO import StringIO

def execute(hdf, args, env):
    db = env.get_db_cnx()
    cursor = db.cursor()
    cs = db.cursor()

    if args:
        return wParameters(hdf,args,env,db,cursor)
    else:
        db = env.get_db_cnx()
        cursor = db.cursor()

        buf = StringIO()
        buf.write('SELECT namespace, COUNT(*) FROM wiki_namespace ')

        cursor.execute(buf.getvalue() + ' GROUP BY namespace ORDER BY namespace')
        msg = StringIO()
        msg.write('<ul>')
        while 1:
          row = cursor.fetchone()
          if row == None:
             break

          tag = row[0]
          refcount = int(row[1])

          (linktext,title,desc) = getInfo(db,tag)

          link = env.href.wiki(tag)

          msg.write('<li><a title="%s" href="%s">' % (title,link))
          msg.write(linktext)
          msg.write('</a> %s (%s)</li>\n' % (desc,refcount))

        msg.write('</ul>')

        return msg.getvalue()

def wParameters(hdf,args,env,db,cursor):
    categories = args.split(',')

    buf = StringIO()
    criteria = StringIO()

    me = hdf.getValue('wiki.page_name', '')

    heirarchy = me.split('/')
    prog = re.compile('^\.([-]\d+)$')

    for current in categories:
    	if current == "." :
    	    current = me
    	else :
            m = prog.search(current)
            if m :
                current = heirarchy[int(m.group(1))]
    	buf.write('SELECT DISTINCT name FROM wiki_namespace where')
    	buf.write(' namespace like \'%s\' INTERSECT ' % current)

    cursor.execute(buf.getvalue()[0:-11] + ' ORDER BY name')

    msg = StringIO()
    msg.write('<ul>')

    while 1:
        row = cursor.fetchone()
        if row == None:
            break
        tag = row[0]
        (linktext,title,desc) = getInfo(db,tag)

        link = env.href.wiki(tag)

        msg.write('<li><a title="%s" href="%s">' % (title,link))
        msg.write(linktext)
        msg.write('</a> %s</li>\n' % desc)
    msg.write('</ul>')

    return msg.getvalue()

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

