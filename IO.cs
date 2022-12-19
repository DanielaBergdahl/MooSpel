namespace MooSpel
{
    public class IO : IUI
    {
        public void Clear()
        {
            //nothing
        }
        public void Exit()
        {
            System.Environment.Exit(0);
        }
        public string GetString()
        {
            return Console.ReadLine();
        }
        public void PutString(string s)
        {
            Console.WriteLine(s);
        }
    }


}
