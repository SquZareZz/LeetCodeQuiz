using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class StringCompression
    {
        public int CompressFail(char[] chars)
        {
            if(chars.Length == 1)
            {
                return 1;
            }
            var CharsDictionary = new Dictionary<char,int>();
            var CharType = new List<char>();
            foreach(char c in chars)
            {
                if (!CharsDictionary.ContainsKey(c))
                {
                    CharsDictionary.Add(c, 1);
                    CharType.Add(c);
                }
                else
                {
                    CharsDictionary[c]++;
                }
            }
            int Result = CharsDictionary.Count,ToWriteDown=0;
            for(int i=0;i< Result; i++)
            {
                chars[i+ ToWriteDown] = CharType[i];
                int ToTrans = CharsDictionary[CharType[i]];
                switch (ToTrans)
                {
                    case 1:
                        ToWriteDown = i;
                        continue;
                    case >9:
                        foreach (char c in ToTrans.ToString())
                        {
                            chars[i + ToWriteDown + 1] = (Char)(c);
                            ToWriteDown++;
                        }
                        ToWriteDown++;
                        break;
                    default:
                        chars[i + ToWriteDown + 1] =(Char)(ToTrans + 48);
                        ToWriteDown = 1+i;
                    break;
                }
            }
            return 2* Result;
        }
        public int Compress(char[] chars)
        {
            int Result = 0,tempCount=0;
            var ZipList = new List<string>();
            char temp=chars[0];
            foreach(char c in chars)
            {
                if (temp != c)
                {
                    if (tempCount == 1)
                    {
                        ZipList.Add(temp.ToString());
                    }
                    else
                    {
                        ZipList.Add(temp.ToString() + tempCount);
                    }
                    temp = c;
                    tempCount = 1;
                }
                else
                {
                    tempCount++;
                }
            }
            //最後一號再做一次
            if (tempCount == 1)
            {
                ZipList.Add(temp.ToString());
            }
            else
            {
                ZipList.Add(temp.ToString() + tempCount);
            }
            foreach (var ZipStr in ZipList)
            {
                foreach (char c in ZipStr)
                {
                    chars[Result] = c;
                    Result++;
                }
            }
            return Result;
        }
    }
}
