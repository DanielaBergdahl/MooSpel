using System.Diagnostics.Metrics;

namespace MooSpel
{
    public class Game
    {
        public string UserName { get; set; }
        public string GoalDigits { get; set; }
        public int NumberOfGuesses { get; set; }
        public string ResultOfGuesses { get; set; }

        public void MakeGoalDigits()
        {
            GoalDigits = "";
            Random randomDigitGenerator = new Random();
            for (int i = 0; i < 4; i++)
            {
                int randomIntDigit = randomDigitGenerator.Next(10); //Next method returns a random digit
                string randomStringDigit = "" + randomIntDigit; // vad är "" till för?
                while (GoalDigits.Contains(randomStringDigit)) // är false första gången. Kollar om siffra redan finns.
                {
                    randomIntDigit = randomDigitGenerator.Next(10);
                    randomStringDigit = "" + randomIntDigit;
                }
                GoalDigits = GoalDigits + randomStringDigit;
            }
        }

        //        Console.WriteLine(userGuess + "\n"); // EA : Kan nog tas bort, den upprepar bara samma sak som användaren just skrivit.
        
        public string CheckIfBullsOrCows(string goalNumber, string guessedNumber) // Namn: Rätt namn?
        {
            int amountOfCows = 0, amountOfBulls = 0; // Egen anteckning: Kan ta bort värdet 0, det är de redan by default.
            guessedNumber += "    ";   // EA: Behövs mellanslag?
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
    }
}
