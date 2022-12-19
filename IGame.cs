namespace MooSpel
{
    public interface IGame
    {
        string UserName { get; set; }
        string GoalDigits { get; set; }
        int NumberOfGuesses { get; set; }
        string ResultOfGuesses { get; set; }

        void MakeGoalDigits();
        string CheckIfBullsOrCows(string goalNumber, string guessedNumber);
    }
}