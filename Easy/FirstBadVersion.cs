using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class FirstBadVersion : VersionControl
    {
        public int FirstBadVersionSlowest(int n)
        {
            while (n > -1)
            {
                if (IsBadVersion(n))
                {
                    n--;
                }
                else
                {
                    return n + 1;
                }
            }
            return -1;
        }
        public int FirstBadVersionFail(int n)
        {
            if (n % 2 == 1)
            {
                n = n + 1;
            }
            int Ntemp = n / 2;
            int Nhead = 0;
            while (Ntemp > -1)
            {
                if (Ntemp - Nhead == 1 && Nhead != 0 || Ntemp == Nhead)
                {
                    return Ntemp;
                }
                else if (n - Ntemp == 1)
                {
                    if (IsBadVersion(n) && !IsBadVersion(Ntemp))
                    {
                        return n;
                    }
                    else
                    {
                        return Ntemp;
                    }
                }
                if (IsBadVersion(Ntemp) == true)
                {
                    Ntemp = (Ntemp + Nhead) / 2;
                    Nhead = Ntemp;
                }
                else
                {
                    Ntemp = (Ntemp + n) / 2;
                }
            }
            return -1;
        }
        public int FirstBadVersionFail2(int n)
        {
            //1:true->true
            //2:true->false
            //3:false->false
            int Ntemp;
            if (n % 2 == 1)
            {
                Ntemp = (n + 1) / 2;
            }
            else
            {
                Ntemp = n / 2;
            }
            int Nhead = 0;
            bool FirstCheck = false;
            while (n > -1)
            {
                if (Nhead > 0)
                {
                    if (Nhead == 1 && Ntemp == 1)
                    {
                        return Ntemp;
                    }
                    if ((Ntemp + 1 == n || Nhead + 1 == Ntemp) && FirstCheck)
                    {
                        if (IsBadVersion(n) == IsBadVersion(Ntemp))
                        {
                            return Ntemp;
                        }
                        else
                        {
                            return n;
                        }
                    }
                }
                FirstCheck = true;
                if (IsBadVersion(Ntemp))
                {
                    if ((Ntemp + Nhead) % 2 == 1)
                    {
                        Ntemp = (Ntemp + Nhead + 1) / 2;
                    }
                    else
                    {
                        Ntemp = (Ntemp + Nhead) / 2;
                    }
                }
                else
                {
                    Nhead = Ntemp;
                    if ((Ntemp + n) % 2 == 1)
                    {
                        Ntemp = (Ntemp + n + 1) / 2;
                    }
                    else
                    {
                        Ntemp = (Ntemp + n) / 2;
                    }
                }
            }
            return -1;
        }
        public int FirstBadVersion1(int n)
        {
            if (n == 1)
            {
                return n;
            }
            int Nhead = 1;
            int Nend = n;
            while (Nhead < n)
            {
                int Nmid = Nhead / 2 + Nend / 2;//防止溢位
                if (IsBadVersion(Nmid))
                {
                    Nend = Nmid;
                }
                else if (!IsBadVersion(Nmid) && IsBadVersion(Nmid + 1))
                {
                    return Nmid + 1;
                }
                else
                {
                    Nhead = Nmid + 1;
                }
            }
            if (Nhead != n && IsBadVersion(Nhead))
            {
                return Nhead;
            }
            return -1;
        }
    }

    public class VersionControl
    {
        public bool IsBadVersion(int version)
        {
            const int Ver = 2;
            if (version >= Ver)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
