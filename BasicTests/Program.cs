using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ComparisonWithPython();
        }

        private static void ComparisonWithPython()
        {
            Console.Write(String.Join(",", Enumerable.Range(0, 5).Select(x => (x, x ^ 2))));
            Console.Read();
        }

        private static void ObservableCollectionTests()
        {
            //After a removal it always tightens the collection
            var collection = new ObservableCollection<int>();
            Enumerable.Range(1, 10).ToList().ForEach(number => collection.Add(number));
            collection.Move(9, 0);
            collection.Move(8, 3);
        }

        private static void FibonacciTests()
        {
            int number = 7;
            Console.WriteLine($"FibonacciRecursion of {number} is: {FibonacciRecursion(number)}");
            Console.WriteLine($"FibonacciDynamic of {number} is: {FibonacciDynamic(number)}");
            Console.WriteLine($"FibonacciBottomUp of {number} is: {FibonacciBottomUp(number)}");
        }

        private static int[] tab;

        private static int FibonacciRecursion(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
            }
        }

        private static int FibonacciDynamic(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            tab = new int[n];
            //int[] tab = new int[n];
            tab[0] = tab[1] = 1;
            int result = FibDyn(n);
            return result;
        }

        private static int FibDyn(int n)
        {
            if (tab[n - 1] != 0)
                return tab[n - 1];
            else
            {
                tab[n - 1] = FibDyn(n - 1) + FibDyn(n - 2);
                return tab[n - 1];
            }
        }

        private static int FibonacciBottomUp(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            tab = new int[n];
            tab[0] = tab[1] = 1;

            for (int i = 0; i < n; i++)
            {
                if (tab[i] == 0)
                {
                    tab[i] = tab[i - 1] + tab[i - 2];
                }
            }
            return tab[n - 1];
        }

        private static int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private static void ObjectInjectionNullCheck()
        {
            A a;
            var b = new B();
            ICollection<int> col = new List<int>();
            //This is not allowed
            //b.InitializeA(a);
        }


        public class ParalelLoopsTest
        {
            List<int> _values;
            private int _size;

            public ParalelLoopsTest(int size)
            {
                _size = size;
            }
            private void InitiliazeVariables()
            {
                _values = new List<int>();
                for (int i = 0; i < _size; i++)
                {
                    _values.Add(0);
                }
            }

            public long TestRegular()
            {
                InitiliazeVariables();
                var timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < _values.Count; i++)
                {
                    _values[i]++;
                }
                timer.Stop();
                return timer.ElapsedMilliseconds;
            }

            public long TestParalel()
            {
                InitiliazeVariables();
                var timer = new Stopwatch();
                timer.Start();
                Parallel.For(0, _values.Count - 1, val => val++);
                timer.Stop();
                return timer.ElapsedMilliseconds;
            }
        }

        class A
        {

        }

        class B
        {
            public void InitializeA(A a)
            {
                a = new A();
            }
        }


        public static void PassingFuncs()
        {
            Circle circle = new Circle();
            double radius1 = circle.Calculate(GetCircumference);
            double radius2 = circle.Calculate(r => 2 * Math.PI * r);
            double radius3 = circle.Calculate(delegate (double r)
            {
                return 2 * Math.PI * r;
            });
            Console.WriteLine($"radius1: {radius1}, radius2: {radius2}, radius3: {radius3}");
        }

        private static void HexFunctions()
        {
            DateTime dt = new DateTime(2017, 09, 04, 20, 30, 05, 600);
            byte[] dateTimeBytes = new byte[9] { 0x17, 0x2B, 0x59, 0x80, 0x14, 0x11, 0x08, 0x15, 0x00 };
            byte[] withoutCRC = new byte[9] { 0x02, 0x00, 0x0B, 0x00, 0x22, 0x92, 0x71, 0x00, 0x00 };
            byte[] withoutCRC2 = new byte[] { 0x02, 0x00, 0x09, 0xFF, 0x22, 0x00, 0xFF };
            ushort hex = Crc16.ComputeChecksum(withoutCRC);
            ushort hex2 = Calc(withoutCRC);
            byte[] hex3 = CalculateCRC16(withoutCRC2);
            //Console.WriteLine($"0x{hex3[0].ToString("X")} 0x{hex3[1].ToString("X")}");
            //ushort hex3 = CalculateCRC16(withoutCRC);
            //Console.WriteLine(hex.ToString("x2"));
            byte[] b = DateTimeToBytes(dt);

            dt = BytesToDateTime(b);
            Console.WriteLine(dt.ToString("dd.MM.yyyy HH:mm:ss.fff"));
        }

        public static DateTime BytesToDateTime(byte[] bytes)
        {
            if (bytes.Length != 9)
            {
                throw new ArgumentException();
            }
            int hours = Convert.ToInt32(bytes[0]);
            int minutes = Convert.ToInt32(bytes[1]);
            long totalMiliseconds = Convert.ToInt32(bytes[2] * 256 + Convert.ToInt32(bytes[3]));
            int seconds = (int)(totalMiliseconds / 1000);
            int miliseconds = (int)(totalMiliseconds - seconds * 1000);
            int year = Convert.ToInt32(bytes[4]) * 100 + Convert.ToInt32(bytes[5]);
            int month = Convert.ToInt32(bytes[6]);
            int day = Convert.ToInt32(bytes[7]);
            return new DateTime(year, month, day, hours, minutes, seconds, miliseconds);
        }

        public static byte[] DateTimeToBytes(DateTime dt)
        {
            byte[] message = new byte[9];
            message[0] = (byte)dt.Hour;
            message[1] = (byte)dt.Minute;
            long totalMiliseconds = dt.Second * 1000 + dt.Millisecond;
            message[2] = (byte)(totalMiliseconds / 256);
            message[3] = (byte)(totalMiliseconds - 256 * message[2]);
            message[4] = (byte)(dt.Year / 100);
            message[5] = (byte)(dt.Year - message[4] * 100);
            message[6] = (byte)dt.Month;
            message[7] = (byte)dt.Day;
            message[8] = 0x00;
            return message;
        }

        private static byte[] CalculateCRC16(byte[] data)
        {
            ushort crcPolynom = 0x8408;
            ushort crcPreset = 0xFFFF;

            ushort crc = crcPreset;
            for (int i = 0; i < data.Length; i++)
            {
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                        crc = (ushort)((crc >> 1) ^ crcPolynom);
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            return new byte[] { (byte)(crc - 256 * (crc / 256)), (byte)(crc / 256) };
        }

        private static ushort Calc(byte[] data)
        {
            ushort wCRC = 0xFFFF;
            for (int i = 0; i < data.Length; i++)
            {
                wCRC ^= (ushort)(data[i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCRC & 0x8000) != 0)
                        wCRC = (ushort)((wCRC << 1) ^ 0x8408);
                    else
                        wCRC <<= 1;
                }
            }
            return wCRC;
        }

        private static void Extensions()
        {
            string x = "Some string";
            Console.WriteLine(x.Reverse());
        }

        private static double GetCircumference(double r) => 2 * Math.PI * r;
    }
    public static class Crc16
    {
        const ushort polynomial = 0x8408;
        static readonly ushort[] table = new ushort[256];

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        static Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }

    public static class StringUtility
    {
        public static string Reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }

    public sealed class Circle
    {
        private double radius = 5.0;

        public double Calculate(Func<double, double> op)
        {
            return op(radius);
        }
    }

}
