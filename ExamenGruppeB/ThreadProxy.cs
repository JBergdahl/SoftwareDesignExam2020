using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PG3302
{
    public abstract class ThreadProxy
    {
        protected Thread Thread;
        protected bool Running;

        protected ThreadProxy()
        {
            Thread = new Thread(new ThreadStart(ThreadLoop));
            Running = false;
        }

        protected abstract void Task();

        protected void ThreadLoop()
        {
            while (Running)
            {
                Task();
            }
        }

        public void Start(string playerName)
        {
            Running = true;
            Console.WriteLine("Starting " + playerName);
            Thread.Start();
        }

        public void Stop()
        {
            Running = false;
            Thread.Join();
        }
    }
}
