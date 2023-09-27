using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class BasicCalculatorII
    {
        public int CalculateFail(string s)
        {
            //太久
            string temp = "";
            var TableData = new List<string>();
            var Priority = false;
            foreach (var item in s)
            {
                if (item == 32) //=' '
                {
                    continue;
                }
                if (Int32.TryParse(item.ToString(), out _))
                {
                    temp += item;
                }
                else if (!Int32.TryParse(item.ToString(), out _))
                {
                    if (item == '*' || item == '/')
                    {
                        switch (Priority)
                        {
                            case true:
                                TableData.Add(temp);
                                TableData.Add(item.ToString());
                                break;
                            case false:
                                TableData.Add("(");
                                TableData.Add(temp);
                                TableData.Add(item.ToString());
                                Priority = true;
                                break;
                        }
                    }
                    else
                    {
                        TableData.Add(temp);
                        if (Priority == true)
                        {
                            TableData.Add(")");
                        }
                        TableData.Add(item.ToString());
                        Priority = false;
                    }
                    temp = "";
                }
            }
            TableData.Add(temp);
            if (Priority == true)
            {
                TableData.Add(")");
            }
            while (TableData.Count > 1)
            {
                int StartIndex = TableData.IndexOf("(");
                int EndIndex = TableData.IndexOf(")");
                int tempNum = 0;
                if (StartIndex == -1)
                {
                    switch (TableData[1])
                    {
                        case "+":
                            tempNum = Int32.Parse(TableData[0]) + Int32.Parse(TableData[2]);
                            break;
                        case "-":
                            tempNum = Int32.Parse(TableData[0]) - Int32.Parse(TableData[2]);
                            break;
                    }
                    TableData[0] = tempNum.ToString();
                    TableData.RemoveRange(1, 2);
                }
                else
                {
                    tempNum = Int32.Parse(TableData[StartIndex + 1]);
                    for (int i = StartIndex; i < EndIndex - 2; i += 2)
                    {
                        switch (TableData[i + 2])
                        {
                            case "*":
                                tempNum = tempNum * Int32.Parse(TableData[i + 3]);
                                break;
                            case "/":
                                tempNum = tempNum / Int32.Parse(TableData[i + 3]);
                                break;
                        }
                    }
                    TableData[StartIndex] = tempNum.ToString();
                    TableData.RemoveRange(StartIndex + 1, EndIndex - StartIndex);
                }
            }
            return Int32.Parse(TableData[0]);
        }
        public int Calculate(string s)
        {
            var nums = new List<int>();
            char Operator = '+';
            int Current = 0;
            int pos = 0;
            while (pos < s.Length)
            {
                if (s[pos] == ' ')
                {
                    pos++;
                    continue;
                }
                while (pos < s.Length && Int32.TryParse(s[pos].ToString(), out _))
                {
                    Current = Current * 10 + (s[pos] - '0');
                    pos++;
                }
                if (pos >= s.Length) break;
                if (Operator == '+' || Operator == '-')
                {
                    nums.Add(Current * (Operator == '+' ? 1 : -1));
                }
                else if (Operator == '*')
                {
                    nums[nums.Count - 1] = nums.Last() * Current;
                }
                else if (Operator == '/')
                {
                    nums[nums.Count - 1] = nums.Last() / Current;
                }
                Current = 0;
                if (pos + 2 < s.Length)
                {
                    Operator = s[pos + 2];
                    pos++;
                }
                else
                {
                    break;
                }
            }
            return nums.Sum(x => x);
        }
        public int CalculateFail2(string s)
        {
            //前綴行不通
            var Sign = new Stack<char>();
            var Num = new Stack<int>();
            foreach (char c in s.Reverse())
            {
                if (c == 32) //=' '
                {
                    continue;
                }
                if (Int32.TryParse(c.ToString(), out int temp))
                {
                    Num.Push(temp);
                }
                else
                {
                    Sign.Push(c);
                }
            }
            int temp2;
            while (Sign.Count > 0)
            {
                int num1 = Num.Pop();
                int num2 = Num.Pop();
                switch (Sign.Pop())
                {
                    case '+':
                        temp2 = num1 + num2;
                        Num.Push((int)temp2);
                        break;
                    case '-':
                        temp2 = num1 - num2;
                        Num.Push((int)temp2);
                        break;
                    case '*':
                        temp2 = num1 * num2;
                        Num.Push((int)temp2);
                        break;
                    case '/':
                        temp2 = num1 / num2;
                        Num.Push((int)temp2);
                        break;
                }
            }
            return Num.Pop();
        }
        public int Calculate2(string s)
        {
            var Sign = new List<char>();
            var Num = new List<int>();
            s = s.Replace(" ", "");
            var Candidate = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Int32.TryParse(s[i].ToString(), out _))
                {
                    Candidate = Candidate + s[i];
                }
                else if (s[i] == '*' || s[i] == '/')
                {
                    int Start = Int32.Parse(Candidate);
                    while (i < s.Length && (s[i] == '*' || s[i] == '/'))
                    {
                        int j = i + 1;
                        while (j < s.Length && Int32.TryParse(s[j].ToString(), out _))
                        {
                            j++;
                        }
                        switch (s[i])
                        {
                            case '*':
                                Start = Start * Int32.Parse(s.Substring(i + 1, j - i - 1));
                                break;
                            case '/':
                                Start = Start / Int32.Parse(s.Substring(i + 1, j - i - 1));
                                break;
                        }
                        i = j;
                    }
                    if (i < s.Length)
                    {
                        Sign.Add(s[i]);
                    }
                    Num.Add(Start);
                    Candidate = "";
                }
                else
                {
                    Num.Add(Int32.Parse(Candidate));
                    Sign.Add(s[i]);
                    Candidate = "";
                }
            }
            if(Int32.TryParse(Candidate,out int temp))
            {
                Num.Add(temp);
            }
            while (Sign.Count > 0)
            {
                switch (Sign[0])
                {
                    case '+':
                        Num[0] = Num[0] + Num[1];
                        break;
                    case '-':
                        Num[0] = Num[0] - Num[1];
                        break;
                }
                Sign.RemoveRange(0, 1);
                Num.RemoveRange(1, 1);
            }
            return Num[0];
        }
    }
}
