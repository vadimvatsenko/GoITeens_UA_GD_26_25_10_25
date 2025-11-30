using System;
using System.Text;

// вікторина

namespace Questions_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   
            Console.InputEncoding  = Encoding.UTF8;

            List<string> studentsNames = Names.GetNames();
            List<string> qa = Topic_1.GetQuestions();
            
            Random random = new Random();
            
            /*Console.WriteLine(studentsNames[1]); // елемент за індексом
            Console.WriteLine(studentsNames.Count); // кількість елементів 16*/

            Console.Write("Вітаю всіх учнів");
            for (int i = 0; i < studentsNames.Count; i++)
            {
                Console.WriteLine(studentsNames[i]);
            }

            Thread.Sleep(1000);
            do
            {
                Console.Clear();
                Console.ResetColor();
                
                Console.WriteLine("Знайди учня, який буде відповідати.");
                int randomStudentIndex = random.Next(0, studentsNames.Count);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(studentsNames[randomStudentIndex]);
                
                Thread.Sleep(500);
                int randomQuestionIndex = random.Next(0, qa.Count);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(qa[randomQuestionIndex]);
                
                qa.RemoveAt(randomQuestionIndex);

                Console.WriteLine($"Питань залишилось {qa.Count}");
                
                Console.ReadKey();
                
            } while (qa.Count > 0);
            
            Console.WriteLine("Питання закінчились!");
            Console.ReadKey();
        }
    }
}