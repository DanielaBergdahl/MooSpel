namespace MooGame
{
    public static class ProgramHelpers
    {

        public static string CheckIfBullsOrCows(string goalNumber, string guessedNumber) // Namn: Rätt namn?
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
