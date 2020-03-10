using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DemoEvent
{
    public class Car
    {
        private int CurrSpeed { get; set; }
        private int MaxSpeed { get; set; }

        public Car(int maxspeed)
        {
            CurrSpeed = 0;
            MaxSpeed = maxspeed;
        }

        public override string ToString()
        {
            return "current speed = "+ CurrSpeed;
        }
        public void Accelerate()
        {
            CurrSpeed += 10; // la voiture accélère de 10 km/h
            if (Math.Abs(CurrSpeed - MaxSpeed) < 10)
            {
                if (CarAboutToBlow != null)
                {
                    CarAboutToBlow(this, new CarEngineEventArgs(CurrSpeed));
                }
            }
            else if (CurrSpeed > MaxSpeed && CarExploded != null)
            {
                CarExploded(this, new CarEngineEventArgs(CurrSpeed));
            }
        }

        // définition des événements pouvant se produire
        public event CarEngineProblem CarAboutToBlow;
        public event CarEngineProblem CarExploded;
    }

    // définition du délégué décrivant le modèle de handler appelé en cas d'événement
    public delegate void CarEngineProblem(object sender,CarEngineEventArgs e);
}
