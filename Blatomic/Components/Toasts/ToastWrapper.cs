using System.Timers;

namespace Blatomic.Components.Toasts
{
    public class ToastWrapper : IDisposable
    {
        public ToastWrapper(Toast toast)
        {
            Toast = toast;
            int readTime = (toast.Message.Length * 80) + 4000;

            timer = new System.Timers.Timer(readTime)
            {
                AutoReset = false,
                Enabled = true
            };

            timer.Elapsed += TimerOver;
        }

        public Toast Toast { get; set; }
        public bool IsShowing { get; set; } = true;
        public event ElapsedEventHandler? Elapsed;
        private System.Timers.Timer timer;

        private void TimerOver(object? sender, ElapsedEventArgs e)
        {
            IsShowing = false;
            Elapsed?.Invoke(this, e);
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
