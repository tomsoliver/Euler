using System;

namespace Algorithms.ProjectEuler10_99
{
    public static class _19CountingSundays
    {
        //You are given the following information, but you may prefer to do some research for yourself.

        //1 Jan 1900 was a Monday.
        //Thirty days has September,
        //April, June and November.
        //All the rest have thirty-one,
        //Saving February alone,
        //Which has twenty-eight, rain or shine.
        //And on leap years, twenty-nine.
        //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
        //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        public static int Execute()
        {
            var date = new DateTime(1901, 01, 01);
            var endDate = new DateTime(2000, 12, 31);
            var numberOfSundaysOnTheFirstOFTheMonth = 0;

            while (date <= endDate)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday && date.Day == 1)
                    numberOfSundaysOnTheFirstOFTheMonth++;
                date = date.AddDays(1);
            }

            return numberOfSundaysOnTheFirstOFTheMonth;
        }

        public static int FirstRun()
        {

            const int endDay = 31, endMonth = 12, endYear = 2000;
            int day = 1, month = 1, year = 1900, numberOfSundaysOnTheFirstOFTheMonth = 0;
            var dayOfWeek = DayOfWeek.Monday;

            while (year < endYear || month < endMonth || day < endDay)
            {
                if (day == 1 && dayOfWeek == DayOfWeek.Sunday && year >= 1901)
                    numberOfSundaysOnTheFirstOFTheMonth++;

                // Increment day
                if (dayOfWeek == DayOfWeek.Saturday)
                    dayOfWeek = DayOfWeek.Sunday;
                else
                    dayOfWeek++;

                // Check if febuary and the 28th, and check for leap years
                if (month == 2 && day >= 28)
                {
                    // Check if leap year, but not on a centuray unless it is divisible by 400
                    if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                    {
                        // Check if the 29th
                        if (day == 29)
                        {
                            month++;
                            day = 1;
                            continue;
                        }
                    }
                    else
                    {
                        month++;
                        day = 1;
                        continue;
                    }
                }
                // Check if april, june september, or november
                else if (day == 30 && (month == 4 || month == 6 || month == 9 || month == 11))
                {
                    month++;
                    day = 1;
                    continue;
                }
                // Check if december, start new year, 
                else if (day == 31 && month == 12)
                {
                    year++;
                    month = 1;
                    day = 1;
                    continue;
                }
                // Check for other months if day is 31
                else if (day == 31)
                {
                    month++;
                    day = 1;
                    continue;
                }

                day++;
            }

            return numberOfSundaysOnTheFirstOFTheMonth;
        }
    }
}
