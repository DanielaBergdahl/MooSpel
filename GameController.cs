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
            string input;
            do { 
                    Display();
                    input = _ui.GetString().Trim();
                    //Handle(input);
            }   while (input.ToLower() != "n");
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

        private void Display()
        {
            _ui.PutString(_game.GetStartMessage());
        }
    }
}
