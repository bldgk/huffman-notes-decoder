using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanLibrary
{
    public static class Extensions
    {
        public static byte[] ToUTF8(this string s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);

        }
        public static byte[] ToUTF8(this string s, int index, int count)
        {
            return System.Text.Encoding.UTF8.GetBytes(s.Substring(index, count));
        }
        public static string FromUTF8(this byte[] bytes)
        {
            return System.Text.Encoding.UTF8.GetString(bytes);

        }
    }
}
