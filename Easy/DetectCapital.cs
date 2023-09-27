using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DetectCapital
    {
        public bool DetectCapitalUse(string word)
        {
            //true=Upper;false=Lowwer
            bool FirstLetter = false, SecondOn = false, ThirdOn = false;
            int Count = 0;//算第幾項
            foreach (char c in word)
            {
                switch (Count)
                {
                    case 0:
                        FirstLetter = c >= 'a' && c <= 'z' && Count == 0 ? false : true;
                        break;

                    default:
                        switch (FirstLetter)
                        {
                            case true:
                                if (c >= 'A' && c <= 'Z' && Count > 0)//
                                {
                                    SecondOn = true;
                                }
                                else if (c >= 'a' && c <= 'z' && Count > 0)
                                {
                                    ThirdOn = true;
                                }

                                if (SecondOn && c >= 'a' && c <= 'z')
                                {
                                    return false;
                                }
                                else if (ThirdOn && c >= 'A' && c <= 'Z')
                                {
                                    return false;
                                }
                                break;

                            case false:
                                if (c >= 'A' && c <= 'Z')//
                                {
                                    return false;
                                }
                                break;
                        }
                        break;
                }
                Count++;
            }
            return true;
        }
    }
}
