using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class MaximumLengthSubstringWithTwoOccurrences
    {
        public int MaximumLengthSubstringFail(string s)
        {

            var EachItems = s.ToHashSet<char>();
            Dictionary<char, int> charCountDict = EachItems.ToDictionary(c => c, c => 0);
            int Front = 0, Back = 0;
            foreach (char c in s)
            {
                if (charCountDict[c] == 2)
                {
                    if (charCountDict.Count(x => x.Value != 0) != charCountDict.Count())
                    {
                        Front = -1;
                    }
                    break;
                }
                else
                {
                    charCountDict[c]++;
                    Front++;
                }
            }
            charCountDict = EachItems.ToDictionary(c => c, c => 0);
            foreach (char c in s.Reverse())
            {
                if (charCountDict[c] == 2)
                {
                    if (charCountDict.Count(x => x.Value != 0) != charCountDict.Count())
                    {
                        Back = -1;
                    }
                    break;
                }
                else
                {
                    charCountDict[c]++;
                    Back++;
                }
            }
            return Math.Max(Front, Back);
        }
        public int MaximumLengthSubstring(string s)
        {
            Dictionary<char, int> Dict = s.ToHashSet<char>().ToDictionary(c => c, c => 0);
            foreach (var c in s)
            {
                if (Dict[c] < 3)
                {
                    Dict[c]++;
                }                
            }
            return Dict.Values.Sum();
        }
    }
}
