using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class SolutionIsPalindrome
    {
        public bool IsPalindrome(int x)
        {
            string tempString = x.ToString();
            string CharFront; string CharBack;

            for (int i = 0; i < tempString.Length; i++)
            {
                CharFront = tempString.Substring(i, 1);
                CharBack = tempString.Substring(tempString.Length - 1 - i, 1);
                if (!CharFront.Equals(CharBack))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class SolutionIsPalindromeBestWay
    {
        public bool IsPalindrome(int x)
        {
            string tempString = x.ToString();

            for (int i = 0; i < tempString.Length; i++)
            {
                if (!tempString.Substring(i, 1).Equals(tempString.Substring(tempString.Length - 1 - i, 1)))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class SolutionIsPalindrome3
    {
        public bool IsPalindrome(int x)
        {

            for (int i = 0; i < x.ToString().Length; i++)
            {
                if (!x.ToString().Substring(i, 1).Equals(x.ToString().Substring(x.ToString().Length - 1 - i, 1)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
