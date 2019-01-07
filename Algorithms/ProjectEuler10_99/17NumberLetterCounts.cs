using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Algorithms.ProjectEuler10_99
{
    public static class _17NumberLetterCounts
    {
        private static Dictionary<int, string> numberNames = new Dictionary<int, string>
            {
                {0, string.Empty},
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
                {20, "Twenty"},
                {30, "Thirty"},
                {40, "Forty"},
                {50, "Fifty"},
                {60, "Sixty"},
                {70, "Seventy"},
                {80, "Eighty"},
                {90, "Ninety"},
                {100, "Hundred"},
                {1000, "Thousand"},
            };

        // If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        // If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        // NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
        public static int Execute()
        {
            const int minValue = 1;
            const int maxValue = 1000;

            var count = 0;
            for (var i = minValue; i <= maxValue; i++)
            {
                var digits = i.ToString();
                var valueName = "";
                var place = 0;

                if (digits.Length >= 4)
                {
                    var thousand = int.Parse(digits[place].ToString());
                    valueName += " " + numberNames[thousand] + " " + numberNames[1000];
                    if (i % 1000 != 0) valueName += " and ";
                    place++;
                }
                if (digits.Length >= 3)
                {
                    var hundred = int.Parse(digits[place].ToString());
                    if (hundred != 0)
                    {
                        valueName += " " + numberNames[hundred] + " " + numberNames[100];
                        if (i % 100 != 0) valueName += " and";
                    }
                    place++;
                }
                if (digits.Length >= 2)
                {
                    var stringValue = new string(new[] { digits[place], digits[place + 1] });
                    var value = int.Parse(stringValue);

                    if (value <= 20 && value != 0)
                        valueName += " " + numberNames[value];
                    else if (value != 0)
                    {
                        var ten = int.Parse(digits[place].ToString()) * 10;
                        var one = int.Parse(digits[place + 1].ToString());
                        valueName += " " + numberNames[ten] + " " + numberNames[one];
                    }
                }
                else if (digits.Length == 1)
                {
                    valueName += " " + numberNames[int.Parse(digits[0].ToString())];
                }

                Console.WriteLine(digits + ":" + valueName.Substring(1));
                count += valueName.Replace(" ", string.Empty).Length;
            }

            return count;
        }
    }
}