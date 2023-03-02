using System;

namespace _11_DemoEvent
{
    public class Car
    {
        // définition du délégué décrivant le modèle de handler appelé en cas d'événement
        public delegate void CarEngineProblem(object sender, CarEngineEventArgs e);
     
        // définition des événements pouvant se produire
        public event CarEngineProblem CarAboutToBlow;
        public event CarEngineProblem CarExploded;
        private int CurrSpeed { get; set; }
        private int MaxSpeed { get; set; }
        public bool Exploded { get; set; }

        public Car(int maxspeed)
        {
            CurrSpeed = 0;
            MaxSpeed = maxspeed;
        }

        public void Accelerate()
        {
            CurrSpeed += 10; // la voiture accélère de 10 km/h
            if (Math.Abs(CurrSpeed - MaxSpeed) < 10)
            {
                if (CarAboutToBlow != null) 
                    NotifyAboutToBlow();
            }
            else
            {
                if (CurrSpeed <= MaxSpeed) 
                    return;
                Exploded = true;
                NotifyExploded();
            }
        }

        private void NotifyExploded()
        {
            ConsoleEx.WriteLine("-->  Sending CarExploded", ConsoleColor.Red);
            CarExploded?.Invoke(this, new CarEngineEventArgs(CurrSpeed));
            ConsoleEx.WriteLine("<--  CarExploded send", ConsoleColor.Red);
        }

        private void NotifyAboutToBlow()
        {
            ConsoleEx.WriteLine("-->  Sending CarAboutToBlow", ConsoleColor.Magenta);
            if (CarAboutToBlow != null)
                foreach (CarEngineProblem dg in CarAboutToBlow.GetInvocationList())
                    dg.BeginInvoke(this, new CarEngineEventArgs(CurrSpeed), Callback, CurrSpeed);
            ConsoleEx.WriteLine("<--  CarAboutToBlow sended", ConsoleColor.Magenta);
        }

        private void Callback(IAsyncResult ar)
        {
            ConsoleEx.WriteLine($"<--  CarAboutToBlow Callback : {ar.AsyncState}", ConsoleColor.Cyan);
        }

        public override string ToString()
        {
            return "current speed = " + CurrSpeed;
        }
    }
}
