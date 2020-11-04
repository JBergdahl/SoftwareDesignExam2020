using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PG3302
{
    public abstract class ThreadProxy
    {
        protected Thread _thread;
        protected bool _running;

        public Thread Thread { get => _thread; }
        public bool IsAlive { get => _thread.IsAlive; }
        public bool Running { get => _running; }

        protected ThreadProxy()
        {
            //_thread = new Thread(new ThreadStart(ThreadLoop));
            _thread = new Thread(() => ThreadLoop());
            _running = false;
        }

        protected abstract void Task();

        protected void ThreadLoop()
        {
            while (_running)
            {
                Task();
            }
        }

        public void Start(string playerName)
        {
            _running = true;
            Console.WriteLine("Starting " + playerName);
            _thread.Start();
        }

        public void Stop()
        {
            _running = false;
            _thread.Join();
        }
    }
}
