using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ExcelSheetColumnTitle
    {
        public string ConvertToTitleFail(int columnNumber)
        {
            string title = "";//1>26^0+1>26^1+26^0+1
            bool StartScan = true;
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };
            int PowOfCol = 0;
            double SumOfCol = 1;
            while (StartScan)
            {
                if (SumOfCol < columnNumber)
                {
                    PowOfCol++;
                    SumOfCol = Math.Pow(26, PowOfCol) + SumOfCol;

                }
                else
                {
                    StartScan = false;
                }
            }

            for (int i = PowOfCol; i > -1; i--)
            {
                //Convert.ToInt32(Math.Pow(26, PowOfCol));
                int temp = columnNumber / Convert.ToInt32(SumOfCol);
                if (temp == 0)
                {
                    temp = columnNumber % 26;
                }
                else
                {
                    columnNumber = columnNumber - temp * Convert.ToInt32(Math.Pow(26, i));
                }
                title = title + AlphabetConvert.FirstOrDefault(x => x.Value == temp).Key;
                SumOfCol = SumOfCol - Convert.ToInt32(Math.Pow(26, i));
            }
            return title;
        }
        public string ConvertToTitleFail2(int columnNumber)
        {
            string title = "";
            //var AlphabetConvert = new Dictionary<string, int>()
            //{
            //    {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
            //    ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
            //    ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
            //    ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
            //    ,{"Y",25},{"Z",26}
            //};
            string titleIndex = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
            while (columnNumber > 0)
            {
                int Remainder = columnNumber % 26;
                int quotient = columnNumber / 26;
                if (Remainder != 0)
                {
                    title = titleIndex[Remainder] + title;
                    columnNumber = (columnNumber - Remainder) / 26;
                }
                else
                {
                    if (quotient < 27)
                    {
                        title = titleIndex[quotient] + title;
                    }
                    title = titleIndex[quotient] + title;
                    columnNumber = columnNumber / 26;
                }
            }
            return title;
        }
        public string ConvertToTitleFail3(int columnNumber)
        {
            string title = "";
            bool StartScan = true;
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };
            int PowOfCol = 0;
            double SumOfCol = 1;
            while (StartScan)
            {
                if (columnNumber >= SumOfCol)
                {
                    PowOfCol++;
                    SumOfCol = Math.Pow(26, PowOfCol) + SumOfCol;

                }
                else
                {
                    StartScan = false;
                }
            }

            for (int i = PowOfCol; i > 0; i--)
            {
                //SumOfCol=703
                //Convert.ToInt32(Math.Pow(26, PowOfCol));//701
                var ToQuotient = SumOfCol - Math.Pow(26, i);//27
                int temp = 0;
                if (columnNumber != 0)
                {
                    temp = columnNumber / Convert.ToInt32(ToQuotient);//25
                }
                else
                {
                    temp = 1;
                }

                title = AlphabetConvert.FirstOrDefault(x => x.Value == temp).Key + title;
                columnNumber = columnNumber - temp * Convert.ToInt32(ToQuotient);
                SumOfCol -= Math.Pow(26, i);
            }
            return title;
        }
        public string ConvertToTitleBestWay(int columnNumber)
        {
            //a1=26,    a2=27^n*26,when n=1,2,3.....
            //這題的盲點在於，沒有0的概念，所以可能同時有兩種字母能表達同個數
            //ex:52 == 27+25 == 26*2+0 => 沒有0的概念，所以要選擇27+25
            string title = "";
            bool StartScan = true;
            double SumOfCol = 26; int PowOfCol = 1;
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };
            while (StartScan)
            {
                if (SumOfCol < columnNumber)
                {
                    PowOfCol++;
                    if (PowOfCol == 1)
                    {
                        SumOfCol += 26;
                    }
                    else
                    {
                        SumOfCol += Math.Pow(26, PowOfCol);
                    }
                }
                else
                {
                    StartScan = false;
                }
            }
            for (int i = PowOfCol - 1; i > -1; i--)
            {
                int temp = 0;
                if (i != 0)
                {
                    temp = columnNumber / Convert.ToInt32(Math.Pow(26, i));
                    if (columnNumber % 26 == 0)
                    {
                        temp = columnNumber / Convert.ToInt32(Math.Pow(27, i));
                    }
                }
                else
                {
                    temp = columnNumber;
                }
                title += AlphabetConvert.FirstOrDefault(x => x.Value == temp).Key;
                columnNumber -= Convert.ToInt32(Math.Pow(26, i) * temp);

            }
            return title;
        }
        public string ConvertToTitleQuickCompile(int columnNumber)
        {
            //a1=26,    a2=27^n*26,when n=1,2,3.....
            //這題的盲點在於，沒有0的概念，所以可能同時有兩種字母能表達同個數
            //ex:52 == 27+25 == 26*2+0 => 沒有0的概念，所以要選擇27+25
            string title = "";
            string titleIndex = "_ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            bool StartScan = true;
            double SumOfCol = 26; int PowOfCol = 1;
            while (StartScan)
            {
                if (SumOfCol < columnNumber)
                {
                    PowOfCol++;
                    if (PowOfCol == 1)
                    {
                        SumOfCol += 26;
                    }
                    else
                    {
                        SumOfCol += Math.Pow(26, PowOfCol);
                    }
                }
                else
                {
                    StartScan = false;
                }
            }
            for (int i = PowOfCol - 1; i > -1; i--)
            {
                int temp;
                if (i != 0)
                {
                    temp = columnNumber / Convert.ToInt32(Math.Pow(26, i));
                    if (columnNumber % 26 == 0)
                    {
                        temp = columnNumber / Convert.ToInt32(Math.Pow(27, i));
                    }
                }
                else
                {
                    temp = columnNumber;
                }
                title = title + titleIndex[temp];
                columnNumber -= Convert.ToInt32(Math.Pow(26, i) * temp);
            }
            return title;
        }
    }
}
