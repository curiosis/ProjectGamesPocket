using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGamesPocket.Assets.Scripts
{
    class Pesel
    {
        public static bool CheckPESELLength(string PESELNumber)
        {
            if (PESELNumber.Length != 11)
            {
                return false;
            }

            return true;
        }

        public static bool CheckIfPESELContainsDigitsOnly(string PESELNumber)
        {
            foreach (var c in PESELNumber.Select(d => !Char.IsDigit(d)))
            {
                if (c)
                {
                    return false;
                }
            }

            return true;
        }

        public static int ComputePESELYear(int PESEL2DigitsYear, int PESELMonth)
        {
            if (PESELMonth > 0 && PESELMonth < 13)
            {
                return 1900 + PESEL2DigitsYear;
            }

            if (PESELMonth > 20 && PESELMonth < 33)
            {
                return 2000 + PESEL2DigitsYear;
            }

            if (PESELMonth > 40 && PESELMonth < 53)
            {
                return 2100 + PESEL2DigitsYear;
            }

            if (PESELMonth > 60 && PESELMonth < 73)
            {
                return 2200 + PESEL2DigitsYear;
            }

            return 1800 + PESEL2DigitsYear;
        }

        public static bool CheckIfMonthIsCorrect(int PESELMonth)
        {
            if (PESELMonth % 20 == 0)
            {
                return false;
            }

            for (int i = 0; i <= 80; i += 20)
            {
                for (int j = 13 + i; j <= 19 + i; j++)
                {
                    if (PESELMonth == j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool CheckIfDayIsCorrect(int PESELDay, int PESELMonth, int PESELYear)
        {
            if (PESELDay == 0 || PESELDay > 31)
            {
                return false;
            }

            for (int i = 0; i <= 80; i += 20)
            {
                for (int j = 1 + i; j <= 7 + i ? j <= 7 + i : j <= 12 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 31)
                    {
                        return false;
                    }
                }

                for (int j = 4 + i; j <= 6 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 30)
                    {
                        return false;
                    }
                }

                for (int j = 9 + i; j <= 11 + i; j += 2)
                {
                    if (PESELMonth == j && PESELDay > 30)
                    {
                        return false;
                    }
                }
            }

            if (PESELYear == 2000 || (PESELYear % 4 == 0 && PESELYear % 100 != 0))
            {
                if (PESELMonth % 20 == 2 && PESELDay > 29)
                {
                    return false;
                }
            }
            else
            {
                if (PESELMonth % 20 == 2 && PESELDay > 28)
                {
                    return false;
                }
            }

            return true;
        }

        public static int ComputePESELChecksum(List<int> PESELList)
        {
            int sum = PESELList[0] * 9 + PESELList[1] * 7 + PESELList[2] * 3 + PESELList[3] * 1 + PESELList[4] * 9 +
                      PESELList[5] * 7 + PESELList[6] * 3 + PESELList[7] * 1 + PESELList[8] * 9 + PESELList[9] * 7;

            return sum % 10;
        }

        public static void PESEL(string PESELReadLine)
        {
            List<int> PESELList;
            int PESELMonth;
            int PESELDay;
            int PESELYear;
            int PESELChecksum;

            if (!CheckPESELLength(PESELReadLine) || !CheckIfPESELContainsDigitsOnly(PESELReadLine))
            {
                return;
            }

            PESELList = PESELReadLine.ToCharArray().Select(n => (int)char.GetNumericValue(n)).ToList();
            PESELMonth = Int32.Parse(PESELReadLine.Substring(2, 2));
            PESELDay = Int32.Parse(PESELReadLine.Substring(4, 2));
            PESELYear = ComputePESELYear(Int32.Parse(PESELReadLine.Substring(0, 2)), PESELMonth);
            PESELChecksum = Int32.Parse(PESELReadLine.Substring(10, 1));

            if (!CheckIfMonthIsCorrect(PESELMonth) || !CheckIfDayIsCorrect(PESELDay, PESELMonth, PESELYear) || !PESELChecksum.Equals(ComputePESELChecksum(PESELList)))
            {
                return;
            }
        }
    }
}
