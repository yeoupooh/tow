#!/usr/bin/python
# -*- coding: euc-kr -*-

import sys
import os

#print len(sys.argv)
#print sys.argv

if len(sys.argv) < 4:
	print "Usage:", sys.argv[0], "<ProjectName> <SourceFile> <DestinationFile>"
	sys.exit(1)

project_name = sys.argv[1]
src_file = sys.argv[2]
dest_file = sys.argv[3]

#print project_name
#print src_file
#print dest_file

#tow_home = os.environ['TOW_HOME']
#print tow_home

f = open(src_file, "rt")
f2 = open(dest_file, "wt")

while f:
	line = f.readline()
	rep_line = line.replace("%PROJECT_NAME%", project_name)
	if len(line) == 0:
		break
	f2.write(rep_line)
	
f.close()
f2.close()

print "replaced and copied."
