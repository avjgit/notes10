import urllib

def read_text():
	quotes = open("movie_quotes.txt")
	content = quotes.read()
	print(content)
	quotes.close()
	check_profanity(content)

def check_profanity(text_to_check):
	connection = urllib.urlopen("http://www.wdyl.com/profanity?q=" + text_to_check)
	output = connection.read()
	print(output)
	connection.close()

	if "true" in output:
		print("There are curse words there!")
	elif "false" in output:
		print("File content is safe")
	else:
		print("Could not process document")

		
read_text()