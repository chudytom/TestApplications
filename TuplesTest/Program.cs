using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            var t = Tally(numbers);
            Console.WriteLine($"Count: {t.count} Sum:{t.sum}");
        }

        private static (int count, int sum) Tally(int[] numbers)
        {
            var r = (count: 0, sum: 0);
            foreach (var item in numbers)
            {
                Console.WriteLine("I am typing a horrible long string and" +
                    " it is actually gonna take a while before I finish." +
                    " But don't you worry you won't get too bored because" +
                    " I really want to show you something that" +
                    " is very interestin. Are you ready for this now?");
                r.count++;
                r.sum += item;
            }
            return r;
        }
    }
    class AnotherClass
    {
        public AnotherClass(int number)
        {

        }
    }
}
