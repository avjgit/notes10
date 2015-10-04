# -----------------
# User Instructions
# 
# Write a function, readwordlist, that takes a filename as input and returns
# a set of all the words and a set of all the prefixes in that file, in 
# uppercase. For testing, you can assume that you have access to a file 
# called 'words4k.txt'

def prefixes(word):
    "A list of the initial sequences of a word, not including the complete word."
    return [word[:i] for i in range(len(word))]

def readwordlist(filename):
    """Read the words from a file and return a set of the words 
    and a set of the prefixes."""
    file = open(filename) # opens file
    text = file.read()    # gets file into string
    # your code here
    wordset = set(text.upper().split())
    prefixset = set(p for word in wordset for p in prefixes(word))
    return wordset, prefixset
    
WORDS, PREFIXES = readwordlist('words4k.txt')


def longest_words(hand, board_letters):
    "Return all word plays, longest first."
    ###Your code here.
    #return max(word_plays(hand, board_letters), key=len)
    return sorted(word_plays(hand, board_letters), reverse=True, key=len)

# -----------------
# User Instructions
# 
# Write a function, word_score, that takes as input a word, and
# returns the sum of the individual letter scores of that word.
# For testing, you can assume that you have access to a file called 
# 'words4k.txt'


POINTS = dict(A=1, B=3, C=3, D=2, E=1, F=4, G=2, H=4, I=1, J=8, K=5, L=1, M=3, N=1, O=1, P=3, Q=10, R=1, S=1, T=1, U=1, V=4, W=4, X=8, Y=4, Z=10, _=0)

def word_score(word):
    "The sum of the individual letter point scores for this word."
    ###Your code here.
    score = 0
    for l in word:
        score += POINTS[l]
    return score

    return sum(POINTS[L] for l in word)

def topn(hand, board_letters, n=10):
    "Return a list of the top n words that hand can play, sorted by word score."
    ###Your code here.
    words = word_plays(hand, board_letters)
    return sorted(words, reverse = True, key = word_score)[:n]

def test():
    assert len(WORDS)    == 3892
    print len(PREFIXES)
    assert len(PREFIXES) == 6475
    assert 'UMIAQS' in WORDS
    assert 'MOVING' in WORDS
    assert 'UNDERSTANDIN' in PREFIXES
    assert 'ZOMB' in PREFIXES
    return 'tests pass'

print test()