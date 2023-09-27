using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class Validate_IP_Address
    {
        public string ValidIPAddress(string queryIP)
        {
            if (TypeIPV4(queryIP))
            {
                return "IPv4";
            }
            else if (TypeIPV6(queryIP))
            {
                return "IPv6";
            }
            else
            {
                return "Neither";
            }
        }
        public bool TypeIPV4(string queryIP)
        {
            var SplitIP = queryIP.Split('.');
            if (SplitIP.Length != 4 || SplitIP.Contains("")) return false;
            foreach (var split in SplitIP)
            {
                if ((split[0] == '0' && split.Length != 1) || !Int32.TryParse(split, out int test))
                {
                    return false;
                }
                else if (test > 255 || test < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool TypeIPV6(string queryIP)
        {
            var SplitIP = queryIP.Split(':');
            if (SplitIP.Length != 8 || SplitIP.Contains("")) return false;
            foreach (var split in SplitIP)
            {
                if (split.Length > 4 || !Int32.TryParse(split, System.Globalization.NumberStyles.HexNumber, null, out int test))
                {
                    //Convert.ToInt32(split,16)
                    return false;
                }
                else if (test > 65535 || test < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
