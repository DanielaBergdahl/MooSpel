﻿namespace MooSpel
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new IO();
            Game game = new Game();
            TopList topList = new TopList();
            GameController controller = new GameController(game, ui, topList);
            controller.Run();
        }
    }       
}