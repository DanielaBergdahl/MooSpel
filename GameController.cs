using System.Xml.Linq;

namespace MooSpel
{
    internal class GameController
    //Skickar sakerna mellan klasserna
    {
        private Game _game;
        private IUI _ui;

        public GameController(Game game, IUI ui)
        {
            this._game = game;
            this._ui = ui;
        }
        public void Run()
        {
            AskUserName();
            string userInput;
            do
            {
                SetUpNewGame();
                string resultOfGuesses = "";
                do
                {
                    userInput = _ui.GetString().Trim();
                    if (userInput != "n")
                    {
                        resultOfGuesses = _game.CheckIfBullsOrCows(_game.GoalDigits, userInput);
                        _ui.PutString(resultOfGuesses);
                    }
                } while (resultOfGuesses != "BBBB," && userInput.ToLower() != "n");

                UpdateTopList();
                PrintTopList();
                _ui.PutString("Continue?");
                userInput = _ui.GetString().Trim();
            } while (userInput.ToLower() != "n");
            
        }

        private void UpdateTopList()
        {
            Console.WriteLine("Updating toplist...");
        }

        private void PrintTopList()
        {
            Console.WriteLine("Printing toplist...");
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
