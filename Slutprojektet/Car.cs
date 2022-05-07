using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class Car
    {
        protected int gas;
        public int Gas
        {
            get { return gas; }
            set { gas = value; }
        }

        protected int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        protected string carModel;
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        protected string carName;
        public string CarName
        {
            get { return carName; }
            set { carName = value; }
        }

        protected string registrationPlate;
        public string RegistrationPlate
        {
            get { return registrationPlate; }
            set { registrationPlate = value; }
        }

        protected int carQuality;
        public int CarQuality
        {
            get { return carQuality; }
            set { carQuality = value; }
        }

        Random randomNumber = new Random();

        public virtual void carStats()
        {
            Console.Write($"Namn: {carName} || Model: {carModel} || Reg Nr: {registrationPlate}");
            Console.Write($"|| Bensin: {gas} || Fart: {speed} || Kavlité: {carQuality}");
        }

        public virtual void useCar()
        {
            gas -= randomNumber.Next(2, 3);
            carQuality -= randomNumber.Next(1, 8);

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