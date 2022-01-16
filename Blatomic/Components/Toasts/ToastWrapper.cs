using System.Timers;

namespace Blatomic.Components.Toasts
{
    public class ToastWrapper
    {
        public ToastWrapper(Toast toast)
        {
            Toast = toast;
            var headerWords = toast.Header.Split(' ').Length;
            var messageWords = toast.Message.Split(' ').Length;
            ReadTime = ((headerWords + messageWords) * 250) + 4000;
        }

        public Toast Toast { get; set; }
        public double PercentageComplete => 100 - (percentage * 100);

        public event ElapsedEventHandler? OnElapsed;
        public readonly int ReadTime;
        private double totalTicks => ReadTime / ToastContainer.ToastTickRate;
        private double percentage => tickCount / totalTicks;
        private double tickCount = 0;

        public void TimerTick(object? sender, ElapsedEventArgs e)
        {
            tickCount++;

            if (tickCount >= totalTicks)
            {
                OnElapsed?.Invoke(this, e);
            }
        }
    }
}
