using System.Text;
using System.Text.Json;

namespace Questions_1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   
            Console.InputEncoding  = Encoding.UTF8;
            
            Random random = new Random();
            
            List<Student> students = await LoadResourses();
            
            bool isCorrect =  false;
            
            Dictionary<string, string> themes = new Dictionary<string, string>()
            {
                { "Arrays", StaticPath.ArrayQA },
                { "Cycles", StaticPath.CyclesQA },
                { "Strings", StaticPath.StringQA },
                { "Methods", StaticPath.MethodsQA },
            };
            
            // розрахунок шляху до теми
            string targetPath = ChoseTheme(themes);

            // завантаження питань
            List<Question> questions = await LoadQuestions(targetPath);

            // кількість питань на учня
            int tryes = questions.Count / students.Count;
            
            // заповнення кількості питань на учня
            Dictionary<Student, int> questionsByTeacher = FillTargertCountQaForStudents(questions, students);
            
            RunProgramm(students, random, questions, questionsByTeacher);
        }

        private static void RunProgramm(List<Student> students, Random random, List<Question> questions, Dictionary<Student, int> questionsByTeacher)
        {
            bool isCorrect;
            do
            {
                Console.Clear();
                Console.ResetColor();
                
                Student student = ChooseRandom(students, random);
                
                Console.WriteLine("На питання буде відповідати: ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"***{student.FirstName} {student.SecondName}***");
                
                Console.ResetColor();
                
                Console.WriteLine("Натисни будь-яку клавішу щоб продовжити...");
                Console.ReadKey();
                
                Question question = ChooseRandom(questions, random);
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
                    
                    isCorrect = int.TryParse(input, out int correctAnswer) 
                                && (correctAnswer >= 1 && correctAnswer <= 4);

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
                        questionsByTeacher[student]--;

                        if (questionsByTeacher[student] == 0)
                        {
                            students.Remove(student);
                        }
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
                
            } while (questions.Count > 0 || students.Count > 0);
            
            
            Console.WriteLine("Питання закінчились, дякую");
            Console.ReadKey();
        }

        private static T ChooseRandom<T>(List<T> list, Random random)
            => list[random.Next(list.Count)];

        private static Dictionary<Student, int> FillTargertCountQaForStudents(List<Question> questions, List<Student> students)
        {
            Dictionary<Student, int> questionsByTeacher = new Dictionary<Student, int>();
            for (int i = 0; i < questions.Count; i++)
            {
                Student student = students[i % students.Count];
                
                if (!questionsByTeacher.ContainsKey(student))
                {
                    questionsByTeacher.Add(students[i], 1);
                }
                else
                {
                    questionsByTeacher[student]++;
                }
            }
            
            return questionsByTeacher;
        }

        private static string ChoseTheme(Dictionary<string, string> themes)
        {
            for (int i = 0; i < themes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {themes.ElementAt(i).Key}");
            }
            
            bool isValidThemeNumber = false;
            string targetPath =  String.Empty;
            
            do
            {
                Console.Write("Enter Theme Number: ");
                string themeInput = Console.ReadLine();
                
                if (int.TryParse(themeInput, out int theme) && (theme >= 1 && theme <= themes.Count))
                {
                    isValidThemeNumber = true;
                    targetPath = themes.ElementAt(theme - 1).Value;
                }
                else
                {
                    Console.Write($"Enter Valid Theme Number");
                    continue;
                }
            } while (!isValidThemeNumber);
            
            return targetPath;
        }

        // завантаження студентів
        async static Task<List<Student>> LoadResourses()
        {
            List<Student> tempStudentsList = new List<Student>();
            try
            {
                using (FileStream fs = new FileStream(StaticPath.StudentsPath, FileMode.OpenOrCreate))
                {
                    var studentsArray = await JsonSerializer.DeserializeAsync<Student[]>(fs);
                    tempStudentsList.AddRange(studentsArray);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return tempStudentsList;
        }

        // завантаження питань
        async static Task<List<Question>> LoadQuestions(string path)
        {
            List<Question> questions = new List<Question>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Question[]? qa = await JsonSerializer.DeserializeAsync<Question[]>(fs);
                    questions.AddRange(qa);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return questions;
        }
    }
}