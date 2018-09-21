using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Solution
{
    class Payload
    {
        public int Content { get; private set; }

        public Payload(int c)
        {
            Thread.Sleep(1000); // emulate costly resource acquisition
            Content = c;
        }
    }

    class Solution
    {

        // Make GetSingleValue() thread safe. Retain the creation of val in the method. 
        // Make the critical section as short as possible, 
        // as well as the overall running time of the program.
        static Payload val = null;

        public static Payload GetSingleValue(int i)
        {
            lock(val)
            if (val == null)
            {
                val = new Payload(i);
            }
            return val;
        }

        static void Main(string[] args)
        {
            TextWriter tw = null;
            try
            {
                string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
                tw = new StreamWriter(@fileName, true);

                int count = 0;
                if (!Int32.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    tw.WriteLine("Incorrect input.");
                    return;
                }
                int[] res = new int[count];

                Parallel.For(0, count, (i) =>
                {
                    res[i] = GetSingleValue(i).Content;
                });

                var ok = true;
                for (var i = 1; i < count; i++)
                {
                    if (res[i] != res[i - 1])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    tw.WriteLine("This solution appears to be thread-safe.");
                }
                else
                {
                    tw.WriteLine("This solution is NOT thread-safe.");
                }
            }
            finally
            {
                if (tw != null)
                {
                    tw.Flush();
                    tw.Close();
                }
            }
        }
    }
}