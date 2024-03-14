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

    [TestCase(2, 40, 39)]
    [TestCase(1, 39, 38)]
    [TestCase(0, 38, 36)]
    [TestCase(-1, 36, 34)]
    [TestCase(-5, 1, 0)]
    [TestCase(0, 0, 0)]
    public void WhenItemIsNormal_ShouldUpdateQualityAccordingly(int sellIn, int quality, int expectedQuality)
    {
        // Arrange
        var name = "normal item";
        var items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }
}