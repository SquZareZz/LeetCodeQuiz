using QuizSolution.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class GrayCode
    {
        //實際上考的是移位計算，不用內存移位的就會算很久
        
        public IList<int> GrayCode1(int n)
        {
            var Result=new List<int>();
            for(int i=0;i< Math.Pow(2, n); i++) 
            {
                string Temp=Convert.ToString(i,2);
                string TempResult = "" + Temp[0];
                for(int j=1;j<Temp.Length;j++)
                {
                    TempResult += (Temp[j] ^ (Temp[j - 1] - '0')) - '0';
                }
                Result.Add(Convert.ToInt32(TempResult,2));
            }
            return Result;
        }
        public IList<int> GrayCode2(int n)
        {
            var Result = new List<int>();
            for (int i = 0; i < Math.Pow(2, n); i++)
            {
                Result.Add((i >> 1) ^ i);//i 右移1位跟原本 i 做XOR
                //也就是原數/2以後XOR
            }
            return Result;
        }
    }
}
