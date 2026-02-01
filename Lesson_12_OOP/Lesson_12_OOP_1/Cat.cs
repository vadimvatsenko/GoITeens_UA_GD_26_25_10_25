namespace Lesson_12_OOP_1;

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {
    }


    public override void Say()
    {
        Console.WriteLine("I'm Cat, Meao");
    }

    public override void Eat()
    {
        Console.WriteLine("I'm Cat, I eat mouse");
    }

    public override void Walk()
    {
        Console.WriteLine("I'm Cat, I walk to the kitchen");
    }
    
}