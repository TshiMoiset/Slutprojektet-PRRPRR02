using System.Globalization;
using System.Security.Cryptography;
using System.Linq;
using System.Dynamic;
using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class StartGame
    {
        public void LauchGame()
        {
            string answer = "";

            // While loopen kommer köras tills att man har valt att köra som vuxen eller tonåring.
            while (answer != "vuxen" || answer != "tonåring")
            {
                Console.WriteLine("Ska din Tamagotchi vara vuxen eller tonåring?");
                Console.WriteLine("Kör du med vuxen tamagotchi kommer du ha ett husdjur.");
                answer = Console.ReadLine().ToLower();
                Console.Clear();

                // Spelet kommer tala om för användaren att valen vilka val som finns om hen inte svarar rätt på frågan. 
                if (answer != "vuxen" || answer != "tonåring")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det där är inte ett giltigt alternativ!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Välj vuxen eller barn, försök igen!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Väljer man vuxen körs kodenblocket nedan. 
                if (answer == "vuxen")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    AdultTamagotchiGameMode();
                }

                // Väljer man vuxen körs kodenblocket nedan. 
                else if (answer == "tonåring")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    TeenTamagotchiGameMode();
                }
            }
        }

        // Koden för att köra som tonåring tamagotchin.
        void TeenTamagotchiGameMode()
        {
            TeenTamagotchi tamagotchi = new TeenTamagotchi();
            int answerInt = 0;
            string answer = "";

            Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
            Console.WriteLine();
            Console.Write("Tamagotchi namn: ");
            tamagotchi.name = Console.ReadLine().ToUpper();

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

                // Gör om stringen till en int. Om användaren svara med en int som är störren än eller lika med 6 går inte spelet vidare.
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

                // Om användaren svara 4 körs koden och tamagotchin äter. Hunger sänks.
                if (answer == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Tack för maten :)");
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    tamagotchi.feed();
                }

                if (answer == "5")
                {
                    tamagotchi.tick();
                }
            }
        }

        // Koden för att köra som vuxen tamagotchi
        void AdultTamagotchiGameMode()
        {
            AdultTamagotchi tamagotchi = new AdultTamagotchi();
            Pet pet = new Pet();
            int answerInt = 0;
            string answer = "";

            Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
            Console.WriteLine();
            Console.Write("Tamagotchi namn: ");
            tamagotchi.name = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine("Välje ett namn åt husdjuret, tryck sedan [ENTER] för att fortsätta.");
            Console.WriteLine();
            Console.Write("Husdjurets namn: ");
            pet.name = Console.ReadLine().ToUpper();

            // Hämtar värdet av isAlive. Om isAlive är true körs loopen. Behöver loopen för att köra spelet. 
            while (tamagotchi.GetAlive())
            {
                Console.Clear();
                Console.Write($"Namn: {tamagotchi.name} || ");
                tamagotchi.printStats();
                Console.Write($"Namn: {pet.name} || ");
                pet.printStats();

                Console.WriteLine();
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine($"1. Lär {tamagotchi.name} ett nytt tal.");
                Console.WriteLine($"2. Vilka tal kan {tamagotchi.name}?");
                Console.WriteLine($"3. Hälsa på {tamagotchi.name}.");
                Console.WriteLine($"4. Mata {tamagotchi.name}");
                Console.WriteLine($"5. Lek med husdjuret.");
                Console.WriteLine($"6. Mata husdjuret.");
                Console.WriteLine($"7. Göra ingenting.");
                Console.WriteLine();
                answer = Console.ReadLine();

                // Gör om stringen till en int. Om användaren svara med en int som är störren än eller lika med 6 går inte spelet vidare.
                // Gör även att man man måste svara med en int.
                while (!int.TryParse(answer, out answerInt) || answerInt >= 8)
                {
                    Console.Clear();
                    Console.Write($"Namn: {tamagotchi.name} || ");
                    tamagotchi.printStats();
                    Console.Write($"Namn: {pet.name} || ");
                    pet.printStats();
                    Console.WriteLine();
                    Console.WriteLine("Vad vill du göra?");
                    Console.WriteLine($"1. Lär {tamagotchi.name} ett nytt tal.");
                    Console.WriteLine($"2. Vilka tal kan {tamagotchi.name}?");
                    Console.WriteLine($"3. Hälsa på {tamagotchi.name}.");
                    Console.WriteLine($"4. Mata {tamagotchi.name}");
                    Console.WriteLine($"5. Lek med husdjuret.");
                    Console.WriteLine($"6. Mata husdjuret.");
                    Console.WriteLine($"7. Göra ingenting.");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det där är inte ett giltigt svar!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Välj ett alternativ mellan 1-7, Försök igen!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Okej, Då väljer jag: ");
                    answer = Console.ReadLine();
                }

                // Om användaren svara 1 körs koden. Man lär tamagotchin ett tal.
                if (answer == "1")
                {
                    int learnNumber = 0;
                    string numberAnswer = "";

                    Console.Write($"Lär {tamagotchi.name} ett nytt tal: ");

                    numberAnswer = Console.ReadLine();

                    // Gör om string till en int och tvingar spelaren att svara med en int.
                    while (!int.TryParse(numberAnswer, out learnNumber))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Det där är inte ett giltigt svar!");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Skriv ett tal!");
                        Console.ForegroundColor = ConsoleColor.White;
                        numberAnswer = Console.ReadLine();
                    }

                    tamagotchi.teachNewNumber(learnNumber);
                    Console.WriteLine(learnNumber);

                    pet.tick();
                }

                // Väljer man 2 körs koden och spelaren får se vilka tal tamagitchin kan
                if (answer == "2")
                {
                    tamagotchi.ShowKnownNumbers();
                    Console.WriteLine();
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    pet.tick();
                }

                // Om användaren svara 3 körs koden. Man hälsar på tamagotchin. Tamagothin kommer svara med en random hälsningfras som finns i en array.  
                if (answer == "3")
                {
                    Console.WriteLine($"Säg något till {tamagotchi.name}.");
                    Console.WriteLine("Tryck sedan på [ENTER] för att fortsätta!");
                    Console.WriteLine();
                    Console.ReadLine();
                    tamagotchi.hi();
                    tamagotchi.reduceBoredom();
                    pet.tick();
                    Console.ReadLine();
                }

                // Om användaren svara 4 körs koden och tamagotchin äter. Hunger sänks.
                if (answer == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Tack för maten :)");
                    Console.WriteLine("Tryck på [ENTER] för att fortsätta!");
                    Console.ReadLine();
                    tamagotchi.feed();
                }

                // Husdjurets boredom går ner samt tamagotchins. Men hungern går upp för båda.
                if (answer == "5")
                {
                    pet.reduceBoredom();
                    tamagotchi.tick();
                    tamagotchi.reduceBoredom();
                }

                // Koden körs och husdjurets hunger går ner.
                if (answer == "6")
                {
                    pet.feed();
                }

                // Svara man 5 körs koden nedan, hunger och boredom ökar med ett random värde.
                if (answer == "7")
                {
                    tamagotchi.tick();
                    pet.tick();
                }
            }
        }
    }
}


