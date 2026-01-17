//Рівень 1. Базові функції (легкі)

//1. 🎮 Функція-привітання гравця: напиши функцію, яка приймає ім’я героя і виводить: Ласкаво просимо в гру, [ім’я]! .
//2. ❤️ Функція здоров’я: створи функцію, яка приймає силу удару ворога і повертає, скільки здоров’я втратить герой.


//🔹 Рівень 2. Параметри та аргументи (середні)
//1. 👹 Функція вибору сильнішого ворога: напиши функцію, яка приймає силу двох ворогів і повертає, хто з них сильніший.
//2. Середній досвід гравців: створи функцію, яка приймає три значення досвіду гравців у команді і повертає середнє значення.

//🔹 Рівень 3. Повертаючі функції (вище середнього)
// 1. ✨ Перевірка "чи вистачить манни": Функція приймає кількість манни і вартість закляття, повертає true або false.
// 2. 💰💎 Конвертер золота в кристали: створи функцію, яка приймає кількість золота і курс обміну, а повертає кількість кристалів.

//🔹 Рівень 4. Складніші задачі (важкі)
//1. Напиши гру "Камінь-Ножиці-Папір”:
// Створи функцію GetWinner(player1, player2), яка приймає два вибори: "Камінь", "Ножиці", "Папір".
// Функція повинна визначати:
//якщо перший переміг → повертає "Переміг гравець 1",
//якщо другий переміг → "Переміг гравець 2",
//якщо однаково → "Нічия".

//2. 💥 Міні-калькулятор пошкоджень: створи функцію, яка приймає: силу атаки, силу захисту, тип зброї (меч, лук, магія) і повертає кількість пошкоджень.

// 🔹 Рівень 5. Важкі задачі (майже як маленькі системи)

// 🎒 Пошук найсильнішого предмета в інвентарі: напиши функцію, яка приймає масив предметів із їхньою силою і повертає найсильніший предмет.

// 🔑 Перевірка паролю для входу у гру: Гравець має ввести пароль. Створи функцію, яка перевіряє:
// довжину ≥ 8,
// наявність великої літери,
// наявність цифри.

namespace Lesson_9_Methods_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int sum = Sum(1, 2);
            int sum2 = Sum(1, 2, 7);
            
            int sum3 = Sum(10);
            //int sum2 = Sum(1, 2, 5);
            Console.WriteLine(sum);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);

            Console.ReadKey();


            double A = 1.5;
            double B = -1.5;
            double C = 0;
            
            int numbA = Sign(A);
            int numbB = Sign(B);
            int numbC = Sign(C);
            
            Console.WriteLine(Sign(A));

            int result = numbA +  numbB + numbC;
            
            int result2 = Sign(A) + Sign(B) + Sign(C);
            //int result = A + B;

            OverloadMethod();
            OverloadMethod("Denys");
            OverloadMethod(5,6);
            OverloadMethod(5,6,9);
            OverloadMethod("Mitya", 17);
            OverloadMethod(17, "Mitya");
            OverloadMethod(5,6.5,9);
            
            Console.ReadKey();
        }

        static int Sign(double x)
        {
            if (x < 0)
                return -1;
            else if (x > 0)
                return 1;
            else
                return 0;
        }
        
        static int Sum(int a, int b = 5, int c = 5)
        {
            return a + b + c;
        }

        static void OverloadMethod()
        {
            Console.WriteLine("Overload Method");
        }

        static void OverloadMethod(string name)
        {
            Console.WriteLine("Overload Method" + " " + name);
        }
        
        static void OverloadMethod(int a, int b)
        {
            Console.WriteLine($"{a + b}");
        }
        
        static void OverloadMethod(int a, int b, int c)
        {
            Console.WriteLine($"{a + b + c}");
        }
        
        static void OverloadMethod(string name, int age)
        {
            Console.WriteLine($"{name} - {age}");
        }
        
        static void OverloadMethod(int age, string name)
        {
            Console.WriteLine($"{name} - {age}");
        }
        
        static void OverloadMethod(int a, double b, int c)
        {
            Console.WriteLine($"{a + b + c}");
        }
        
    }
}