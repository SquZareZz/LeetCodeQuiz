using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DistanceBetweenBusStops
    {
        public int DistanceBetweenBusStops1(int[] distance, int start, int destination)
        {
            int Clockwise = 0, CounterClockwise = 0;
            int Clock_Now = start;

            while (Clock_Now != destination)
            {
                if (Clock_Now == distance.Length)
                {
                    Clock_Now = 0;
                    if (destination == 0) break;
                }
                Clockwise += distance[Clock_Now];
                Clock_Now++;
            }
            Clock_Now = start;
            while (Clock_Now != destination)
            {
                if (Clock_Now == 0)
                {
                    Clock_Now = distance.Length - 1;
                    CounterClockwise += distance[Clock_Now];
                }
                else
                {
                    Clock_Now--;
                    CounterClockwise += distance[Clock_Now];                    
                }                
            }
            return Math.Min(Clockwise, CounterClockwise);
        }
    }
}
