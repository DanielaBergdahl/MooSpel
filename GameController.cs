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
            SetUpNewGame();

            //Själva gissningsfasen börjar...
            string input;
            do { 
                    DisplayGameState();
                    input = _ui.GetString().Trim();
                    //Handle(input);
            }   while (input.ToLower() != "n");
        }

      

        public void AskUserName()
        {
            _ui.PutString(_game.GetStartMessage()); // sker bara en gång Set up fas
            _game.UserName = _ui.GetString().Trim();// Sker bar en gång Set up fas
        }
        private void SetUpNewGame()
        {
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
