using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class ZigzagConversion
    {
        public string ConvertFail(string s, int numRows)
        {
            var ZigzagList = new List<string>();
            int LenS = s.Length;
            string Result = "";
            for (int i = 0; i < LenS;)
            {
                switch (i % numRows - 1)
                {
                    case 0:
                        if (LenS - i - 1 >= numRows)
                        {
                            ZigzagList.Add(s.Substring(i, numRows));
                            i += numRows;
                        }
                        else
                        {
                            ZigzagList.Add(s.Substring(i, LenS - i - 1));
                            i += LenS - i - 1;
                        }
                        break;
                    default:
                        ZigzagList.Add(s[i].ToString());
                        break;
                }
            }
            int Count = 0;
            for (int i = 0; i < ZigzagList.Count; i++)
            {

            }
            return "Fail";
            //for (int i = 0; i < LenS; i++)
            //{
            //    int judgeNum = 1 * (numRows-2);//1,2
            //    int judgeNum2 = i % (numRows + judgeNum);//0%4、1%4
            //switch (judgeNum2)
            //{
            //    // 0 6 12
            //    //case 0:
            //    //    Result += ZigzagList[i+ Count*(judgeNum+1)][0];
            //    //break;
            //    //default:
            //    //    Result += ZigzagList[i + Count * (judgeNum + 1)][]
            //    //break;
            //    Count++;
            //}
            //}
        }
        public string ConvertFail2(string s, int numRows)
        {
            int LenS = s.Length;
            var ZigzagList = new List<string>();
            for (int i = 0; i < numRows; i++)
            {
                ZigzagList.Add("");
            }
            int AddValue1 = 2 * (numRows - 1);
            bool AddValue1CK = false, AddValue2CK = false;
            string Result = "";
            int CountCol = 0;
            //[0,4,8,12],[1,3,5,7,9....],[2,6,10] ;4、4/2
            //[0,6,12],[1,5,7,11,13],[2,4,8,10],[3,9] ;6、6/2
            if (numRows == 1)
            {
                return s;
            }
            while (CountCol < numRows)
            {
                if (CountCol == 0 || CountCol == numRows - 1)
                {
                    for (int i = 0; i < LenS;)
                    {
                        if (i + CountCol < LenS)
                        {
                            ZigzagList[CountCol] += s[i + CountCol].ToString();
                        }
                        i += AddValue1;

                    }
                }
                else
                {
                    switch (CountCol % 2)
                    {
                        case 0:
                            for (int i = CountCol; i < LenS;)
                            {
                                ZigzagList[CountCol] += s[i].ToString();
                                if (!AddValue1CK && !AddValue2CK)
                                {
                                    i += 2;
                                    AddValue1CK = true;
                                }
                                else if (AddValue1CK && !AddValue2CK)
                                {
                                    i += 4;
                                    AddValue1CK = false;
                                }
                            }
                            break;
                        case 1:
                            switch (numRows)
                            {
                                case < 4:
                                    for (int i = CountCol; i < LenS;)
                                    {
                                        ZigzagList[CountCol] += s[i].ToString();
                                        i += 2;
                                    }
                                    break;
                                default:
                                    for (int i = CountCol; i < LenS;)
                                    {
                                        ZigzagList[CountCol] += s[i].ToString();
                                        if (!AddValue1CK && !AddValue2CK)
                                        {
                                            i += 4;
                                            AddValue2CK = true;
                                        }
                                        else if (!AddValue1CK && AddValue2CK)
                                        {
                                            i += 2;
                                            AddValue2CK = false;
                                        }
                                    }
                                    break;
                            }
                            break;
                    }
                }
                AddValue1CK = false;
                AddValue2CK = false;
                CountCol++;
            }
            foreach (var str in ZigzagList)
            {
                Result += str;
            }
            return Result;
        }
        public string Convert(string s, int numRows)
        {
            //[0,4,8,12],[1,3,5,7,9....],[2,6,10] ;4、4/2
            //[0,6,12],[1,5,7,11,13],[2,4,8,10],[3,9] ;6、6/2
            //第一段VALUE是 2*(numRows - 2)，第二段VALUE是 2 * (numRows-1) - AddValue2
            int LenS = s.Length;
            //初始化數值
            var ZigzagList = new List<string>();
            for (int i = 0; i < numRows; i++)
            {
                ZigzagList.Add("");
            }
            int CountRow = 0, AddValue1 = numRows - 1;
            bool AddValue1CK = false, AddValue2CK = false;
            //過短特例
            if (numRows == 1)
            {
                return s;
            }

            while (CountRow < numRows)
            {
                if (CountRow == 0 || CountRow == numRows - 1)//頭尾
                {
                    for (int i = 0; i < LenS;)
                    {
                        if (i + CountRow < LenS)
                        {
                            ZigzagList[CountRow] += s[i + CountRow].ToString();
                        }
                        i += 2 * AddValue1;

                    }
                }
                else
                {
                    //每過一行，要重新算一次兩段式的距離
                    //第一段是用row數量減去正在第幾row
                    int AddValue2 = 2 * (AddValue1 - CountRow);
                    //第二段是用兩倍row數減去剩下的數值
                    int AddValue3 = 2 * AddValue1 - AddValue2;

                    switch (numRows)
                    {
                        case < 4:
                            for (int i = CountRow; i < LenS;)
                            {
                                ZigzagList[CountRow] += s[i].ToString();
                                i += 2;
                            }
                            break;
                        default:
                            for (int i = CountRow; i < LenS;)
                            {
                                ZigzagList[CountRow] += s[i].ToString();
                                if (!AddValue1CK && !AddValue2CK)
                                {
                                    i += AddValue2;
                                    AddValue1CK = true;
                                }
                                else if (AddValue1CK && !AddValue2CK)
                                {
                                    i += AddValue3;
                                    AddValue1CK = false;
                                }
                            }
                            break;
                    }
                }
                //初始化
                AddValue1CK = false;
                AddValue2CK = false;
                //往下算
                CountRow++;
            }
            return string.Join("", ZigzagList.ToArray());
        }
    }
}
