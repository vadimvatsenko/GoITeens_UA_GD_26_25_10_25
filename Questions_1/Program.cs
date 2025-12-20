using System;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

// вікторина

namespace Questions_1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   
            Console.InputEncoding  = Encoding.UTF8;
            
            Random random = new Random();
            List<Student> students = new List<Student>();
            List<Question> questions = new List<Question>();
            bool isCorrect =  false;
            
            string studentsPath = @"P:/Projects/Rider/GoITeens_UA_GD_26_25_10_25/Questions_1/Jsons/_students.json";
            //string qaPath = @"P:/Projects/Rider/GoITeens_UA_GD_26_25_10_25/Questions_1/Jsons/arrays.json";
            string qaPath = @"P:/Projects/Rider/GoITeens_UA_GD_26_25_10_25/Questions_1/Jsons/cycles.json";
            
            try
            {
                using (FileStream fs = new FileStream(studentsPath, FileMode.OpenOrCreate))
                {
                    var studentsArray = await JsonSerializer.DeserializeAsync<Student[]>(fs);
                    students.AddRange(studentsArray);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                using (FileStream fs = new FileStream(qaPath, FileMode.OpenOrCreate))
                {
                    Question[]? qa = await JsonSerializer.DeserializeAsync<Question[]>(fs);
                    questions.AddRange(qa);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            do
            {
                Console.Clear();
                Console.ResetColor();
                Student student = students[random.Next(students.Count)];
                Console.WriteLine("На питання буде відповідати: ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"***{student.FirstName} {student.SecondName}***");
                Console.ResetColor();
                
                Console.WriteLine("Натисни будь-яку клавішу щоб продовжити...");
                Console.ReadKey();
                
                Question question = questions[random.Next(questions.Count)];
                Console.Write("Питання: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(question.Quest);
                

                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[{i + 1}] ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{question.Answers[i].Answ}");
                }

                do
                {
                    Console.ResetColor();
                    Console.Write("Вибери правильну відповідь від 1 до 4: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string input = Console.ReadLine();
                    
                    isCorrect = int.TryParse(input, out int correctAnswer) && (correctAnswer >= 1 && correctAnswer <= 4);

                    if (isCorrect)
                    {
                        if (question.Answers[correctAnswer - 1].IsCorrect)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"[{correctAnswer}] {question.Answers[correctAnswer - 1].Answ} - Правильна відповідь");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Відповідь не вірна, ");
                            
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Правильна відповідь була ");

                            for (int i = 0; i < question.Answers.Count; i++)
                            {
                                if (question.Answers[i].IsCorrect)
                                {
                                    Console.Write($"[{i + 1}] {question.Answers[i].Answ}");
                                }
                            }
                        }
                        
                        questions.Remove(question); 
                        students.Remove(student);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorect Format of answer");
                        continue;
                    }
                    
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine("Натисни будь-яку клавішу щоб продовжити...");
                    
                } while (!isCorrect);
                
            } while (questions.Count > 0);
            
            
            Console.WriteLine("Питання закінчились, дякую");
            Console.ReadKey();
            
        }
    }
}