using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            if (String.IsNullOrEmpty(word1) || String.IsNullOrEmpty(word2))
            {
                return Math.Max(word1.Length, word2.Length);
            }
            var ResTable = new int[word1.Length + 1, word2.Length + 1];
            //做邊緣
            for (int i = 0; i < word1.Length + 1; i++)
            {
                if (i == 0)
                {
                    ResTable[i, 0] = 0;
                }
                else
                {
                    ResTable[i, 0] = ResTable[i - 1, 0] + 1;
                }
            }
            for (int i = 0; i < word2.Length + 1; i++)
            {
                if (i == 0)
                {
                    ResTable[0, i] = 0;
                }
                else
                {
                    ResTable[0, i] = ResTable[0, i - 1] + 1;
                }
            }
            //方向有三，↖↑←
            //如果是↖，當現階段英文字母相同時，不需要增加步驟
            //如果是↑或←，不論現階段英文字母是否相同，都需要移除字母，所以都是+1
            for (int i = 1; i < word1.Length + 1; i++)
            {
                for (int j = 1; j < word2.Length + 1; j++)
                {
                    var ToAdd = word1[i - 1] == word2[j - 1] ? 0 : 1;
                    ResTable[i, j] = Math.Min(Math.Min(ResTable[i - 1, j] + 1, ResTable[i, j - 1] + 1),
                        ResTable[i - 1, j - 1] + ToAdd);
                }
            }
            Bitmap bitmap = CreateMatrixImage(ResTable, word1, word2);

            // 將圖片保存到文件
            bitmap.Save("C:\\Users\\jaysu\\Downloads\\output.png", System.Drawing.Imaging.ImageFormat.Png);
            return ResTable[word1.Length, word2.Length];
        }
        static Bitmap CreateMatrixImage(int[,] matrix, string word1, string word2)
        {
            int width = matrix.GetLength(1);
            int height = matrix.GetLength(0);
            int cellSize = 50; // 每個單元格的大小

            Bitmap bitmap = new Bitmap(width * cellSize, height * cellSize);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                for (int y = 0; y < height + 1; y++)
                {

                    for (int x = 0; x < width + 1; x++)
                    {
                        Brush brush = Brushes.Black;
                        string text;
                        Font font = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);
                        if (y == 0 && x == 0)
                        {
                            continue;
                        }
                        else if ((y == 0 && x == 1) || (x == 0 && y == 1))
                        {
                            text = 0.ToString();
                        }
                        else if (y == 0)
                        {
                            text = word2[x - 2].ToString();
                        }
                        else if (x == 0)
                        {
                            text = word1[y - 2].ToString();
                        }
                        else
                        {
                            text = matrix[y - 1, x - 1].ToString();
                        }
                        g.DrawString(text, font, brush, x * cellSize, y * cellSize);
                    }
                }
            }

            return bitmap;
        }
    }
}
