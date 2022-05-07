using Microsoft.VisualBasic;
using System;

namespace Slutprojektet
{
    public class TeenCar : Car
    {
        string CarName = "Aixam";
        string CarModel = "Aixam-A.777";
        string RegistrationPlate = "HGV 168";
        int Gas = 16;
        int Speed = 45;
        int CarQuality = 80;

        Random randomNumber = new Random();

        public override void carStats()
        {
            Console.Write($"Namn: {CarName} || Model: {CarModel} || Reg Nr: {RegistrationPlate}");
            Console.Write($"|| Bensin: {Gas}L || Fart: {Speed} km/h || Kavlité: {CarQuality} ||");
        }

        public override void useCar()
        {
            Gas -= randomNumber.Next(1, 4);
            CarQuality -= randomNumber.Next(1, 8);

            if (gas == 0)
            {
                Console.WriteLine("Bensinen är slut");
            }
            else if (carQuality == 0)
            {
                Console.WriteLine("Bilen fungerar inte längre.");
            }
        }
    }
}