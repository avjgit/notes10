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
# Credit goes to Websten from forums
#
# Use Dave's suggestions to finish your daysBetweenDates
# procedure. It will need to take into account leap years
# in addition to the correct number of days in each month.

daysOfMonths = [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]

def isLeapYear(year):
    if (year % 4 > 0):
        return False
    if (year % 100 > 0):
        return True
    return not (year % 400 > 0)

# # # # print isLeapYear(2008)
# # # # print isLeapYear(2012)
# # # # print isLeapYear(2016)
# # # # print isLeapYear(2020)
# # # # print isLeapYear(2024)
# # # # print isLeapYear(2028)
# # # # print isLeapYear(2032)
def isLeapYearFebruary(y, m):
    return isLeapYear(y) and m == 2

def daysOfMonth(y,m):
    return 29 if isLeapYearFebruary(y,m) else daysOfMonths[m-1]

def nextDay(year, month, day):
    if day < daysOfMonth(year,month):
        return year, month, day + 1
    else:
        if month == 12:
            return year + 1, 1, 1
        else:
            return year, month + 1, 1
        
def dateIsBefore(year1, month1, day1, year2, month2, day2):
    """Returns True if year1-month1-day1 is before year2-month2-day2. Otherwise, returns False."""
    if year1 < year2:
        return True
    if year1 == year2:
        if month1 < month2:
            return True
        if month1 == month2:
            return day1 < day2
    return False        

def daysBetweenDates(year1, month1, day1, year2, month2, day2):
    """Returns the number of days between year1/month1/day1
       and year2/month2/day2. Assumes inputs are valid dates
       in Gregorian calendar."""
    # program defensively! Add an assertion if the input is not valid!
    assert not dateIsBefore(year2, month2, day2, year1, month1, day1)
    days = 0
    while dateIsBefore(year1, month1, day1, year2, month2, day2):
        year1, month1, day1 = nextDay(year1, month1, day1)
        days += 1
    return days

def test():
    test_cases = [((2012,1,1,2012,2,28), 58), 
                  ((2012,1,1,2012,3,1), 60),
                  ((2011,6,30,2012,6,30), 366),
                  ((2011,1,1,2012,8,8), 585 ),
                  ((1900,1,1,1999,12,31), 36523)]
    
    for (args, answer) in test_cases:
        result = daysBetweenDates(*args)
        if result != answer:
            print "Test with data:", args, "failed"
        else:
            print "Test case passed!"

test()