using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class Program
	{

		public static void Main(string[] args)
		{

			bool gameIsOn = true;
			Console.WriteLine("Enter your user name:\n");
			string userName = Console.ReadLine();

			while (gameIsOn)
			{
				string goalDigits = MakeGoalDigits();

				
				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goalDigits + "\n");
				string userGuess = Console.ReadLine();
				
				int numberOfGuesses = 1;
				string resultOfGuesses = CheckIfBullsOrCows(goalDigits, userGuess); // EA: Det användaren gissat läggs in som argument i metoden.
				Console.WriteLine(resultOfGuesses + "\n");
				while (resultOfGuesses != "BBBB,")
				{
					numberOfGuesses++;
					userGuess = Console.ReadLine();
					Console.WriteLine(userGuess + "\n"); // EA : Kan nog tas bort, den upprepar bara samma sak som användaren just skrivit.
					resultOfGuesses = CheckIfBullsOrCows(goalDigits, userGuess);
					Console.WriteLine(resultOfGuesses + "\n");
				}

				StreamWriter scoreStatisticsOutput = new StreamWriter("result.txt", append: true);
				scoreStatisticsOutput.WriteLine(userName + "#&#" + numberOfGuesses);
				scoreStatisticsOutput.Close();
				showTopList();
				Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
				string usersAnswer = Console.ReadLine();
				
				if (usersAnswer != null && usersAnswer != "" && usersAnswer.Substring(0, 1) == "n")
				{
					gameIsOn = false;
				}
			}
		}
		static string MakeGoalDigits()
		{
			Random randomDigitGenerator = new Random();
			string goalDigits = "";
			for (int i = 0; i < 4; i++)
			{
				int randomIntDigit = randomDigitGenerator.Next(10); //Next method returns a random digit
				string randomStringDigit = "" + randomIntDigit; // vad är "" till för?
				while (goalDigits.Contains(randomStringDigit)) // är false första gången. Kollar om siffra redan finns.
				{
					randomIntDigit = randomDigitGenerator.Next(10);
					randomStringDigit = "" + randomIntDigit;
				}
				goalDigits = goalDigits + randomStringDigit; //Här läggs det till en siffra till goalDigits för varje gång loopen körs
			}
			return goalDigits;
		}

		static string CheckIfBullsOrCows(string goalNumber, string guessedNumber) // Namn: Rätt namn?
		{
			int amountOfCows = 0, amountOfBulls = 0; // Egen anteckning: Kan ta bort värdet 0, det är de redan by default.
			guessedNumber += "    ";     // if player entered less than 4 chars //EA: Kommentaren är kanske överflödig. Behövs koden alls?
			for (int i = 0; i < 4; i++) // EA: Tror det går att ta bort den här for:en. 
			{
				for (int j = 0; j < 4; j++)  // EA: Går det att byta ut mot foreach? 
                {
					if (goalNumber[i] == guessedNumber[j])
					{
						if (i == j)
						{
							amountOfBulls++;
						}
						else
						{
							amountOfCows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, amountOfBulls) + "," + "CCCC".Substring(0, amountOfCows);
		}


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
			players.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
			Console.WriteLine("Player   games average");
			foreach (Player p in players)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			scoreStatisticsInput.Close();
		}
	}

	class Player
	{
		public string Name { get; private set; }
        public int NGames { get; private set; } // EA: Vad är det till?
		int totalGuess;
		

		public Player(string name, int guesses)
		{
			this.Name = name;
			NGames = 1; //EA: Varför är den satt till 1?
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			NGames++;
		}

		public double Average()
		{
			return (double)totalGuess / NGames;
		}

		
	    public override bool Equals(Object p)
		{
			return Name.Equals(((Player)p).Name);
		}

		
	    public override int GetHashCode()
        {
			return Name.GetHashCode();
		}
	}
}