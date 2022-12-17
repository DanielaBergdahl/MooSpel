using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooSpel
{
    public class Player
    {
        public string Name { get; private set; }
        public int AmountOfGames { get; private set; } // EA: Ändrat namnet till AmountOfGames 
        int totalGuess;


        public Player(string name, int guesses)
        {
            this.Name = name;
            AmountOfGames = 1; //EA: Varför är den satt till 1?
            totalGuess = guesses;
        }

        public void Update(int guesses)                 //Har en (1) references
        {                                               // TODO - Hitta bra namn på metoden
            totalGuess += guesses;
            AmountOfGames++;
        }

        public double Average()                         //Har tre references
        {                                               // TODO - Hitta bra namn på metoden
            return (double)totalGuess / AmountOfGames;
        }
    }
}
