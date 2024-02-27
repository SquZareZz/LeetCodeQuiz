using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class KeysAndRooms
    {

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            //未確認過的 = 需要調查
            var RoomCK = new bool[rooms.Count];
            //能開的 = 可以調查
            var RoomOpen = new bool[rooms.Count];
            //第一間的門必開
            RoomOpen[0] = true;
            var BeOpened = FindKeys(RoomOpen, rooms, RoomCK);
            //最後統計有沒有沒開成的
            return BeOpened.Count(x => x == false) == 0;
        }
        public bool[] FindKeys(bool[] RoomOpen, IList<IList<int>> rooms, bool[] RoomCK)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (RoomOpen[i] == true && RoomCK[i] == false)
                {
                    foreach (var key in rooms[i])
                    {
                        RoomOpen[key] = true;
                    }
                    RoomCK[i] = true;
                    FindKeys(RoomOpen, rooms, RoomCK);
                }
            }
            return RoomOpen;
        }
    }
}
