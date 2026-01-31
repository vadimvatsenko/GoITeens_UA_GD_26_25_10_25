using System;
using NUnit.Framework;

[TestFixture]
public class KataTest
{
    [Test]
    public void KataTests()
    {
        Assert.That(Kata.ToCamelCase("the_stealth_warrior"), Is.EqualTo("theStealthWarrior"), "Kata.ToCamelCase('the_stealth_warrior')");
        Assert.That(Kata.ToCamelCase("The-Stealth-Warrior"), Is.EqualTo("TheStealthWarrior"), "Kata.ToCamelCase('The-Stealth-Warrior')");
    }
}