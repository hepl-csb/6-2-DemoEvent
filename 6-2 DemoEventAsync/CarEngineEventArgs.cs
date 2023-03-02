using System;

namespace _11_DemoEvent
{
    // définition d'une classe EventArgs qui contient les infos envoyées au programme principal lorsque l'événement est produit
    public class CarEngineEventArgs : EventArgs
    {
        public int CurrSpeed { get; set; }
        public CarEngineEventArgs(int currspeed)
        {
            CurrSpeed = currspeed;
        }
    }
}
