# 60 задач на дебагінг по C#

## 1
```csharp
// Знайди помилку.
// Програма має вивести суму чисел.
int a = 5;
int b = 10;
Console.WriteLine("Sum = " + a - b);
```

## 2
```csharp
// Знайди помилку.
// Чому тут виводиться не 2.5?
int a = 5;
int b = 2;
double result = a / b;
Console.WriteLine(result);
```

## 3
```csharp
// Знайди помилку.
// Чому це повідомлення виводиться завжди?
int age = 18;

if (age >= 18);
{
    Console.WriteLine("Можна");
}
```

## 4
```csharp
// Знайди помилку.
// Проблема в умові if.
int score = 100;

if (score = 100)
{
    Console.WriteLine("Відмінно");
}
```

## 5
```csharp
// Знайди помилку.
// Цикл працює неправильно.
for (int i = 0; i <= 5; i--)
{
    Console.WriteLine(i);
}
```

## 6
```csharp
// Знайди помилку.
// Чому програма зависає?
int count = 0;

while (count < 5)
{
    Console.WriteLine(count);
}
```

## 7
```csharp
// Знайди помилку.
// Тут є проблема з індексом масиву.
int[] numbers = { 1, 2, 3 };
Console.WriteLine(numbers[3]);
```

## 8
```csharp
// Знайди помилку.
// Чому виникає помилка під час запуску?
string text = null;
Console.WriteLine(text.Length);
```

## 9
```csharp
// Знайди помилку.
// Програма має рахувати площу прямокутника.
int width = 4;
int height = 5;
int area = width + height;
Console.WriteLine(area);
```

## 10
```csharp
// Знайди помилку.
// У виводі переплутані дані.
string firstName = "Ivan";
string lastName = "Petrenko";
Console.WriteLine("Мене звати " + lastName + " " + lastName);
```

## 11
```csharp
// Знайди помилку.
int price = 19.99;
Console.WriteLine(price);
```

## 12
```csharp
// Знайди помилку.
// Чому цей код не працює?
Console.Write("Введіть число: ");
int number = Console.ReadLine();
Console.WriteLine(number * 2);
```

## 13
```csharp
// Знайди помилку.
// Тут має вийти 12, а не 7.
int coins = 10;
coins = 5;
coins += 2;
Console.WriteLine(coins);
```

## 14
```csharp
// Знайди помилку.
// Умова складена неправильно.
int age = 15;

if (age >= 10 && age >= 18)
{
    Console.WriteLine("Підходить");
}
```

## 15
```csharp
// Знайди помилку.
// Є проблема в switch.
int day = 2;

switch (day)
{
    case 1:
        Console.WriteLine("Понеділок");
    case 2:
        Console.WriteLine("Вівторок");
        break;
}
```

## 16
```csharp
// Знайди помилку.
// Де саме тут буде помилка?
string word = "Hello";

for (int i = 0; i <= word.Length; i++)
{
    Console.WriteLine(word[i]);
}
```

## 17
```csharp
// Знайди помилку.
// Середнє значення рахується неправильно.
int a = 7;
int b = 8;
int c = 9;

int average = a + b + c / 3;
Console.WriteLine(average);
```

## 18
```csharp
// Знайди помилку.
// Має бути: "Відповідь: 5".
int x = 2;
int y = 3;
Console.WriteLine("Відповідь: " + x + y);
```

## 19
```csharp
// Знайди помилку.
// Неправильне порівняння значень.
string password = "12345";

if (password == 12345)
{
    Console.WriteLine("Правильно");
}
```

## 20
```csharp
// Знайди помилку.
// Метод написаний неправильно.
static void PrintMessage()
{
    return "Привіт!";
}
```

## 21
```csharp
// Знайди помилку.
// Метод повинен повертати число.
static int Sum(int a, int b)
{
    Console.WriteLine(a + b);
}
```

