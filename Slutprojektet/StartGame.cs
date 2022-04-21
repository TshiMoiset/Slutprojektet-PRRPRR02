using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    public class StartGame
    {
        public void lauchGame()
        {
            Console.Clear();
            int answerInt = 0;
            string answer = "";
            string food = "";
            Tamagotchi tamagotchi1 = new Tamagotchi();
            tamagotchi1.name = "";

            Console.Clear();
            Console.WriteLine("Välj ett namn åt din Tamagotchi, tryck sedan [ENTER] för att fortsätta.");
            Console.Write("Tamagotchi namn: ");
            tamagotchi1.name = Console.ReadLine();

            Console.WriteLine();
            Console.Write($"Namn: {tamagotchi1.name} || ");

            while (tamagotchi1.GetAlive())
            {
                tamagotchi1.printStats();
                Console.WriteLine();

                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine($"1. Lära {tamagotchi1.name} ett nytt ord");
                Console.WriteLine($"2. Hälsa på {tamagotchi1.name}");
                Console.WriteLine($"3. Mata {tamagotchi1.name}");
                Console.WriteLine($"4. Göra ingenting");

                answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.WriteLine();
                    Console.Write($"Lär {tamagotchi1.name} ett nytt ord: ");
                    string wordAnswer = Console.ReadLine();
                    tamagotchi1.teach(wordAnswer);
                    Console.WriteLine();
                    Console.WriteLine($"{tamagotchi1.name} lärde sig ordet: {wordAnswer} ");
                    tamagotchi1.tick();
                }

                if (answer == "2")
                {
                    tamagotchi1.hi();
                    Console.WriteLine();
                    tamagotchi1.tick();
                }

                if (answer == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vad vill du att {tamagotchi1.name} ska äta?");
                    food = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    Console.WriteLine("Tack för maten, den var god :)");
                    Console.WriteLine();
                    tamagotchi1.tick();
                    tamagotchi1.feed();

                }

                if (answer == "4")
                {
                    Console.WriteLine("Vad tråkig du är :(");
                    Console.WriteLine();
                    tamagotchi1.tick();
                }

                while (!int.TryParse(answer, out answerInt))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Det där är inte ett giltigt svar!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Välj en siffra mellan 1-4, Försök igen!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Okej, Jag väljer då: ");
                    answer = Console.ReadLine();
                }
            }

        }
    }
}