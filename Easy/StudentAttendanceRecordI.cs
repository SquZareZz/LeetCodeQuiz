using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class StudentAttendanceRecordI
    {
        public bool CheckRecord(string s)
        {
            int CountL = 0, CountA = 0;
            foreach (char c in s)
            {
                switch (c)
                {
                    case 'A':
                        CountA++;
                        CountL = 0;
                        if (CountA > 1)
                        {
                            return false;
                        }
                        break;
                    case 'L':
                        CountL++;
                        if (CountL >= 3)
                        {
                            return false;
                        }
                        break;
                    case 'P':
                        CountL = 0;
                        break;
                }
            }
            return true;
        }
        public bool CheckRecordOneRow(string s)
        {
            return !s.Contains("LLL") && s.Split('A').Length - 1 < 2;
        }
    }
}
