using System;
namespace Timers
{
    public class Timer
    {
        public Timer()
        {
            
        }

        private System.Timers.Timer interval;
        private ITime time;
        
        public event EventHandler<TimerEventArgs> TimeChange;
        public EventHandler TimerStop;
        public EventHandler TimerStart;
        public void SetTime(ITime time) {
            this.time = time;
            TimeChange(this, new TimerEventArgs() { Time = time });
        }

        public void Stop()
        {
            interval.Stop();
            TimerStop(this, EventArgs.Empty);
        }

        public void Start()
        {
            Console.WriteLine(CalculateFutureDate(new int[] { 0, 0, 5 }).ToString());
            interval = SetInterval.SetInterval.setInterval(() =>
            {
                Console.WriteLine("Timer");
            }, 1000);
            
            TimerStart(this, EventArgs.Empty);
        }
        
        private int[] SubtractDates(DateTime future, DateTime now)
        {
            int[] time = new int[3];
            time[0] = future.Hour - now.Hour;
            time[1] = future.Minute - now.Minute;
            time[2] = future.Second - now.Second;
            if (time[0] < 0)
            {
                time[0] += 24;
                time[1]--;
            }
            if (time[1] < 0)
            {
                time[1] += 60;
                time[2]--;
            }
            if (time[2] < 0)
            {
                return new int[3] {-1, -1, -1};
            }
            return time;
        }

        private DateTime CalculateFutureDate(int[] time)
        {
            DateTime future = DateTime.Now;
            future = future.AddHours(time[0]);
            future = future.AddMinutes(time[1]);
            future = future.AddSeconds(time[2]);
            return future;
        }

    }

    public class TimerEventArgs : EventArgs
    {
        public ITime Time { get; set; }
    }

    public interface ITime
    {
        int hours { get; set; }
        int minutes { get; set; }
        int seconds { get; set; }
    }
}
