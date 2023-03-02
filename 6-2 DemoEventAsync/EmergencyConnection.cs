using System;
using System.Collections;
using System.Threading;

namespace _11_DemoEvent
{
    public class EmergencyConnection
    {
        private readonly ArrayList _ar;
        private bool _running;

        public EmergencyConnection()
        {
            _ar = new ArrayList();
            var thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            _running = true;
            while (_running)
            {
                var syncAr = ArrayList.Synchronized(_ar);

                if (syncAr.Count > 0)
                {
                    ConsoleEx.WriteLine($"      Send emergency notification: {syncAr[0]}", ConsoleColor.Yellow);
                    syncAr.RemoveAt(0);
                    Thread.Sleep(1000);
                    ConsoleEx.WriteLine("      Emergency notification sended", ConsoleColor.Yellow);
                }
                Thread.Sleep(10);
            }
        }


        public void Warning(object sender, CarEngineEventArgs e)
        {
            var syncAr = ArrayList.Synchronized(_ar);
            syncAr.Add($"      WARNING : Thread emergency : {e.CurrSpeed}");
        }

        public void Error(object sender, CarEngineEventArgs e)
        {
            var syncAr = ArrayList.Synchronized(_ar);
            syncAr.Add($"      ERRROR : Thread emergency : {e.CurrSpeed}");
        }

        public void Stop()
        {
            _running = false;
        }

    }
    
}
