using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FindWordsContainingCharacter
    {
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            var result = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(x))
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public IList<int> FindWordsContaining2(string[] words, char x)
        {
            var result = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {
                foreach (var c in words[i])
                {
                    if (c == x)
                    {
                        result.Add(i);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
