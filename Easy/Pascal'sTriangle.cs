using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class Pascal_sTriangle
    {
        public IList<IList<int>> Generate(int numRows)//[[非固定尺寸],[非固定尺寸],.......]
                                                      //呼叫的時候，按照順序打入中括號、索引值=>  bucket[0][0]=>1
        {
            var bucket = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                var x = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        x.Add(1);
                    }
                    else if (j > 0 && j < i)
                    {
                        x.Add(bucket[i - 1][j - 1] + bucket[i - 1][j]);

                    }
                    else
                    {
                        x.Add(1);
                    }
                }
                bucket.Add(x);
            }
            return bucket;
        }
    }
}
