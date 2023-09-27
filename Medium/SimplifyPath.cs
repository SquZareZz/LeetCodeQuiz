using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SimplifyPath
    {
        public string SimplifyPath1(string path)
        {
            var Result=new List<string>();
            int i = 0;
            //先開始找第一個斜線
            //之後往下找第二個斜線，這中間的字串儲存到一個LIST
            //如果字串不是一個點或兩個點，儲存
            //如果是一個點，PASS後重找
            //如果是兩個點，把上一項刪掉
            while (i < path.Length-1)
            {
                //part1
                while (i < path.Length&&path[i] == '/' ) 
                {
                    i++;
                }
                if (i == path.Length)
                {
                    break;
                }
                int start = i;
                //part2
                while (i < path.Length && path[i] != '/' ) 
                {
                    i++;
                }
                int end = i - 1;
                //
                string s = path.Substring(start, end - start + 1);
                if (s == "..")
                {
                    if (Result.Count != 0)
                    {
                        Result.RemoveAt(Result.Count-1);
                    }
                }
                else if (s != ".")
                {
                    Result.Add(s);
                }
            }
            if (Result.Count == 0)
            {
                return "/";
            }
            string ResultStr = "";
            foreach(string s in Result)
            {
                ResultStr += "/" + s;
            }
            return ResultStr;
        }
    }
}