## 22
```csharp
// Знайди помилку.
// Чому тут не можна присвоїти результат у змінну?
static void Main()
{
    int result = Multiply(3, 4);
    Console.WriteLine(result);
}

static void Multiply(int a, int b)
{
    Console.WriteLine(a * b);
}
```

## 23
```csharp
// Знайди помилку.
// Магазин майже завжди "відкритий". Чому?
int hour = 14;

if (hour > 8 || hour < 18)
{
    Console.WriteLine("Відкрито");
}
```

## 24
```csharp
// Знайди помилку.
// Тут одразу дві помилки.
int[] nums = { 1, 2, 3, 4, 5 };

for (int i = 1; i <= nums.Length; i++)
{
    Console.WriteLine(nums[i]);
}
```

## 25
```csharp
// Знайди помилку.
// Перевірка парності зроблена неправильно.
int number = 8;

if (number / 2 == 0)
{
    Console.WriteLine("Парне");
}
```

## 26
```csharp
// Знайди помилку.
// Сума масиву рахується неправильно.
int[] numbers = { 1, 2, 3, 4 };
int sum = 0;

for (int i = 0; i < numbers.Length; i++)
{
    sum = numbers[i];
}

Console.WriteLine(sum);
```

## 27
```csharp
// Знайди помилку.
// Чому число 10 ніколи не випаде?
Random random = new Random();
int number = random.Next(1, 10);
Console.WriteLine(number);
```

## 28
```csharp
// Знайди помилку.
// Тут проблема з типом даних.
bool isAlive = "true";

if (isAlive)
{
    Console.WriteLine("Гравець живий");
}
```

## 29
```csharp
// Знайди помилку.
// HP має зменшуватися, а не замінюватися.
int hp = 100;
int damage = 25;

hp = damage;
Console.WriteLine(hp);
```

## 30
```csharp
// Знайди помилку.
// Оператор записаний неправильно.
string text = "Hello";
text =+ " World";
Console.WriteLine(text);
```

## 31
```csharp
// Знайди помилку.
// Логіка умов неправильна.
int number = 0;

if (number >= 0)
{
    Console.WriteLine("Додатне");
}
else if (number == 0)
{
    Console.WriteLine("Нуль");
}
```

## 32
```csharp
// Знайди помилку.
// Додай захист від ділення на нуль.
int a = 10;
int b = 0;
Console.WriteLine(a / b);
```

## 33
```csharp
// Знайди помилку.
// Чому вхід не спрацьовує?
string login = "admin";
string password = "1234";

if (login == "admin" && password == "12345")
{
    Console.WriteLine("Вхід виконано");
}
```

## 34
```csharp
// Знайди помилку.
// Чому цей цикл нескінченний?
int lives = 3;

while (lives > 0)
{
    Console.WriteLine("Гравець живий");
    lives++;
}
```

## 35
```csharp
// Знайди помилку.
// Тут є проблема зі списком.
List<int> numbers = new List<int>() { 1, 2, 3 };
Console.WriteLine(numbers[3]);
```

## 36
```csharp
// Знайди помилку.
// Порівняння може не спрацювати.
string name = "Alex";
if (name == "alex")
{
    Console.WriteLine("Привіт");
}
```

## 37
```csharp
// Знайди помилку.
// Чому числа пропускаються?
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    i++;
}
```

## 38
```csharp
// Знайди помилку.
// Неправильний індекс масиву.
int[] arr = new int[5];
Console.WriteLine(arr[5]);
```

## 39
```csharp
// Знайди помилку.
// Знижка рахується не так, як очікується.
double price = 10;
int discount = 3;
double finalPrice = price - discount / 2;
Console.WriteLine(finalPrice);
```

## 40
```csharp
// Знайди помилку.
// Проблема в назві змінної.
Console.WriteLine("Введіть ім’я:");
string name = Console.ReadLine();
Console.WriteLine("Привіт, " + Name);
```

