using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SuperPow
    {
        public int SuperPow1(int a, int[] b)
        {
            //用二分法，把原始的極大數(ex:2^100)拆成兩個數(ex:2^100=>ex:2^50*2^50)
            //直到取餘的目標要到了，才開始做(ex:2048/1337)
            //因為不考慮商，所以退回原本的數，餘數是一樣的，只是商成倍數關係
            long res = 1;
            for (int i = 0; i < b.Length; i++)
            {
                long a1 = IteratePow(res, 10);
                var a2 = IteratePow(a, b[i]) % 1337;
                res = a1 * a2;
                //res = IteratePow(res, 10) * IteratePow(a, b[i]) % 1337;
            }
            return (int)res;
        }
        public long IteratePow(long Multiplicand, int PowerN)
        {
            switch (PowerN)
            {
                case 0:
                    return 1;
                case 1:
                    return Multiplicand % 1337;
                default:
                    return IteratePow(Multiplicand % 1337, PowerN / 2) 
                        * IteratePow(Multiplicand % 1337, PowerN - PowerN / 2) % 1337;
            }
        }
    }
}
