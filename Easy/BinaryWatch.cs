using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class BinaryWatch
    {
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            var Result = new List<string>();
            string MinuteWord;
            int ZeroCount = 0;
            if (turnedOn > 8)
            {
                return Result;
            }
            else if (turnedOn == 0)
            {
                Result.Add("0:00");
            }
            else
            {
                for (int i = 1; i < 12; i++)
                {
                    int turnedOnTemp = turnedOn;
                    int MinCheck = MinuteEvent(i);
                    if (MinCheck <= turnedOn)
                    {
                        turnedOnTemp -= MinCheck;
                        MinuteWord = i.ToString();
                    }
                    else
                    {
                        MinuteWord = "0";
                        ZeroCount++;
                    }
                    if (turnedOnTemp == 0)
                    {
                        Result.Add(MinuteWord + ":00");
                    }
                    else
                    {
                        if (ZeroCount < 2)
                        {
                            Result = SecondEvent(turnedOnTemp, Result, MinuteWord);
                        }
                    }
                }
                if (ZeroCount == 0)//補算 0時的狀況
                {
                    Result = SecondEvent(turnedOn, Result, "0");
                }
            }

            return Result;
        }
        public IList<string> ReadBinaryWatchBestWay(int turnedOn)
        {
            var Result = new List<string>();
            string MinuteWord = "";
            if (turnedOn > 8)
            {
                return Result;
            }
            else if (turnedOn == 0)
            {
                Result.Add("0:00");
            }
            else
            {
                for (int i = 1; i < 12; i++)
                {
                    int turnedOnTemp = turnedOn;
                    int MinCheck = MinuteEvent(i);
                    if (MinCheck <= turnedOn)
                    {
                        turnedOnTemp -= MinCheck;
                        MinuteWord = i.ToString();
                    }
                    if (turnedOnTemp == 0)
                    {
                        Result.Add(MinuteWord + ":00");
                    }
                    else
                    {
                        if (turnedOnTemp != turnedOn)
                        {
                            Result = SecondEvent(turnedOnTemp, Result, MinuteWord);
                        }
                    }
                }
                Result = SecondEvent(turnedOn, Result, "0");
            }

            return Result;
        }
        public int MinuteEvent(int turnedOn)
        {
            switch (turnedOn)
            {
                case 1:
                case 2:
                case 4:
                case 8:
                    turnedOn = 1;
                    break;
                case 7:
                case 11:
                    turnedOn = 3;
                    break;
                default:
                    turnedOn = 2;
                    break;
            }
            return turnedOn;
        }
        public List<string> SecondEvent(int turnedOnTemp, List<string> Result, string MinuteWord)
        {
            int ToCountBinary = 0;
            for (int k = 0; k < 60; k++)
            {
                string temp = Convert.ToString(k, 2);
                foreach (var a in temp)//Binary Trans
                {
                    if (a == '1')
                    {
                        ToCountBinary++;
                    }
                }
                if (turnedOnTemp == ToCountBinary)//Add to List
                {
                    if (k < 10)
                    {
                        Result.Add(MinuteWord + ":0" + k.ToString());
                    }
                    else
                    {
                        Result.Add(MinuteWord + ":" + k.ToString());
                    }
                }
                ToCountBinary = 0;
            }
            return Result;
        }
    }
}
