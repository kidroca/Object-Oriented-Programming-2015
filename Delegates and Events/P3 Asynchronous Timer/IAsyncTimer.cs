namespace P3_Asynchronous_Timer
{
    using System;

    public interface IAsyncTimer
    {
        Action Callback { get; set; }

        void Start();
    }
}