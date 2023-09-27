using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class ExcelSheetColumnNumber
    {
        public int TitleToNumber(string columnTitle)
        {
            int result = 0;
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };
            int TarLen = columnTitle.Length;

            if (TarLen == 1)
            {
                return AlphabetConvert[columnTitle];
            }
            else
            {
                int j = 0;
                for (int i = TarLen - 1; i > -1; i--)
                {
                    result += AlphabetConvert[columnTitle[j].ToString()] * Convert.ToInt32(Math.Pow(26, i));
                    j++;
                }
            }
            return result;
        }
        public int TitleToNumberNodictAndSlower(string columnTitle)
        {
            string AlphabetConvert = "_ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (columnTitle.Length == 1)
            {
                return AlphabetConvert.IndexOf(columnTitle);
            }
            else
            {
                int j = 0; int result = 0;
                for (int i = columnTitle.Length - 1; i > -1; i--)
                {
                    result += AlphabetConvert.IndexOf(columnTitle[j]) * Convert.ToInt32(Math.Pow(26, i));
                    j++;
                }
                return result;
            }
        }
        public int TitleToNumberSlower(string columnTitle)
        {
            int result = 0;
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };

            if (columnTitle.Length == 1)
            {
                return AlphabetConvert[columnTitle];
            }
            else
            {
                for (int i = columnTitle.Length - 1; i > -1; i--)
                {
                    result += AlphabetConvert[new string(columnTitle.Reverse().ToArray())[i].ToString()] * Convert.ToInt32(Math.Pow(26, i));
                }
            }
            return result;
        }
        public int TitleToNumber2(string columnTitle)
        {
            var AlphabetConvert = new Dictionary<string, int>()
            {
                {"A",1 },{"B",2},{"C",3},{"D",4},{"E",5},{"F",6}
                ,{"G",7},{"H",8},{"I",9},{"J",10},{"K",11},{"L",12}
                ,{"M",13},{"N",14},{"O",15},{"P",16},{"Q",17},{"R",18}
                ,{"S",19},{"T",20},{"U",21},{"V",22},{"W",23},{"X",24}
                ,{"Y",25},{"Z",26}
            };

            if (columnTitle.Length == 1)
            {
                return AlphabetConvert[columnTitle];
            }
            else
            {
                int j = 0; int result = 0;
                for (int i = columnTitle.Length - 1; i > -1; i--)
                {
                    result += AlphabetConvert[columnTitle[j].ToString()] * Convert.ToInt32(Math.Pow(26, i));
                    j++;
                }
                return result;
            }
        }
    }
}
