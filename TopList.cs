using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooSpel
{
    internal class TopList : ITopList
    {
        public void Update(int numberOfGuesses, string userName)
        {
            StreamWriter scoreStatisticsOutput = new StreamWriter("result.txt", append: true);
            scoreStatisticsOutput.WriteLine(userName + "#&#" + numberOfGuesses);
            scoreStatisticsOutput.Close();
        }

        public void Show()
        {
            StreamReader scoreStatisticsInput = new StreamReader("result.txt");
            List<Player> players = new List<Player>();
            string nameAndScoreLine;
            while ((nameAndScoreLine = scoreStatisticsInput.ReadLine()) != null)
            {
                string[] allNamesAndScores = nameAndScoreLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string nameOfPlayer = allNamesAndScores[0];
                int playerTotalGuesses = Convert.ToInt32(allNamesAndScores[1]);


                Player player = new Player(nameOfPlayer, playerTotalGuesses);
                int playerPosition = players.IndexOf(player); // EA: Hur kan det bli -1? Det blir det i alla fall.
                if (playerPosition < 0)
                {
                    players.Add(player);
                }
                else
                {
                    players[playerPosition].Update(playerTotalGuesses);
                }


            }
            players.Sort((player1, p2) => player1.Average().CompareTo(p2.Average())); //EA: Här skapas väl en lista?..
            Console.WriteLine("Player   games average");                                            //EA: Som skrivs ut här.
            foreach (Player p in players)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.AmountOfGames, p.Average()));
            }
            scoreStatisticsInput.Close();
        }

    }
}
