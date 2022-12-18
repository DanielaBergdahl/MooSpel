using System.Diagnostics.Metrics;

namespace MooSpel
{
    internal class Game
    {
        public string UserName { get; set; }
        public string GoalDigits { get; set; }
        public string AskForUserName()
        {
            return "Enter your user name:\n";
        }
        public string GetStartNewGameMessage()
        {
            return "New game:\n\nFor practice, number is: " + GoalDigits + "\n";
        }
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
                GoalDigits = GoalDigits + randomStringDigit; //Här läggs det till en siffra till goalDigits för varje gång loopen körs
            }
        }


        // TODO - Ändra så att en metod med numberOfGuesses i Game returnerar  "Correct it took...X guessesn\Continue?"
        //public void MakeGuess(string userGuess)
        //{
        //    numberOfGuesses = 1;
        //    string resultOfGuesses = CheckIfBullsOrCows(GoalDigits, userGuess); //userGuess ska vara input från användaren
        //    Console.WriteLine(resultOfGuesses + "\n");
        //    while (resultOfGuesses != "BBBB,")
        //    {
        //        numberOfGuesses++;
        //        userGuess = Console.ReadLine(); // TODO - Gör som med UserName!
        //        Console.WriteLine(userGuess + "\n"); // EA : Kan nog tas bort, den upprepar bara samma sak som användaren just skrivit.
        //        resultOfGuesses = CheckIfBullsOrCows(GoalDigits, userGuess);
        //        Console.WriteLine(resultOfGuesses + "\n");
        //    }
        //}
        public string CheckIfBullsOrCows(string goalNumber, string guessedNumber) // Namn: Rätt namn?
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
    }
}
