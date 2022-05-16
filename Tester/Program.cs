using System;
using Timers;
namespace Tester
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Timer();
            var count = 0;
            timer.TimerStart += (sender, e) => Console.WriteLine("Timer started");
            timer.TimeChange += (sender, e) => Console.WriteLine("Time changed");
            timer.TimerStop += (sender, e) => Console.WriteLine("Timer stopped");
            timer.Start();
            
            while (true) ;
        }
    }
}
