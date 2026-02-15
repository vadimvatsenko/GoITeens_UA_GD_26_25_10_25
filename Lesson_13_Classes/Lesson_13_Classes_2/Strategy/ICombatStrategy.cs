namespace Lesson_13_Classes_2.Strategy;

public interface ICombatStrategy
{
    string Name { get; }
    void Execute(Hero hero, Unit target);
}