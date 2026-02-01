namespace Lesson_12_OOP_1;

public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {
    }

    public override void Say()
    {
        Console.WriteLine("I am a dog, BaoWao");
    }

    public override void Eat()
    {
        Console.WriteLine("I am a dog, I eat meat");
    }

    public override void Walk()
    {
        Console.WriteLine("I am a dog, I walk to the yard");
    }
}