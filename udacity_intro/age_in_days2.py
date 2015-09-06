"""
Returns the year, month, day of the next day.
Simple version: assume every month has 30 days.
"""
def nextDay1(year, month, day):
    day += 1
    if day > 30:
        day = 1
        month += 1
        if month > 12:
            month = 1
            year += 1
    return (year, month, day)

def nextDay2(year, month, day):
    if day < 30:
        return (year, month, day + 1)
    else:
        if month < 12:
            return (year, month + 1, 1)
        else:
            return (year + 1, 1, 1)

# Define a daysBetweenDates procedure that would produce the
# correct output if there was a correct nextDay procedure.
#
# Note that this will NOT produce correct outputs yet, since
# our nextDay procedure assumes all months have 30 days
# (hence a year is 360 days, instead of 365).
# 

def nextDay(year, month, day):
    """Simple version: assume every month has 30 days"""
    if day < 30:
        return year, month, day + 1
    else:
        if month == 12:
            return year + 1, 1, 1
        else:
            return year, month + 1, 1
        
def daysBetweenDates(year1, month1, day1, year2, month2, day2):
    """Returns the number of days between year1/month1/day1
       and year2/month2/day2. Assumes inputs are valid dates
       in Gregorian calendar, and the first date is not after
       the second."""
        
    # YOUR CODE HERE!
    y, m, d = year1, month1, day1
    days = 0
    while not (y == year2 and m == month2 and d == day2):
        y, m, d = nextDay(y, m, d)
        days += 1
    
    return days

def test():
    test_cases = [((2012,9,30,2012,10,30),30), 
                  ((2012,1,1,2013,1,1),360),
                  ((2012,9,1,2012,9,4),3)]
    
    for (args, answer) in test_cases:
        result = daysBetweenDates(*args)
        print result
        if result != answer:
            print "Test with data:", args, "failed"
        else:
            print "Test case passed!"

test()
    
