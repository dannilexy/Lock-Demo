using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LockDemo
{
    internal class Program
    {
        private static readonly object locker = new object();
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    lock (locker)
                    {

                        File.AppendAllText(@"C:\Users\me\Downloads\test.txt", "text 1 ");
                        Thread.Sleep(1000);
                        File.AppendAllText(@"C:\Users\me\Downloads\test.txt", "text 2 ");
                    }
                });
            }
            Console.ReadKey();
        }
    }
}
