using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class AdultTamagotchi : Tamagotchi
    {
        Menu goToMenu = new Menu();
        string[] Salutations = { "God dag", "Var hälsad", "Trevligt att råkas", "Fint väder så här års" };
        Queue<int> learnedNumber = new Queue<int>();

        // Skriver ut nuvarande hunger och bredom, och meddelar också huruvida tamagotchin lever.
        public override void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Sifferminne: {learnedNumber.Count} || Ålder: Vuxen || Vid Liv: {isAlive} || ");
        }

        // Ökar hunger och boredom, och om någon av dem kommer över 10 så blir isAlive false.
        public override void tick()
        {
            // Adderar hunger och boredom med en random siffra. 
            Hunger += randomNumber.Next(2, 4);
            Boredom += randomNumber.Next(2, 4);

            // Om boredom och hunger är större än 15 är spelet slut. 
            if (Boredom > 15 || Hunger > 15)
            {
                IsAlive = false;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("Din Tamagotchi har dött.");
                Console.WriteLine("Tryck på [ENTER] för att fortsätta");
                Console.ReadLine();
                Console.Clear();
                goToMenu.RunMenu();
            }
        }

        // public void teachNewNumber()
        // {
        //     for (int i = 0; i < learnedNumber.Count; i++)
        //     {
        //         Console.WriteLine(learnedNumber.Peek());
        //     }
        // }



        // Lägger in siffrorna i Queue:n
        void AddNumbersToQueue()
        {
            learnedNumber.Enqueue(5);
            learnedNumber.Enqueue(20);
            learnedNumber.Enqueue(200);
            learnedNumber.Enqueue(999999);
            learnedNumber.Enqueue(5000);
            learnedNumber.Enqueue(25000);
        }

        public void ShowKnownNumbers()
        {
            AddNumbersToQueue();
            // for (int i = 0; i < learnedNumber.Count; i++)
            // {
            //     Console.WriteLine(learnedNumber.Peek());
            // }

            foreach (var value in learnedNumber)
            {
                Console.WriteLine(value);
            }
        }

        // Skriver ut ett slumpat ord från words, och anropar ReduceBoredom.
        public void hi()
        {
            int pickedSalutation = randomNumber.Next(Salutations.Length);
            Console.WriteLine(Salutations[pickedSalutation]);
            reduceBoredom();
        }
    }
}