using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDemo
{
    public static class Utils
    {
        public static string Clean(this String str)
        {
            return str.Replace('"', ' ').Trim();
        }
    }
}
