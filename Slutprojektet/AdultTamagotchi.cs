using System;

namespace Slutprojektet
{
    public class AdultTamagotchi : Tamagotchi
    {
        string[] Salutations = { "God dag", "Var hälsad", "Trevligt att råkas", "Fint väder så här års" };


        public override void printStats()
        {
            Console.WriteLine($"Tråkighet: {Boredom} || Hunger: {Hunger} || Vokabulär: {words.Count} || Ålder: Vuxen || Vid Liv: {isAlive} || ");
        }

    }
}