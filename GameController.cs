namespace MooSpel
{
    internal class GameController
    //Skickar sakerna mellan klasserna
    {
        private Game game;
        private IUI ui;

        public GameController(Game game, IUI ui)
        {
            this.game = game;
            this.ui = ui;
        }
        public void Run()
        {
            string input;
            do { 
                    Display();
                    input = ui.GetString().Trim(); // EA:Anropar ui:t
                    //Handle(input);
            }   while (input.ToLower() != "n");
        }

        //private void Handle(string input)
        //{
        //    if (input != null && input != "")
        //    {
        //        ui.GetString();
        //    }
        //    else
        //    {
        //        try
        //        {

        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //}

        private void Display()
        {
            ui.PutString("Enter your user name:\n");
        }
    }
}
