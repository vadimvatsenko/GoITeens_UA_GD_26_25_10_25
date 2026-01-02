// 6. Оцінки студентів у шкільній грі: Розробіть ігровий симулятор шкільного класу,
// де гравцеві потрібно буде виступати в ролі вчителя та встановлювати оцінки учням.
// - Пояснення
// Словник: ключ (string) — ПІБ, а значення (int) — оцінка
// Просто створіть порожній словник, за допомогою методу Add додайте декілька учнів та їх оцінку
// Результат виведіть у консоль

//9. Обчислення середньої оцінки у класній грі: Розробіть ігровий симулятор шкільного класу,
// де гравець зіграє вчителя та буде оцінювати віртуальних учнів.
// - Пояснення
// Використайте словник із завдання №6, щоб перебрати всіх студентів та порахувати середню оцінку.
// Зробити у циклі.

namespace Lesson_7_List_Dictionary_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            
            dict.Add("Mitya", new List<int>() {8,12,13});
            dict.Add("Tanya", new List<int>() {11,7,13});
            dict.Add("Denys", new List<int>() {11,3,13});
            dict.Add("Vadym", new List<int>() {11,1,13});
            
            dict["Denys"].Add(12);
            
            /*foreach (var student in dict)
            {
                Console.Write($"{student.Key}: ");
                
                foreach (var value in student.Value)
                {
                    Console.Write($"{value} ");
                }
                
                Console.WriteLine();
            }*/
            
            foreach (var student in dict)
            {
                Console.Write($"{student.Key}: ");
                
                int count = 0;
                float average = 0;
                foreach (var value in student.Value)
                {
                    count++;
                    average += value;
                    Console.Write($"{value} ");
                }
                
                Console.WriteLine($"Середня оцінка {student.Key} - {average / count}");
                
                Console.WriteLine();
            }
            
            /*string name = " ";
            
            do
            {
                Console.WriteLine("Enter Name: ");
                name = Console.ReadLine();
                
                Console.WriteLine("Enter Values: ");
                string valueString  = Console.ReadLine(); //"10,11,12"
                
                string[] values = valueString.Split(',');

                foreach (var v in values)
                {
                    if (!int.TryParse(v, out int value))
                    {
                        Console.WriteLine("Not number");
                        continue;
                    }
                    else
                    {
                        if (!dict.ContainsKey(name))
                        {
                            dict.Add(name, new List<int>());
                            dict[name].Add(value);
                        }
                        else
                        {
                            dict[name].Add(value);
                        }
                    }
                }
                
            } while (dict.Count < 3);
            
            foreach (var student in dict)
            {
                Console.Write($"{student.Key}: ");
                
                foreach (var value in student.Value)
                {
                    Console.Write($"{value} ");
                }
                
                Console.WriteLine();
            }
            */
            
            Console.ReadKey();
        }
    }
}