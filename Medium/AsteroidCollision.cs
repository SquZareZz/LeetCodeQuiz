using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class AsteroidCollision
    {
        public int[] AsteroidCollisionFail(int[] asteroids)
        {
            var ResultStack = new Stack<int>();
            foreach (var asteroid in asteroids)
            {
                if (ResultStack.Count == 0)
                {
                    ResultStack.Push(asteroid);
                    continue;
                }
                var temp = ResultStack.Peek();
                if (temp * asteroid < 0)
                {
                    if (Math.Abs(temp) > Math.Abs(asteroid))
                    {
                        continue;
                    }
                    else if (Math.Abs(temp) < Math.Abs(asteroid))
                    {
                        while (ResultStack.Count > 0 && ResultStack.Peek() * asteroid < 0)
                        {
                            if (Math.Abs(ResultStack.Peek()) < Math.Abs(asteroid))
                            {
                                ResultStack.Pop();
                            }
                            else if (Math.Abs(ResultStack.Peek()) > Math.Abs(asteroid))
                            {
                                break;
                            }
                            else
                            {
                                ResultStack.Pop();
                                break;
                            }
                        }
                        if (ResultStack.Count == 0)
                        {
                            ResultStack.Push(asteroid);
                        }
                    }
                    else
                    {
                        ResultStack.Pop();
                    }
                }
                else
                {
                    ResultStack.Push(asteroid);
                }
            }
            return ResultStack.ToArray().Reverse().ToArray();
        }
        public int[] AsteroidCollision1(int[] asteroids)
        {
            var ResultStack = new Stack<int>();
            foreach (var asteroid in asteroids)
            {
                if (ResultStack.Count == 0)
                {
                    ResultStack.Push(asteroid);
                    continue;
                }
                var temp = ResultStack.Peek();
                //← → 都直接放
                if (temp * asteroid < 0 && temp < 0)
                {
                    ResultStack.Push(asteroid);
                }
                // → ← 需要比大小
                else if (temp * asteroid < 0 && temp > 0)
                {
                    //左比右大直接無視，因為右邊被擠掉了
                    if (Math.Abs(temp) > Math.Abs(asteroid))
                    {
                        continue;
                    }
                    //左等於右時，同號最上面要拿掉、異號保留
                    else if (Math.Abs(temp) == Math.Abs(asteroid))
                    {
                        ResultStack.Pop();
                    }
                    //左比右小要一路比到左等於右或比右大為止
                    else
                    {
                        bool ToPut = false;
                        while (ResultStack.Count > 0 && ResultStack.Peek() * asteroid < 0)
                        {
                            if (Math.Abs(ResultStack.Peek()) < Math.Abs(asteroid))
                            {
                                ToPut = true;
                                ResultStack.Pop();
                            }
                            else if (Math.Abs(ResultStack.Peek()) > Math.Abs(asteroid))
                            {
                                ToPut = false;
                                break;
                            }
                            else
                            {
                                ToPut = false;
                                ResultStack.Pop();
                                break;
                            }
                        }
                        if (ToPut) ResultStack.Push(asteroid);
                    }
                }
                else
                {
                    //相乘 >0 必定是 ← ← 或 → → ，直接放
                    ResultStack.Push(asteroid);
                }
            }
            return ResultStack.ToArray().Reverse().ToArray();
        }
    }
}
