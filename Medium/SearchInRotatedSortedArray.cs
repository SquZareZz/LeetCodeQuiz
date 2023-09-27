using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class SearchInRotatedSortedArray
    {
        public int SearchNoBinaryWay(int[] nums, int target)
        {
            return Array.IndexOf(nums, target);//這是一個答案，但你絕對被打槍
        }
        public int Search(int[] nums, int target)
        {
            //Tar=4;
            //0 1 2 3 4 5 6 7
            //Option 1: 4 5 6 7 0 1 2 3
            //Option 2: 5 6 7 0 1 2 3 4
            //方向是->左到右、小到大，但不知道哪裡被切斷過
            //所以如果中間比頭小，那中間的附近一定有斷點;相反往尾部找，會有斷點
            int Start = 0, End = nums.Length - 1;
            while (Start < End + 1)
            {
                int Mid = Start + (End - Start) / 2;//猜測旋轉點
                if (nums[Mid] == target)//中了直接回傳
                {
                    return Mid;
                }
                if (nums[Mid] < nums[End])//如果中點數字比尾端小
                {
                    if (nums[Mid] < target && nums[End] >= target)//如果中點比目標小且尾端>=目標
                    {
                        Start = Mid + 1;//起始往中點靠
                    }
                    else
                    {
                        End = Mid - 1;//沒有用終點往中間靠
                    }
                }
                else//同理如果中點大於等於尾端
                {
                    if (nums[Start] <= target && nums[Mid] > target)//改成判斷起點是否小於等於目標
                    {
                        End = Mid - 1;
                    }
                    else
                    {
                        Start = Mid + 1;
                    }
                }
            }
            return -1;
        }
    }
}
