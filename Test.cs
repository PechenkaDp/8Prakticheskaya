using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Prakticheskaya
{
    internal class Test
    {
        private static string Name;
        private long Time;
        private static double SpeedMin;
        private static double SpeedSec;
        private Stopwatch sw = new Stopwatch();

        public Test(string name)
        {
            Name = name;
            Text();
        }
        private void stopwatchStarter()
        {
            sw.Start();
        }
        private void Text()
        {
            Thread textWatch = new Thread(new ThreadStart(stopwatchStarter));
            textWatch.Start();
            int index = 0;
            int indexProection = index;
            int yCord = 0;
            string text = "Не верить императору Константину глупо. В описываемую эпоху Византия переживала далеко не лучшие времена, и событие такого масштаба, как приобщение к истинной вере северных варваров.";
            Console.Write(text);
            char[] characters = text.ToCharArray();
            while (true)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Время: " + (60 - sw.ElapsedMilliseconds / 1000));
                if (sw.ElapsedMilliseconds == 60000 || sw.ElapsedMilliseconds > 60000)
                {
                    sw.Stop();
                    Console.Clear();
                    Console.WriteLine("Время вышло!");
                    Thread.Sleep(10);
                    Time = 60000;
                    SpeedSec = index / (Time / 1000);
                    SpeedMin = SpeedSec / 60000;
                    break;
                }
                if (index % 120 == 0 && index != 0) { yCord++; indexProection = 0; }
                if (index == text.Length)
                {
                    Console.Clear();
                    sw.Stop();
                    Time = sw.ElapsedMilliseconds;
                    SpeedSec = index / (double)(sw.ElapsedMilliseconds / 10000);
                    SpeedMin = index * ((double)sw.ElapsedMilliseconds / 60000.0);
                    break;
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == text[index])
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.ForegroundColor = ConsoleColor.Green;
                    characters[index] = key.KeyChar;
                    Console.Write(key.KeyChar);
                    Console.ResetColor();
                    index++;
                    indexProection++;
                }
                else if (key.KeyChar != text[index])
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(key.KeyChar);
                    Console.ResetColor();
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    Console.SetCursorPosition(indexProection, yCord);
                    Console.Write(text[index]);
                }
            }

            Test.FileSerialize();
        }
        public static void FileSerialize()
        {
            List<user> users = new List<user>();
            string jsonRead = "";
            if (File.Exists("C:\\Users\\Public\\Documents\\json.json"))
            {
                jsonRead = File.ReadAllText("C:\\Users\\Public\\Documents\\json.json");
            }
            if (JsonConvert.DeserializeObject<List<user>>(jsonRead) != null)
            {
                users = JsonConvert.DeserializeObject<List<user>>(jsonRead);
            }

            users.Add(new user(Name, SpeedMin, SpeedSec));

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText("C:\\Users\\Public\\Documents\\json.json", json);

            Console.WriteLine("Хотите ли продолжить? (y/n)");
            string answ = Console.ReadLine();
            if (answ == "y")
            {
                Console.Clear();
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Clear();
                Test newTest = new Test(name);
            }
            else if (answ == "n")
            {
                Console.Clear();
                Console.WriteLine("Пока!");
            }
        }
    }
}
