namespace Lesson_12_OOP_1;

public class Mouse : Animal
{
    public Mouse(string name, int age) : base(name, age)
    {
    }

    public override void Say()
    {
        Console.WriteLine("I am a mouse, Pi-Pi");
    }

    public override void Eat()
    {
        Console.WriteLine("I am a mouse, i eat cheese");
    }

    public override void Walk()
    {
        Console.WriteLine("I am a mouse, i bedroom");
    }
}