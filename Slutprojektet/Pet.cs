using System;

namespace Slutprojektet
{
    public class Pet : Creature
    {
        public override void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vid Liv: {isAlive} || ");
        }

        public override void tick()
        {
            hunger += randomNumber.Next(1, 3);
            boredom += randomNumber.Next(1, 3);
            if (boredom > 13 || hunger > 13)
            {
                isAlive = false;
                Console.WriteLine();
                Console.WriteLine("Ditt husdjur dog.");
                Console.WriteLine("Tryck på [ENTER] för att fortsätta");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}