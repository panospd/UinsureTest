using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class ItemMatcherTests
{
    [TestCase("Aged Brie", "Aged Brie", true)]
    [TestCase("Aged Brie", "Aged Brie, an excellent choice", true)]
    [TestCase("Aged Brie", "An excellent choice,Aged Brie.", true)]
    [TestCase("Aged Brie", "An excellent choice,Aged Brie.", true)]
    [TestCase("Aged Brie", "Aged Bri", false)]
    [TestCase("Aged Brie", "Aged Brieada", false)]
    [TestCase("Aged Brie", "ExcellentAged Brie", false)]
    [TestCase("Aged Brie", "AgedBrie", false)]
    public void Is_WhenCalled_ShouldReturnMatchOrNot(string match, string name, bool expectedResult)
    {
        // Arrange
        var item = new Item { Name = name };

        // Act
        var result = item.Is(match);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}