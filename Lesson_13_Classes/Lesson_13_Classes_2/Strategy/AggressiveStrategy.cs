namespace Lesson_13_Classes_2.Strategy;

public class AggressiveStrategy : ICombatStrategy
{
    public string Name => nameof(AggressiveStrategy);
    
    public void Execute(Hero hero, Unit target)
    {
        hero.Attack(target);
    }
}