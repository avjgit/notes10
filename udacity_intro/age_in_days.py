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

def daysBetweenMonths(y, m1, d1, m2, d2):
    days = 0
    for month in range(m1+1,m2):
        days += daysOfMonth(y,month)
    endOfStartMonth = daysOfMonth(y,m1)
    days += endOfStartMonth - d1
    days += d2
    return days

def daysBetweenDates(y1, m1, d1, y2, m2, d2):

    days = 0

    for year in range(y1,y2):
        if (isLeapYear(year) and m1 <= 2) or isLeapYear(year+1):
            days += 366
        else:
            days += 365

    if(m2 > m1):
        days += daysBetweenMonths(y2,m1,d1,m2,d2)
    elif(m2 < m1):
        days -= daysBetweenMonths(y2,m2,d2,m1,d1)
    else:
        days += d2-d1 #handles also negative difference

    return days

days = daysBetweenDates(1982, 7, 28, 2015, 9, 5); print days, days == 12092
days = daysBetweenDates(2000, 1, 1, 2000, 1, 1); print days, days == 0
days = daysBetweenDates(2000, 1, 1, 2000, 1, 2); print days, days == 1
days = daysBetweenDates(2000, 1, 1, 2000, 2, 2); print days, days == 32
days = daysBetweenDates(2000, 1, 1, 2001, 1, 1); print days, days == 366
days = daysBetweenDates(2000, 3, 1, 2001, 3, 1); print days, days == 365
days = daysBetweenDates(2000, 5, 1, 2001, 3, 1); print days, days == 304
days = daysBetweenDates(2000, 5, 15, 2001, 5, 15); print days, days == 365
days = daysBetweenDates(2000, 5, 15, 2001, 3, 2); print days, days == 291
days = daysBetweenDates(2000, 5, 15, 2010, 3, 2); print days, days == 3578
days = daysBetweenDates(2000, 1, 10, 2001, 1, 20); print days, days == 376
days = daysBetweenDates(2000, 1, 20, 2001, 1, 10); print days, days == 356

