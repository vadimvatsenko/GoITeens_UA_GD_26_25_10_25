namespace _09_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}



/*
/ 🎮 Привітання гравця
void GreetPlayer(string name)
{
    Console.WriteLine($"Ласкаво просимо в гру, {name}!");
}

// ❤️ Функція здоров’я
int CalculateHealthLoss(int enemyAttack)
{
    return enemyAttack; // герой втрачає стільки здоров’я, скільки сила удару
}
рівень 2
// 👹 Вибір сильнішого ворога
int StrongerEnemy(int enemy1, int enemy2)
{
    return (enemy1 > enemy2) ? enemy1 : enemy2;
}

// Середній досвід гравців
double AverageExperience(int exp1, int exp2, int exp3)
{
    return (exp1 + exp2 + exp3) / 3.0;
}
рівень 3
// ✨ Перевірка манни
bool HasEnoughMana(int mana, int spellCost)
{
    return mana >= spellCost;
}

// 💰💎 Конвертер золота в кристали
int ConvertGoldToCrystals(int gold, int rate)
{
    return gold / rate;
}
рівень 4
// 🪨✂️📄 Камінь-Ножиці-Папір
string GetWinner(string player1, string player2)
{
    if (player1 == player2) return "Нічия";

    if ((player1 == "Камінь" && player2 == "Ножиці") ||
        (player1 == "Ножиці" && player2 == "Папір") ||
        (player1 == "Папір" && player2 == "Камінь"))
    {
        return "Переміг гравець 1";
    }
    else
    {
        return "Переміг гравець 2";
    }
}

// 💥 Міні-калькулятор пошкоджень
int DamageCalculator(int attack, int defense, string weapon)
{
    int baseDamage = attack - defense;
    if (baseDamage < 0) baseDamage = 0;

    switch (weapon.ToLower())
    {
        case "меч": return baseDamage + 5;
        case "лук": return baseDamage + 3;
        case "магія": return baseDamage + 7;
        default: return baseDamage;
    }
}
рівень 5
// 🎒 Найсильніший предмет
string StrongestItem(Dictionary<string, int> inventory)
{
    string strongest = "";
    int maxPower = int.MinValue;

    foreach (var item in inventory)
    {
        if (item.Value > maxPower)
        {
            maxPower = item.Value;
            strongest = item.Key;
        }
    }
    return strongest;
}

// 🔑 Перевірка паролю
bool CheckPassword(string password)
{
    if (password.Length < 8) return false;
    
    bool hasUpper = false;
    bool hasDigit = false;

    foreach (char c in password)
    {
        if (char.IsUpper(c)) hasUpper = true;
        if (char.IsDigit(c)) hasDigit = true;
    }

    return hasUpper && hasDigit;
}
*/

