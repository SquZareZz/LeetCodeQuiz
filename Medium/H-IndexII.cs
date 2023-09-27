﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class H_IndexII
    {
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            int Count = 0, Len = citations.Length;
            if (Len == 1)
            {
                return Math.Min(1, citations[0]);
            }
            for (int i = Len - 1; i > -1; i--)
            {
                if (Count >= citations[i])
                {
                    return Math.Max(citations[i], Count);
                }
                else
                {
                    Count++;
                }
            }
            return Count;

        }
    }
}