## 41
```csharp
// Знайди помилку.
// Неправильний тип літерала.
char letter = "A";
Console.WriteLine(letter);
```

## 42
```csharp
// Знайди помилку.
// Чому рядок не змінюється?
string message = "Hello";
message[0] = 'Y';
Console.WriteLine(message);
```

## 43
```csharp
// Знайди помилку.
// Блок if працює не так, як здається.
int number = 5;
if (number > 0)
    Console.WriteLine("Додатне");
    Console.WriteLine("Перевірка завершена");
```

## 44
```csharp
// Знайди помилку.
// Логіка перевірки парності неправильна.
int a = 5;
int b = 2;
Console.WriteLine(a % b == 1 ? "Парне" : "Непарне");
```

## 45
```csharp
// Знайди помилку.
// Текст повідомлення неправильний.
int temp = 25;

if (temp > 30)
{
    Console.WriteLine("Жарко");
}
else if (temp > 20)
{
    Console.WriteLine("Холодно");
}
```

## 46
```csharp
// Знайди помилку.
// Тут є проблема при видаленні елемента.
List<string> fruits = new List<string>();
fruits.Add("Apple");
fruits.Add("Banana");
fruits.RemoveAt(2);
```

## 47
```csharp
// Знайди помилку.
// Змінна i тут не є індексом.
int[] numbers = { 2, 4, 6 };
foreach (int i in numbers)
{
    Console.WriteLine(numbers[i]);
}
```

## 48
```csharp
// Знайди помилку.
// Потрібне правильне перетворення типу.
string text = "123";
int number = text;
Console.WriteLine(number + 1);
```

## 49
```csharp
// Знайди помилку.
// Помилка в умові if.
bool isAdmin = false;
if (isAdmin = true)
{
    Console.WriteLine("Адмін");
}
```

## 50
```csharp
// Знайди помилку.
// Неправильне використання властивості.
DateTime today = DateTime.Now;
Console.WriteLine(today.DayOfWeek());
```

## 51
```csharp
// Знайди помилку.
// Тип результату не підходить.
int result = Math.Pow(2, 3);
Console.WriteLine(result);
```

## 52
```csharp
// Знайди помилку.
// Один елемент не виводиться.
string[] names = { "Ola", "Ira", "Max" };
for (int i = 0; i < names.Length - 1; i++)
{
    Console.WriteLine(names[i]);
}
```

## 53
```csharp
// Знайди помилку.
// Тут несумісні типи даних.
int number = 10;
string result = number + 5;
Console.WriteLine(result);
```

## 54
```csharp
// Знайди помилку.
// Гроші списуються завжди. Чому?
int money = 100;
if (money > 50)
    Console.WriteLine("Можна купити");
    money -= 50;
Console.WriteLine(money);
```

## 55
```csharp
// Знайди помилку.
// Метод нічого не повертає.
static int GetNumber()
{
    Console.WriteLine("5");
}
```

## 56
```csharp
// Знайди помилку.
// Цикл з кінця написаний неправильно.
int[] nums = { 10, 20, 30 };
for (int i = nums.Length; i >= 0; i--)
{
    Console.WriteLine(nums[i]);
}
```

## 57
```csharp
// Знайди помилку.
// Умова перевірки email надто слабка.
string email = "";
if (email.Length > 0 || email.Contains("@"))
{
    Console.WriteLine("Email коректний");
}
```

## 58
```csharp
// Знайди помилку.
// Тут є звернення до списку після очищення.
List<int> scores = new List<int>() { 10, 20, 30 };
scores.Clear();
Console.WriteLine(scores[0]);
```

## 59
```csharp
// Знайди помилку.
// Чому рівень не збільшується, як очікується?
int level = 1;
level = level++;
Console.WriteLine(level);
```

## 60
```csharp
// Знайди помилку.
// Логічна умова складена неправильно.
string answer = Console.ReadLine();

if (answer == "yes" || "Yes")
{
    Console.WriteLine("Ок");
}
```