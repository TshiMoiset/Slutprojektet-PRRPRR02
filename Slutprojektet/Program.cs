using System;
using System.Collections.Generic;

namespace Slutprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Anropar klassen menu
            Menu goToMenu = new Menu();
            // Går till menu klassen för att köra koden där
            goToMenu.runMenu();
            Console.ReadLine();
        }
    }
}


