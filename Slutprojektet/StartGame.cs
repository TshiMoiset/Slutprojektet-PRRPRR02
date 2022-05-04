using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class StartGame
    {
        public void lauchGame()
        {

            Tamagotchi tamagotchi = "";
            int answerInt = 0;
            string answer = "";
            string food = "";

            tamagotchiChoise(tamagotchi);

            tamagotchi.name = "";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
            Console.WriteLine("Notera att vi kommer välja namn åt din Tamagotchi om du inte väljer.");
            Console.Write("Tamagotchi namn: ");
            tamagotchi.name = Console.ReadLine().ToUpper();
            Console.Clear();

            if (tamagotchi.name == " ")
            {
                /*int i = tamagotchi.randomNumber.Next(tamagotchi.tamagotchiNames.Length);
                tamagotchi.name = tamagotchi.tamagotchiNames[i];*/
            }

            // Hämtar värdet av isAlive. Om isAlive är true körs loopen. Behöver loopen för att köra spelet. 
            while (tamagotchi.GetAlive())
            {
                Console.Clear();
                Console.Write($"Namn: {tamagotchi.name} || ");
                tamagotchi.printStats();
                Console.WriteLine();
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine($"1. Lär {tamagotchi.name} ett nytt ord.");
                Console.WriteLine($"2. Hur många ord kan {tamagotchi.name}?");
                Console.WriteLine($"3. Hälsa på {tamagotchi.name}.");
                Console.WriteLine($"4. Mata {tamagotchi.name}.");
                Console.WriteLine($"5. Göra ingenting.");
                Console.WriteLine();
                answer = Console.ReadLine();

                // Gör om stringen till en in. Om användaren svara med en int som är störren än 6 går inte spelet vidare.
                while (!int.TryParse(answer, out answerInt) || answerInt >= 6)
                {
                    Console.Clear();
                    Console.Write($"Namn: {tamagotchi.name} || ");
                    tamagotchi.printStats();
                    Console.WriteLine();
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine($"1. Lär {tamagotchi.name} ett nytt ord.");
                    Console.WriteLine($"2. Hur många ord kan {tamagotchi.name}?");
                    Console.WriteLine($"3. Hälsa på {tamagotchi.name}.");
                    Console.WriteLine($"4. Mata {tamagotchi.name}.");
                    Console.WriteLine($"5. Göra ingenting.");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det där är inte ett giltigt svar!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Välj ett alternativ mellan 1-5, Försök igen!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Okej, Då väljer jag: ");
                    answer = Console.ReadLine();
                }

                // Om användaren svara 1 körs koden. Man lär tamagotchin något
                if (answer == "1")
                {
                    Console.Clear();
                    Console.Write($"Lär {tamagotchi.name} ett nytt ord: ");
                    string wordAnswer = Console.ReadLine();
                    tamagotchi.teach(wordAnswer);
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    Console.Clear();
                }

                // Om användaren svara 2 körs koden. Koden hämtar information från metoden. I metoden finns en for loop som loopar igenom listan och skriver ut allt.  
                if (answer == "2")
                {
                    tamagotchi.showWords();
                    Console.ReadLine();
                    Console.Clear();
                }

                // Om användaren svara 3 körs koden. Man hälsar på tamagotchin. Tamagothin kommer svara med en random hälsningfras som finns i en array.  
                if (answer == "3")
                {
                    Console.WriteLine($"Säg något till {tamagotchi.name}.");
                    Console.WriteLine("Tryck sedan på [ENTER] för att fortsätta!");
                    Console.WriteLine();
                    Console.ReadLine();
                    tamagotchi.hi();
                    Console.ReadLine();
                }

                // Om användaren svara 4 körs koden. Man skriver vad tamagotchin ska äta. 
                if (answer == "4")
                {
                    Console.Clear();
                    Console.WriteLine($"Vad ska {tamagotchi.name} äta?");
                    Console.Write($"{tamagotchi.name} ska äta: ");
                    food = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    Console.Write($"Meddelande från {tamagotchi.name}: ");
                    Console.WriteLine("Tack för maten :), Var det här en invandrar eller vit måltid?");
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    Console.WriteLine();
                    tamagotchi.feed();
                }

                // Om användaren svara 5. Man gör ingenting och därför hämtas information från tick och boredom och hunger går up.
                if (answer == "5")
                {
                    tamagotchi.tick();
                }
            }
        }

        Tamagotchi tamagotchiChoise(Tamagotchi tamagotchi)
        {
            string answer = "";

            Console.WriteLine("Ska din tamago vara vuxen eller barn");
            if (answer == "vuxen")
            {
                tamagotchi = new FatherTamagotchi();
                return tamagotchi;
            }

            else if (answer == "barn")
            {
                tamagotchi = new TeenTamagotchi();
                return tamagotchi;

            }

        }
    }
}

