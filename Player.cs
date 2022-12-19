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
        public int AmountOfGames { get; private set; } 
        public int totalGuess;


        public Player(string name, int guesses)
        {
            this.Name = name;
            AmountOfGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)                
        {                                               
            totalGuess += guesses;
            AmountOfGames++;
        }

        public double Average()                         
        {                                               
            return (double)totalGuess / AmountOfGames;
        }
    }
}
