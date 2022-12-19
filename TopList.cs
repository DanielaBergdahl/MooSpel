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
                int playerPosition = players.IndexOf(player); 
                if (playerPosition < 0)
                {
                    players.Add(player);
                }
                else
                {
                    players[playerPosition].Update(playerTotalGuesses);
                }
            }
            players.Sort((player1, player2) => player1.Average().CompareTo(player2.Average())); 
            Console.WriteLine("Player   games average");                                            
            foreach (Player p in players)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.AmountOfGames, p.Average()));
            }
            scoreStatisticsInput.Close();
        }
    }
}
