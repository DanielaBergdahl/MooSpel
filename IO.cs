namespace MooSpel
{
    public class IO : IUI
    {
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
