using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DemoEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car(100);
            // Programme de test de la voiture qui accélère par pas de 10 km/h.
            Console.WriteLine("TEST 1 : La voiture accèlère par pas de 10 km/h, aucune information fournie"); 
            for (int i = 0;i < 15;i++)
            {
                c.Accelerate();
                Console.WriteLine("current speed = {0}", c.ToString());
            }

            // la voiture se prépare à réagir aux événements produits            
            Console.ReadKey();
            try
            { 
                Car c1 = new Car(100);
                c1.CarAboutToBlow += c_CarAboutToBlow;
                c1.CarExploded += c_CarExploded;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("TEST 2 : La voiture accèlère par pas de 10 km/h, informations pertinentes fournies");
                // Programme de test de la voiture qui accélère par pas de 10 km/h.
                for (int i = 0; i < 15; i++)
                {
                    c1.Accelerate();
                    Console.WriteLine("current speed = {0}", c1.ToString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static void c_CarExploded(object sender, CarEngineEventArgs e)
        {
            Console.WriteLine("Dommage, la voiture a explosé, elle roulait à {0}km/h", e.CurrSpeed);
            throw new Exception("Please Stop Car !!!!");
        }

        static void c_CarAboutToBlow(object sender, CarEngineEventArgs e)
        {
            Console.WriteLine("La voiture risque d'exploser, elle roule à {0}km/h",e.CurrSpeed);
        }
    }
}
