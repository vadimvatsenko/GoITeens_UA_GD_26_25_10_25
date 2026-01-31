namespace Lesson_10_CodeWars_2;

using NUnit.Framework;
[TestFixture]

class KataTest
{
    [Test]
    public void Test()
    {
        Assert.That(Kata.UnusualFive(), Is.EqualTo(5));
    }
    
    [Test]
    public void Test1()
    {
        Assert.That(Kata.UnusualFive(), Is.EqualTo(3));
    }
}


