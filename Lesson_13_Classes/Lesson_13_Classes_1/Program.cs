// План заняття
// Кахут по ООП, легкий
// Продовжуемо Тему ООП та класів

// - Євген завдання ООП
// - Роман, рейтинг пісні, Класи та об'єкти
// - Будемо вирішувати задачки

// Hero => Weapon => Bullet


namespace Lesson_13_Classes_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon("pistol", 30, 3);
            Weapon shootgun = new Weapon("shootgun", 8, 5);
            
            Hero hero = new Hero("Bob", weapon);
            
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            
            hero.ChangeWeapon(shootgun);
            
            Console.WriteLine("-------");
            
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            
            Console.WriteLine("-------");
            
            hero.ReloadWeapon();
            
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            
            Console.ReadKey();
            
        }
    }
}



















// HealComponent

/*Зелена трава = відновити невелику кількість здоров’я;
Зелена трава + Зелена трава = відновити помірну кількість здоров’я;
Зелена трава + Зелена трава + Зелена трава = повністю відновити здоров’я;
Зелена трава + Червона трава = повністю відновити здоров’я;
Зелена трава + Зелена трава + Червона трава = повністю відновити здоров’я та на короткий час зменшити отримувану шкоду;*/