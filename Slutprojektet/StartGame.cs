using System.Security.Cryptography;
using System.Linq;
using System.Dynamic;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class StartGame
    {
        public void lauchGame()
        {
            TeenTamagotchi tamagotchi = new TeenTamagotchi();
            AdultTamagotchi adultTamagotchi;
            Car teenTamagotchiCar = new TeenCar();

            int answerInt = 0;
            string answer = "";
            string food = "";

            while (answer != "vuxen" || answer != "barn")
            {
                Console.WriteLine("Ska din Tamagotchi vara vuxen eller barn?");
                answer = Console.ReadLine().ToLower();
                Console.Clear();

                if (answer != "vuxen" || answer != "barn")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det där är inte ett giltigt alternativ!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Välj vuxen eller barn, försök igen!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (answer == "vuxen")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    adultTamagotchi = new AdultTamagotchi();

                    Console.Clear();
                    Console.WriteLine("Work in progress");
                    Console.ReadLine();
                }

                if (answer == "barn")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    //tamagotchi = new TeenTamagotchi();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
                    Console.WriteLine("Notera att vi kommer välja namn åt din Tamagotchi om du inte väljer.");
                    Console.WriteLine();
                    Console.Write("Tamagotchi namn: ");
                    tamagotchi.name = Console.ReadLine().ToUpper();

                    if (tamagotchi.name == " ")
                    {
                        /*int nameIndex = tamagotchi.randomNumber.Next(tamagotchi.TamagotchiNames.Length);
                        tamagotchi.name = tamagotchi.TamagotchiNames[nameIndex];*/
                        Console.WriteLine(tamagotchi.TamagotchiNames.Length);
                    }

                    runTeenTamagotchi();
                }
            }

            void runTeenTamagotchi()
            {
                // Hämtar värdet av isAlive. Om isAlive är true körs loopen. Behöver loopen för att köra spelet. 
                while (tamagotchi.GetAlive())
                {
                    Console.Clear();
                    Console.Write($"Namn: {tamagotchi.name} || ");
                    tamagotchi.printStats();
                    Console.WriteLine();
                    teenTamagotchiCar.carStats();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine($"1. Lär {tamagotchi.name} ett nytt ord.");
                    Console.WriteLine($"2. Hur många ord kan {tamagotchi.name}?");
                    Console.WriteLine($"3. Hälsa på {tamagotchi.name}.");
                    Console.WriteLine($"4. Mata {tamagotchi.name}.");
                    Console.WriteLine($"5. Göra ingenting.");
                    Console.WriteLine($"6. Åk till stan med {tamagotchi.name}s bil.");
                    Console.WriteLine();
                    answer = Console.ReadLine();

                    // Gör om stringen till en int. Om användaren svara med en int som är störren än 6 går inte spelet vidare.
                    while (!int.TryParse(answer, out answerInt) || answerInt >= 7)
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
                        Console.WriteLine($"6. Åk till stan med {tamagotchi.name}s bil.");
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Det där är inte ett giltigt svar!");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Välj ett alternativ mellan 1-6, Försök igen!");
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
                        tamagotchi.tick();
                        Console.Clear();
                    }

                    // Om användaren svara 2 körs koden. Koden hämtar information från metoden. I metoden finns en for loop som loopar igenom listan och skriver ut allt.  
                    if (answer == "2")
                    {
                        tamagotchi.showWords();
                        Console.WriteLine("Tryck på [ENTER] för att fortsätta");
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
                        tamagotchi.tick();
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
                        Console.WriteLine("Tack för maten :)");
                        Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                        Console.ReadLine();
                        Console.WriteLine();
                        tamagotchi.feed();
                    }

                    if (answer == "5")
                    {
                        tamagotchi.tick();
                    }

                    if (answer == "6")
                    {
                        teenTamagotchiCar.useCar();
                        Console.WriteLine($"{tamagotchi.name} åkte till Stockholm");
                        Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                        Console.ReadLine();
                        tamagotchi.reduceBoredom();
                    }
                }
            }
        }
    }
}

