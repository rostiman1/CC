using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [SetUp]
    public void SetUp()
    {
    }
    
    [Test]
    public void CheckingCtorGettingValidValues()
    {
        Hero hero = new Hero("pesho", 10);
        Assert.AreEqual("pesho", hero.Name);
        Assert.AreEqual(10, hero.Level);
    }
    [Test]
    public void CheckingCreateGettingValidValues()
    {
        Hero hero = new Hero("pesho", 10);
        HeroRepository data = new HeroRepository();
        data.Create(hero);
        Assert.AreEqual(1, data.Heroes.Count);
    }
    [Test]
    public void CheckingCreateNotGettingValidValuesName()
    {
        HeroRepository data = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => data.Create(null));
    }
    [Test]
    public void CheckingCreateNotGettingValidValuesExistingName()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("pesho", 13);
        data.Create(hero);
        Assert.Throws<InvalidOperationException>(() => data.Create(hero));
    }
    [Test]
    public void CheckingRemoveGettingValidValues()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("pesho", 13);
        data.Create(hero);
        data.Remove(hero.Name);
        Assert.AreEqual(0,data.Heroes.Count);
    }
    [Test]
    public void CheckingRemoveGettingNullValues()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("pesho", 13);
        data.Create(hero);
        data.Remove(hero.Name);
        Assert.Throws<ArgumentNullException>(()=> data.Remove(null));
    }
    [Test]
    public void CheckingGettingTheHeroHighestLevel()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("pesho", 13);
        Hero hero1 = new Hero("toshko", 15);
        Hero hero2 = new Hero("pettt", 30);
        data.Create(hero);
        data.Create(hero1);
        data.Create(hero2);
 
        Assert.AreEqual(hero2,data.GetHeroWithHighestLevel());
    }
    [Test]
    public void CheckingGettingTheHero()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("pesho", 13);
        Hero hero1 = new Hero("toshko", 15);
        Hero hero2 = new Hero("pettt", 30);
        data.Create(hero);
        data.Create(hero1);
        data.Create(hero2);

        Assert.AreEqual(hero2, data.GetHero("pettt"));
    }
}