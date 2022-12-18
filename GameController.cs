using System.Xml.Linq;

namespace MooSpel
{
    public class GameController
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
                RunGuessingRound();
                _topList.Update(_game.NumberOfGuesses, _game.UserName);
                _topList.Show();
                _ui.PutString("Correct, it took " + _game.NumberOfGuesses + " guesses\nContinue?");
                userInput = _ui.GetString().Trim();
            } while (userInput.ToLower() != "n");
            
        }

        public void AskUserName()
        {
            _ui.PutString(_game.AskForUserName());
            _game.UserName = _ui.GetString().Trim();
        }
        private void SetUpNewGame()
        {
            _game.NumberOfGuesses = 0;
            _game.MakeGoalDigits();
            _ui.PutString(_game.GetStartNewGameMessage());
        }

        public void RunGuessingRound() 
        {
            do
            {
                _game.NumberOfGuesses++;
                _game.ResultOfGuesses = _game.CheckIfBullsOrCows(_game.GoalDigits, _ui.GetString().Trim());
                _ui.PutString(_game.ResultOfGuesses);
            } while (_game.ResultOfGuesses != "BBBB,");
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
