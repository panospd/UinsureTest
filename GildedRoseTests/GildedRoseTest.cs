using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [TestCase(1, 80, 80)]
    [TestCase(0, 80, 80)]
    [TestCase(-1, 80, 80)]
    public void WhenItemIsSulfuras_ShouldNotUpdateQualityOrSellIn(int sellIn, int quality, int expectedQuality)
    {
        // Arrange
        var name = "Sulfuras, Hand of Ragnaros";
        var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }
}