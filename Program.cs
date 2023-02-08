using static System.Net.Mime.MediaTypeNames;

namespace _8Prakticheskaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Clear();
            Test newTest = new Test(name);
        }
    }
}