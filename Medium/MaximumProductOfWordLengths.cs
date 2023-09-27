using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class MaximumProductOfWordLengths
    {
        public int MaxProduct(string[] words)
        {
            int Result = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                var Tar1 = new HashSet<char>(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    string Tar2 = words[j];
                    bool ToDoCheck = false;
                    foreach (char c in Tar1)
                    {
                        if (Tar2.Contains(c))
                        {
                            ToDoCheck = true;
                            break;
                        }
                    }
                    if (!ToDoCheck)
                    {
                        Result = Math.Max(Result, words[i].Length * Tar2.Length);
                    }
                }
            }
            return Result;
        }
        public int MaxProductSlowly(string[] words)
        {
            //全用哈希表太慢
            int Result = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                //用哈希表省掉比對時間
                var Tar1 = new HashSet<char>(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    var Tar2 = new HashSet<char>(words[j]);
                    bool ToDoCheck = false;
                    if (Tar2.Except(Tar1).Count() != Tar2.Count)
                    {
                        ToDoCheck = true;
                    }
                    if (!ToDoCheck)
                    {
                        Result = Math.Max(Result, words[i].Length * words[j].Length);
                    }
                }
            }
            return Result;
        }
    }
}
