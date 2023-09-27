using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class AddBinary
    {
        public string AddBinaryFail(string a, string b)
        {
            string ReturnStr = "";
            int LenA = a.Length;
            int LenB = b.Length;
            int carryOrNot = 0;
            if (LenB > LenA)
            {
                int temp = 0;
                temp = LenA; LenA = LenB; LenB = temp;
                string temp2 = "";
                temp2 = a; a = b; b = temp2;
            }
            for (int i = LenB - 1; i > -1; i--)
            {
                if (int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) == 2)
                {
                    ReturnStr = ReturnStr + "0";
                }
                else
                {
                    ReturnStr = ReturnStr + int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()).ToString();
                }
            }
            if (int.Parse(a[LenB - 1].ToString()) + int.Parse(b[LenB - 1].ToString()) == 2)
            {
                carryOrNot = 1;
            }
            for (int j = LenA - LenB - 1; j > -1; j--)
            {
                if (int.Parse(a[j].ToString()) + carryOrNot == 2)
                {
                    ReturnStr = ReturnStr + "0";
                    carryOrNot = 1;
                }
                else
                {
                    ReturnStr = ReturnStr + (int.Parse(a[j].ToString()) + carryOrNot).ToString();
                    carryOrNot = 0;
                }
            }
            if (ReturnStr[ReturnStr.Length - 1] == '0')
            {
                ReturnStr = ReturnStr + "1";
            }
            return string.Join("", ReturnStr.Reverse().ToArray());
        }
        public string AddBinary1(string a, string b)
        {
            string ReturnStr = "";
            int LenA = a.Length;
            int LenB = b.Length;
            int LenBigger;
            int carryOrNot = 0;
            //補位
            if (LenB > LenA)
            {
                LenBigger = LenB;
                for (int i = 0; i < LenB - LenA; i++)
                {
                    a = "0" + a;
                }
            }
            else if (LenA > LenB)
            {
                LenBigger = LenA;
                for (int i = 0; i < LenA - LenB; i++)
                {
                    b = "0" + b;
                }
            }
            else
            {
                LenBigger = LenB;
            }

            for (int i = LenBigger - 1; i > -1; i--)
            {
                if (int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + carryOrNot == 3)
                {
                    ReturnStr = "1" + ReturnStr;
                    carryOrNot = 1;
                }
                else if (int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + carryOrNot == 2)
                {
                    ReturnStr = "0" + ReturnStr;
                    carryOrNot = 1;
                }
                else
                {
                    ReturnStr = (int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + carryOrNot).ToString() + ReturnStr;
                    carryOrNot = 0;
                }
            }
            if (carryOrNot == 1)
            {
                ReturnStr = "1" + ReturnStr;
            }

            return ReturnStr;
        }
        public string AddBinaryBestWay(string a, string b)
        {
            string ReturnStr = "";
            int LenA = a.Length;
            int LenB = b.Length;
            int carryOrNot = 0;
            // char-'0'=real value

            while (LenA >= 0 || LenB >= 0)
            {
                int AtoAdd = LenA > 0 ? a[LenA - 1] : '0';
                int BtoAdd = LenB > 0 ? b[LenB - 1] : '0';

                switch (AtoAdd - '0' + (BtoAdd - '0') + carryOrNot)
                {
                    case 3:
                        ReturnStr = "1" + ReturnStr;
                        carryOrNot = 1;
                        break;
                    case 2:
                        ReturnStr = "0" + ReturnStr;
                        carryOrNot = 1;
                        break;
                    case 1:
                        ReturnStr = "1" + ReturnStr;
                        carryOrNot = 0;
                        break;
                    case 0:
                        if (LenA > 1 || LenB > 1)
                        {
                            ReturnStr = "0" + ReturnStr;
                            carryOrNot = 0;
                        }
                        else if (LenA == LenB && LenA > 0)
                        {
                            ReturnStr = "0" + ReturnStr;
                            carryOrNot = 0;
                        }
                        break;
                }
                LenA--;
                LenB--;
            }
            return ReturnStr;
        }
    }
}
// A=5 B=-1 Y, A=5 B=1 Y, A=0 B=-1 Y, A=0 B=0 
// A>B