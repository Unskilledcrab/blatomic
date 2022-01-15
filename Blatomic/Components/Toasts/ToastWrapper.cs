using System.Timers;

namespace Blatomic.Components.Toasts
{
    public class ToastWrapper : IDisposable
    {
        public ToastWrapper(Toast toast)
        {
            Toast = toast;
            var headerWords = toast.Header.Split(' ').Length;
            var messageWords = toast.Message.Split(' ').Length;
            ReadTime = ((headerWords + messageWords) * 250) + 4000;

            timer = new System.Timers.Timer(tickTime)
            {
                AutoReset = true,
                Enabled = true
            };

            timer.Elapsed += TimerTick;
        }

        private readonly double tickTime = 100;
        public Toast Toast { get; set; }
        public bool IsShowing { get; set; } = true;
        public event ElapsedEventHandler? OnElapsed;
        public event ElapsedEventHandler? OnTick;
        private System.Timers.Timer timer;
        public readonly int ReadTime;
        private double tickCount = 0;
        private double totalTicks => ReadTime / tickTime;
        public double PercentageComplete => 100 - (percentage * 100);
        private double percentage => tickCount / totalTicks;

        private void TimerTick(object? sender, ElapsedEventArgs e)
        {
            tickCount++;

            if (tickCount >= totalTicks)
            {
                IsShowing = false;
                OnElapsed?.Invoke(this, e);
            }

            OnTick?.Invoke(this, e);
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public void StartTimer()
        {
            timer.Start();
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
