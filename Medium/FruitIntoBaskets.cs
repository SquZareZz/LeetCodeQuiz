using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class FruitIntoBaskets
    {
        public int TotalFruit(int[] fruits)
        {
            bool FirstKind = false, SecondKind = false;
            int[] YourBasket = new int[2];
            int Result = 0, Len = fruits.Length, IndexOf0 = 0, IndexOf1 = 0;
            if (Len < 2)
            {
                return Len;
            }
            int temp = 0;
            for (int i = 0; i < Len; i++)
            {
                if (!FirstKind)
                {
                    YourBasket[0] = fruits[i];
                    IndexOf0 = i;
                    FirstKind = true;
                    temp++;
                }
                else if (FirstKind && !SecondKind)
                {
                    if (YourBasket[0] == fruits[i])
                    {
                        temp++;
                        IndexOf0 = i;
                    }
                    else
                    {
                        YourBasket[1] = fruits[i];

                        SecondKind = true;
                        temp++;
                        IndexOf1 = i;
                    }
                }
                else if (FirstKind && SecondKind)
                {
                    if (YourBasket[0] == fruits[i])
                    {
                        temp++;
                        IndexOf0 = i;
                    }
                    else if (YourBasket[1] == fruits[i])
                    {
                        temp++;
                        IndexOf1 = i;
                    }
                    else
                    {
                        if (temp > Result)
                        {
                            Result = temp;
                        }

                        YourBasket[0] = fruits[i - 1];
                        YourBasket[1] = fruits[i];
                        i = IndexOf1 < IndexOf0 ? IndexOf1 : IndexOf0;
                        temp = 0;
                    }
                }
            }
            return Result = Result > temp ? Result : temp;
        }
        public int TotalFruit2(int[] fruits)
        {
            bool FirstKind = false, SecondKind = false;
            int[] YourBasket = new int[2];
            int Result = 0, Len = fruits.Length, IndexOf0 = 0, IndexOf1 = 0;
            if (Len < 2)
            {
                return Len;
            }
            int temp = 0;
            for (int i = 0; i < Len; i++)
            {
                if (!FirstKind)
                {
                    YourBasket[0] = fruits[i];
                    IndexOf0 = i;
                    FirstKind = true;
                    temp++;
                }
                else if (FirstKind && !SecondKind)
                {
                    if (YourBasket[0] == fruits[i])
                    {
                        temp++;
                        IndexOf0 = i;
                    }
                    else
                    {
                        YourBasket[1] = fruits[i];

                        SecondKind = true;
                        temp++;
                        IndexOf1 = i;
                    }
                }
                else if (FirstKind && SecondKind)
                {
                    if (YourBasket[0] == fruits[i])
                    {
                        temp++;
                        IndexOf0 = i;
                    }
                    else if (YourBasket[1] == fruits[i])
                    {
                        temp++;
                        IndexOf1 = i;
                    }
                    else
                    {
                        if (temp > Result)
                        {
                            Result = temp;
                        }
                        YourBasket[0] = fruits[i - 1];
                        YourBasket[1] = fruits[i];
                        i = IndexOf1 < IndexOf0 ? IndexOf1 : IndexOf0;
                        temp = 0;
                    }
                }
            }
            return Result = Result > temp ? Result : temp;
        }
    }
}
