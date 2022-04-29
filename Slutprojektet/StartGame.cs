using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class StartGame
    {
        public void lauchGame()
        {
            Tamagotchi tamagotchi1 = new Tamagotchi();
            int answerInt = 0;
            string answer = "";
            string food = "";
            tamagotchi1.name = "";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
            Console.WriteLine("Notera att vi komme välja namn åt din Tamagotchi om du inte väljer.");
            Console.Write("Tamagotchi namn: ");
            tamagotchi1.name = Console.ReadLine().ToUpper();
            Console.Clear();

            if (tamagotchi1.name == " ")
            {
                int i = tamagotchi1.randomNumber.Next(tamagotchi1.tamagotchiNames.Length);
                tamagotchi1.name = tamagotchi1.tamagotchiNames[i];
            }

            // Hämtar värdet av isAlive. Om isAlive är true körs loopen. Behöver loopen för att köra spelet. 
            while (tamagotchi1.GetAlive())
            {
                Console.Clear();
                Console.Write($"Namn: {tamagotchi1.name} || ");
                tamagotchi1.printStats();
                Console.WriteLine();
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine($"1. Lär {tamagotchi1.name} ett nytt ord.");
                Console.WriteLine($"2. Hur många ord kan {tamagotchi1.name}?");
                Console.WriteLine($"3. Hälsa på {tamagotchi1.name}.");
                Console.WriteLine($"4. Mata {tamagotchi1.name}.");
                Console.WriteLine($"5. Göra ingenting.");
                Console.WriteLine();
                answer = Console.ReadLine();

                // Gör om stringen till en in. Om användaren svara med en int som är störren än 6 går inte spelet vidare.
                while (!int.TryParse(answer, out answerInt) || answerInt >= 6)
                {
                    Console.Clear();
                    Console.Write($"Namn: {tamagotchi1.name} || ");
                    tamagotchi1.printStats();
                    Console.WriteLine();
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine($"1. Lär {tamagotchi1.name} ett nytt ord.");
                    Console.WriteLine($"2. Hur många ord kan {tamagotchi1.name}?");
                    Console.WriteLine($"3. Hälsa på {tamagotchi1.name}.");
                    Console.WriteLine($"4. Mata {tamagotchi1.name}.");
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
                    Console.Write($"Lär {tamagotchi1.name} ett nytt ord: ");
                    string wordAnswer = Console.ReadLine();
                    tamagotchi1.teach(wordAnswer);
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    tamagotchi1.tick();
                    Console.Clear();
                }

                // Om användaren svara 2 körs koden. Koden hämtar information från metoden. I metoden finns en for loop som loopar igenom listan och skriver ut allt.  
                if (answer == "2")
                {
                    tamagotchi1.showWords();
                }

                // Om användaren svara 3 körs koden. Man hälsar på tamagotchin. Tamagothin kommer svara med en random hälsningfras som finns i en array.  
                if (answer == "3")
                {
                    Console.WriteLine($"Hälsa på {tamagotchi1.name}.");
                    Console.WriteLine("Tryck sedan på [ENTER] för att fortsätta!");
                    Console.WriteLine();
                    Console.ReadLine();
                    tamagotchi1.hi();
                    Console.ReadLine();
                    tamagotchi1.tick();
                }

                // Om användaren svara 4 körs koden. Man skriver vad tamagotchin ska äta. 
                if (answer == "4")
                {
                    Console.Clear();
                    Console.WriteLine($"Vad ska {tamagotchi1.name} äta?");
                    Console.Write($"{tamagotchi1.name} ska äta: ");
                    food = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    Console.Write($"Meddelande från {tamagotchi1.name}: ");
                    Console.WriteLine("Tack för maten :)");
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    Console.WriteLine();
                    tamagotchi1.tick();
                    tamagotchi1.feed();
                }

                // Om användaren svara 5. Man gör ingenting och därför hämtas information från tick och boredom och hunger går up.
                if (answer == "5")
                {
                    tamagotchi1.tick();
                }
            }
        }
    }
}

