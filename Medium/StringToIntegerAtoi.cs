using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class StringToIntegerAtoi
    {
        public int MyAtoi(string s)
        {
            string ResultStr = "";
            bool SignFrontCheck = false, SignCheck = true;
            if (s.Length > 1)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0' && string.IsNullOrEmpty(ResultStr))
                    {
                        if (s.Length > 1 && i < s.Length - 1)
                        {
                            if (int.TryParse(s[i + 1].ToString(), out int ParseTry))
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (s[i] == ' ')
                    {
                        if (string.IsNullOrEmpty(ResultStr))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    }
                    else if (s[i] == '-' && !SignFrontCheck)
                    {
                        if (int.TryParse(s[i + 1].ToString(), out int ParseTry))
                        {
                            SignCheck = false;
                            SignFrontCheck = true;
                        }
                        else
                        {
                            break;
                        }

                    }
                    else if (s[i] == '+' && !SignFrontCheck)
                    {
                        if (int.TryParse(s[i + 1].ToString(), out int ParseTry))
                        {
                            SignFrontCheck = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (int.TryParse(s[i].ToString(), out int ParseTry))
                        {
                            ResultStr += s[i];
                            SignFrontCheck = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                return int.TryParse(s, out int value1And0) ? value1And0 : 0;
            }

            if (string.IsNullOrEmpty(ResultStr))
            {
                return 0;
            }
            if (int.TryParse(ResultStr, out int value))
            {
                return !SignCheck ? value * -1 : value;
            }
            else
            {
                return !SignCheck ? Convert.ToInt32(Math.Pow(2, 31) * -1) : Convert.ToInt32(Math.Pow(2, 30) - 1 + Math.Pow(2, 30));
            }

        }
    }
}
