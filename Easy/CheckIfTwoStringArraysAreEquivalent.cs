using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class CheckIfTwoStringArraysAreEquivalent
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            var temp1 = new StringBuilder();
            var temp2 = new StringBuilder();
            foreach (var word in word1)
            {
                temp1.Append(word);
            }
            foreach(var word in word2)
            {
                temp2.Append(word);
            }            
            return temp1.Equals(temp2);
        }
    }
}
