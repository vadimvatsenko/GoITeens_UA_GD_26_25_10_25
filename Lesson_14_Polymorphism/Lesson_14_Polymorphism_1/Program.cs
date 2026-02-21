// Кахут по Класам
// ДЗ Мітя, Роман
// UI для Мити
// Нова тема Наслідування та Поліморфізм
// Приклади з конспекту
// Композиция классов - невеличкий приклад


namespace Lesson_14_Polymorphism_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior(100, 20, "Sword", 5);
            //Character mage = new Mage();
            
            warrior.AddArmorLevel(10);
            
            Character warior = new Warrior(100, 20, "Sword", 5);
            Character mag = new Mage(10, 10, 10);


            List<Character> characters = new List<Character>()
            {
                warrior,
                mag
            };

            foreach (Character character in characters)
            {
                character.TakeDamage(10);
            }
            
            
            Mage mage = new Mage(100, 2, 20);
            mage.CastSpell();
        }
    }
}