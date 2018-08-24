using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesTestOldFramerwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 4, 8, 16, 32 };

            var t = Tally(numbers);
        }

         static (int, int) Tally(int[] numbers)
        {
            throw new NotImplementedException();
        }
    }
}
