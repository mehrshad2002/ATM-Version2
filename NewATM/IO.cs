using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewATM
{
    public class IO
    {
        public void Print<E>(E val)
        {
            Console.WriteLine(val);
        }

        public void PrintAt<E>(E val)
        {
            Console.Write(val);
        }

        public string Get()
        {
            string val;
            val = Convert.ToString(Console.ReadLine());
            return val;
        }

        public string GetAt<E>()
        {
            string val;
            val = Convert.ToString(Console.Read());
            return val;
        }
    }
}
