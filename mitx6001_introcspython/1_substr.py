# Counting Bobs (15 points possible)
# Assume s is a string of lower case characters.
# Write a program that prints the number of times the string 'bob' occurs in s. 
# For example, if s = 'azcbobobegghakl', then your program should print
# Number of times bob occurs is: 2
s = 'azcbobobegghakl'
subs = 'bob'
count = 0
idx = -1
while True:
	idx = s.find(subs, idx+1);
	if (idx < 0):
		break;
	count += 1

print "Number of times bob occurs is: " + str(count)
