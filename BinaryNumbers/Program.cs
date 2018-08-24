using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Probably the best way will be to only change specific bits, all the rest is generated automatically as 0
            bool check = true;
            bool[] frame = new bool[8];
            frame[3] = true;
            string result = "";
            foreach (var bit in frame)
            {
                result += Convert.ToByte(bit);
            }
            byte binaryNumber = Convert.ToByte("10000110", 2);
            byte binaryNumber2 = 0b1000011;
            byte binaryNumber4 = Convert.ToByte(check);
            int first = 0;
            int second = 1;
            int third = 1;
            byte binaryNumber3 = Convert.ToByte($"{third}{second}{first}", 2);
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Result byte: {Convert.ToByte(result, 2)}");
            Console.WriteLine(binaryNumber2);
            Console.WriteLine(binaryNumber3);
            Console.WriteLine(binaryNumber4);
            Console.ReadLine();
        }
    }
}
