using System;

namespace Slutprojektet
{
    public class Menu
    {
        public void runMenu()
        {
            StartGame runGame = new StartGame();

            Console.Title = "Tamagotchi";       // Fönstrets namn. 
            int menuChoises = 0;
            string menuChoisesString = "";      // Tom string för att kunna svara.

            // Loopen behövs för att menyn ska skrivas ut i konsolen. 
            while (menuChoises != 1)    // Så länge menuChoises inte är lika med 1 kommer loopen köras och menyn kommer skrivas ut. 
            {
                menuAlternatives();     // Skriver ut detsom står i metoden, vilket är menyns val alternativ.
                menuChoisesString = Console.ReadLine();

                // Gör om string till en int och tvingar spelaren till att svara med en int. Svarar spelaren med en siffa/tal som är högre än 3 går spelet inte vidare
                while (!int.TryParse(menuChoisesString, out menuChoises) || menuChoises >= 3)
                {
                    wrongMenuInput();       // Meddelande till spelaren när de svarar fel. 
                    menuChoisesString = Console.ReadLine();
                }

                //Om man svarar 1 fortsätter programmet till startgame klassen och kör koden där. 
                if (menuChoisesString == "1")
                {
                    Console.Clear();        //Raderar allt som tidigare skrivits i konsolen.
                    runGame.lauchGame();
                }

                // Om man svarar 2 får man en förklaring till hur spelet fungerar. 
                else if (menuChoisesString == "2")
                {
                    gameplayInformation();
                }

                Console.WriteLine();
            }
        }

        // För en renare kod har texten till menyn skrivits i en egena metoder.
        // Metoden skrivs ut när menyns while loop körs. 
        void menuAlternatives()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Välkommen till Tamagotchi!");
            Console.WriteLine();
            Console.WriteLine("Välj alternativ 1 eller 2 och tryck [ENTER] för att fortsätta.");
            Console.WriteLine("1. Starta spel!");
            Console.WriteLine("2. Hur funkar det?");
            Console.WriteLine();
        }

        // Metoden används när spelaren svarat med ett ogiltigt svar.
        void wrongMenuInput()
        {
            Console.WriteLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det där är inte ett giltigt svar!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Välj alternativ 1 eller 2, Försök igen!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Starta spel!");
            Console.WriteLine("2. Hur funkar det?");
            Console.WriteLine();
            Console.Write("Okej, Då väljer jag: ");
        }

        // Metoden körs när spelaren tryckt på alternativ nr 2 och vill få information om hur spelet fungerar. 
        void gameplayInformation()
        {
            Console.Clear();
            Console.WriteLine("Spelet går ut på att hålla din Tamagotchi vid liv genom att");
            Console.WriteLine("välja mellan att lära den ett nytt ord, hälsa på den, mata den eller göra ingenting.");
            Console.WriteLine("Varje gång du gör ett val ökar hunger och boredom eller så sjunker de, och om någon av de blir över 10 så DÖR din Tamagotchi.");
            Console.WriteLine("DÖD TAMAGOTCHI = GAME OVER");
            Console.WriteLine("Lycka till!");
        }

    }
}