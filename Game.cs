namespace MooSpel
{
    public class Game : IGame
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
                int randomIntDigit = randomDigitGenerator.Next(10);
                string randomStringDigit = "" + randomIntDigit;
                while (GoalDigits.Contains(randomStringDigit))
                {
                    randomIntDigit = randomDigitGenerator.Next(10);
                    randomStringDigit = "" + randomIntDigit;
                }
                GoalDigits = GoalDigits + randomStringDigit;
            }
        }
        public string CheckIfBullsOrCows(string goalNumber, string guessedNumber)
        {
            int amountOfCows = 0, amountOfBulls = 0;
            guessedNumber += "    ";
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++)   
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
