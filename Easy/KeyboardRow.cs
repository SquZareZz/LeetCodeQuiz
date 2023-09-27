using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class KeyboardRow
    {
        public string[] FindWords(string[] words)
        {
            var ResultTemp = new List<string>();
            string[] KeyboardRow = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
            foreach (string word in words)
            {
                bool CheckInside = false;
                for (int i = 0; i < 3; i++)
                {
                    string TarStr = KeyboardRow[i];
                    int Count = 0;
                    foreach (char c in word.ToLower())
                    {
                        if (!TarStr.Contains(c.ToString()))
                        {
                            break;
                        }
                        else
                        {
                            Count++;
                        }
                    }
                    if (Count == word.Length)
                    {
                        CheckInside = true;
                        break;
                    }
                    else
                    {
                        Count = 0;
                    }

                }
                if (CheckInside)
                {
                    ResultTemp.Add(word);
                }
            }
            return ResultTemp.Select(i => i.ToString()).ToArray();


        }
        public string[] FindWords2(string[] words)
        {
            var ResultTemp = new List<string>();
            foreach (string word in words)
            {
                bool CheckInside = false;
                for (int i = 1; i < 4; i++)
                {
                    string TarStr = "";
                    switch (i)
                    {
                        case 1:
                            TarStr = "qwertyuiop";
                            break;
                        case 2:
                            TarStr = "asdfghjkl";
                            break;
                        case 3:
                            TarStr = "zxcvbnm";
                            break;
                    }

                    for (int j = 0; j < word.Length + 1; j++)
                    {
                        if (j == word.Length)
                        {
                            CheckInside = true;
                            break;
                        }
                        if (TarStr.IndexOf(word[j].ToString().ToLower()) == -1)
                        {
                            break;
                        }
                    }
                }
                if (CheckInside)
                {
                    ResultTemp.Add(word);
                }
            }
            return ResultTemp.Select(i => i.ToString()).ToArray();


        }
    }
}
