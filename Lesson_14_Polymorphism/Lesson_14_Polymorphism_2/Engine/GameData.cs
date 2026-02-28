using Lesson_14_Polymorphism_2.Weapons;

namespace Lesson_14_Polymorphism_2.Engine;

public class GameData
{
    private static GameData? _instance;
    
    public List<Weapon> _weapons {get; private set;}
    public List<Weapon> Weapons => _weapons;
    
    public static GameData? Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
    }

    public void RegisterWeapon(params Weapon[] weapons)
    {
        _weapons.AddRange(weapons);
    }
}