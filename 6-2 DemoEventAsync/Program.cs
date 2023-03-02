using System;
using System.Threading;

namespace _11_DemoEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            EmergencyConnection ec = new EmergencyConnection();
            try
            {
                Car c1 = new Car(100);
                c1.CarAboutToBlow += c_CarAboutToBlow;
                c1.CarExploded += c_CarExploded;

                c1.CarAboutToBlow += ec.Warning;
                c1.CarExploded += ec.Error;

                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("TEST 2 : La voiture accèlère par pas de 10 km/h, informations pertinentes fournies");
                for (int i = 0; i < 15; i++)
                {
                    c1.Accelerate();
                    ConsoleEx.WriteLine($"current speed = {c1}", ConsoleColor.White);
                    Thread.Sleep(200);
                    if (c1.Exploded)
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ec.Stop();
            }
            Console.ReadKey();
        }

        static void c_CarExploded(object sender, CarEngineEventArgs e)
        {
            ConsoleEx.WriteLine($"  Dommage, la voiture a explosé, elle roulait à {e.CurrSpeed}km/h", ConsoleColor.Red);
            Thread.Sleep(2000);
            ConsoleEx.WriteLine("  CarExploded Sleep terminé", ConsoleColor.Red);
        }

        static void c_CarAboutToBlow(object sender, CarEngineEventArgs e)
        {
            Console.WriteLine($"  La voiture risque d'exploser, elle roule à {e.CurrSpeed}km/h", ConsoleColor.Magenta);
            Thread.Sleep(2000);
            ConsoleEx.WriteLine("  CarAboutToBlow Sleep terminé", ConsoleColor.Magenta);
        }
    }
}
