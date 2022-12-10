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
				string guessInput = Console.ReadLine();
				
				int numberOfGuesses = 1;
				string resultOfGuesses = CheckIfBullsOrCows(goalDigits, guessInput); // EA: Det användaren gissat läggs in som argument i metoden.
				Console.WriteLine(resultOfGuesses + "\n");
				while (resultOfGuesses != "BBBB,")
				{
					numberOfGuesses++;
					guessInput = Console.ReadLine();
					Console.WriteLine(guessInput + "\n"); // EA : Kan nog tas bort, den upprepar bara samma sak som användaren just skrivit.
					resultOfGuesses = CheckIfBullsOrCows(goalDigits, guessInput);
					Console.WriteLine(resultOfGuesses + "\n");
				}
				StreamWriter output = new StreamWriter("result.txt", append: true);
				output.WriteLine(userName + "#&#" + numberOfGuesses);
				output.Close();
				showTopList();
				Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
				string answer = Console.ReadLine();
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
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


		static void showTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}
				
				
			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			input.Close();
		}
	}

	class PlayerData
	{
		public string Name { get; private set; }
        public int NGames { get; private set; }
		int totalGuess;
		

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
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
			return Name.Equals(((PlayerData)p).Name);
		}

		
	    public override int GetHashCode()
        {
			return Name.GetHashCode();
		}
	}
}