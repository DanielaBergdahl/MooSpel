using System.Xml.Linq;

namespace MooSpel
{
    internal class GameController
    //Skickar sakerna mellan klasserna
    {
        private Game _game;
        private IUI _ui;
        private ITopList _topList;

        public GameController(Game game, IUI ui, ITopList topList)
        {
            _game = game;
            _ui = ui;
            _topList = topList;
        }
        public void Run()
        {
            AskUserName();
            string userInput;
            do
            {
                SetUpNewGame();
                string resultOfGuesses = "";
                int numberOfGuesses = 0; 
                do
                {
                    userInput = _ui.GetString().Trim();
                    numberOfGuesses++;
                    resultOfGuesses = _game.CheckIfBullsOrCows(_game.GoalDigits, userInput);
                    _ui.PutString(resultOfGuesses);
                } while (resultOfGuesses != "BBBB,");

                _topList.Update(numberOfGuesses, _game.UserName);
                _topList.Show();
                _ui.PutString("Correct, it took " + numberOfGuesses + " guesses\nContinue?"); // TODO - Ändra så att en metod med numberOfGuesses i Game returnerar  "Correct it took...X guessesn\Continue?"
                userInput = _ui.GetString().Trim();
            } while (userInput.ToLower() != "n");
            
        }

        public void AskUserName()
        {
            _ui.PutString(_game.AskForUserName()); // sker bara en gång Set up fas
            _game.UserName = _ui.GetString().Trim();// Sker bar en gång Set up fas
        }
        private void SetUpNewGame()
        {
            _game.MakeGoalDigits();
            _ui.PutString(_game.GetStartNewGameMessage());
        }

        private void Handle(string input)
        {
            if (input != null && input != "")
            {
            }
            else
            {
                
            }
        }

        private void DisplayGameState()
        {
        }
    }
}
