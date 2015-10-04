import urllib2
p = urllib2.open("http://www.google.com")
c = p.read()
dir(p)
p.url
p.headers
p.headers.items()
p.headers['content-type']