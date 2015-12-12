namespace P3_Asynchronous_Timer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;
    using P2_Interest_Calculator;

    public class AsyncTimer : IAsyncTimer
    {
        private const string ERROR_TIMER_RUNNING = "Cannot change values while the timer is running";

        private int count;
        private int interval;
        private Action callback;

        private CancellationTokenSource cancellation;
        private Task timerTask;

        public AsyncTimer(int count, int interval, Action callback)
        {
            this.Count = count;
            this.Interval = interval;
            this.Callback = callback;
        }

        [MinValue(0, inclusive: false)]
        public int Count
        {
            get
            {
                return this.count;

            }

            set
            {
                if (this.IsRunning)
                {
                    throw new InvalidOperationException(ERROR_TIMER_RUNNING);
                }

                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Count)
                });

                this.count = value;
            }
        }

        [MinValue(0, inclusive: false)]
        public int Interval
        {
            get
            {
                return this.interval;

            }

            set
            {
                if (this.IsRunning)
                {
                    throw new InvalidOperationException(ERROR_TIMER_RUNNING);
                }

                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Interval)
                });

                this.interval = value;
            }
        }

        public bool IsRunning
        {
            get
            {
                bool isStopped = this.timerTask == null || this.timerTask.IsCompleted
                       || this.timerTask.IsCanceled || this.timerTask.IsFaulted;

                return !isStopped;
            }
        }

        public Action Callback
        {
            get
            {
                return this.callback;

            }

            set
            {
                if (this.IsRunning)
                {
                    throw new InvalidOperationException(ERROR_TIMER_RUNNING);
                }

                this.callback = value;
            }
        }

        public void Start()
        {
            if (this.IsRunning)
            {
                return;
            }

            this.cancellation = new CancellationTokenSource();
            var ct = this.cancellation.Token;

            this.timerTask = Task.Run(() =>
            {
                while (this.count > 0)
                {
                    ct.ThrowIfCancellationRequested();
                    Thread.Sleep((int)this.Interval);
                    this.Callback();
                    this.count--;
                }
            }, this.cancellation.Token);
        }

        public void Pause()
        {
            if (this.cancellation.Token.CanBeCanceled)
            {
                this.cancellation.Cancel();
            }
        }

        public void Reset(int count, int interval)
        {
            this.Count = count;
            this.Interval = interval;
        }
    }
}