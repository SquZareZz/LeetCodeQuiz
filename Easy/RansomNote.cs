using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            var magazineDict = new Dictionary<char, int>();
            foreach (var word in magazine)
            {
                if (!magazineDict.ContainsKey(word))
                {
                    magazineDict.Add(word, 1);
                }
                else
                {
                    magazineDict[word]++;
                }
            }
            foreach (var word in ransomNote)
            {
                if (!magazineDict.ContainsKey(word))
                {
                    return false;
                }
                else
                {
                    magazineDict[word]--;
                    if (magazineDict[word] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CanConstructSlower(string ransomNote, string magazine)
        {
            while (ransomNote.Length > 0)
            {
                int MagazineIndex = magazine.IndexOf(ransomNote[0]);
                if (MagazineIndex != -1)
                {
                    magazine = magazine.Remove(MagazineIndex, 1);
                    ransomNote = ransomNote.Remove(0, 1);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
