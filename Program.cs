namespace MooSpel
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new IO();
            Game game = new Game();
            TopList topList = new TopList();
            GameController controller = new GameController(game, ui, topList);
            controller.Run();
        }
        
        //public static void ToMove() //public static void Main(string[] args)
        //{

        //    bool gameIsOn = true;
        //    //Console.WriteLine("Enter your user name:\n");
        //    string userName = Console.ReadLine(); //KLAR

        //    while (gameIsOn)
        //    {
        //        //string goalDigits = MakeGoalDigits();


        //        Console.WriteLine("New game:\n");
        //        //comment out or remove next line to play real games!
        //        Console.WriteLine("For practice, number is: " + goalDigits + "\n");
        //        string userGuess = Console.ReadLine();

        //        int numberOfGuesses = 1;
        //        string resultOfGuesses = Game.CheckIfBullsOrCows(goalDigits, userGuess);
        //        Console.WriteLine(resultOfGuesses + "\n");
        //        while (resultOfGuesses != "BBBB,")
        //        {
        //            numberOfGuesses++; 
        //            userGuess = Console.ReadLine();  // KLAR
        //            Console.WriteLine(userGuess + "\n"); // EA : Den upprepar bara samma sak som användaren just skrivit.
        //            resultOfGuesses = Game.CheckIfBullsOrCows(goalDigits, userGuess); // KLAR
        //            Console.WriteLine(resultOfGuesses + "\n");
        //        }

        //        StreamWriter scoreStatisticsOutput = new StreamWriter("result.txt", append: true);
        //        scoreStatisticsOutput.WriteLine(userName + "#&#" + numberOfGuesses);
        //        scoreStatisticsOutput.Close();
        //        showTopList();
        //        Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
        //        string usersAnswer = Console.ReadLine();

        //        //if (usersAnswer != null && usersAnswer != "" && usersAnswer.Substring(0, 1) == "n") // Flyttat till Controller Run method.
        //        //{
        //        //    gameIsOn = false;
        //        //}
        //    }
        //}
        //static string MakeGoalDigits()
        //{
        //    Random randomDigitGenerator = new Random();
        //    string goalDigits = "";
        //    for (int i = 0; i < 4; i++)
        //    {
        //        int randomIntDigit = randomDigitGenerator.Next(10); //Next method returns a random digit
        //        string randomStringDigit = "" + randomIntDigit; // vad är "" till för?
        //        while (goalDigits.Contains(randomStringDigit)) // är false första gången. Kollar om siffra redan finns.
        //        {
        //            randomIntDigit = randomDigitGenerator.Next(10);
        //            randomStringDigit = "" + randomIntDigit;
        //        }
        //        goalDigits = goalDigits + randomStringDigit; //Här läggs det till en siffra till goalDigits för varje gång loopen körs
        //    }
        //    return goalDigits;
        //}

        static void showTopList() // EA:Ska nog vara en Make- OCH PrintTopList, dvs flera metoder.
        {


            StreamReader scoreStatisticsInput = new StreamReader("result.txt");
            List<Player> players = new List<Player>();
            string nameAndScoreLine;
            while ((nameAndScoreLine = scoreStatisticsInput.ReadLine()) != null)
            {
                string[] allNamesAndScores = nameAndScoreLine.Split(new string[] { "#&#" }, StringSplitOptions.None); // EA:Förstår ej StringSplitOptions.None
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

    //class OldPlayer --ANVÄNDS EJ--
    //{
        //public string Name { get; private set; }
        //public int AmountOfGames { get; private set; } // EA: Ändrat namnet till AmountOfGames 
        //int totalGuess;


        //public Player(string name, int guesses)
        //{
        //    this.Name = name;
        //    AmountOfGames = 1; //EA: Varför är den satt till 1?
        //    totalGuess = guesses;
        //}

    //    public void Update(int guesses)                 //Har en (1) references
    //    {                                               //Flyttar till Player class
    //        totalGuess += guesses;
    //        AmountOfGames++;
    //    }

    //    public double Average()                         //Har tre references
    //    {                                               //Flyttar till Player class
    //        return (double)totalGuess / AmountOfGames;
    //    }


    //    public override bool Equals(Object p)     // KAN TA BORT, har ej referenser
    //    {
    //        return Name.Equals(((Player)p).Name);
    //    }


    //    public override int GetHashCode()       // KAN TA BORT, har ej referenser
    //    {
    //        return Name.GetHashCode();
    //    }
    //}
}