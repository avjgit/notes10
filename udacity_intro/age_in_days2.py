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

def nextDay(year, month, day):
    if day < 30:
        return (year, month, day + 1)
    else:
        if month < 12:
            return (year, month + 1, 1)
        else:
            return (year + 1, 1, 1)