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
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
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
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(2, 40, 43)]
    [TestCase(5, 39, 42)]
    [TestCase(6, 38, 40)]
    [TestCase(10, 36, 38)]
    [TestCase(11, 35, 36)]
    [TestCase(12, 37, 38)]
    [TestCase(2, 49, 50)]
    [TestCase(1, 30, 33)]
    [TestCase(0, 30, 0)]
    public void WhenItemIsBackstagePasses_ShouldUpdateQualityAccordingly(int sellIn, int quality, int expectedQuality)
    {
        // Arrange
        var name = "Backstage passes to a TAFKAL80ETC concert";
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(2, 40, 41)]
    [TestCase(1, 39, 40)]
    [TestCase(0, 38, 40)]
    [TestCase(-1, 42, 44)]
    [TestCase(-2, 49, 50)]
    [TestCase(-3, 50, 50)]
    public void WhenItemIsAgedBrie_ShouldUpdateQualityAccordingly(int sellIn, int quality, int expectedQuality)
    {
        // Arrange
        var name = "Aged Brie";
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(2, 40, 38)]
    [TestCase(1, 39, 37)]
    [TestCase(0, 38, 34)]
    [TestCase(-1, 36, 32)]
    [TestCase(-5, 1, 0)]
    [TestCase(0, 0, 0)]
    public void WhenItemIsConjured_ShouldUpdateQualityAccordingly(int sellIn, int quality, int expectedQuality)
    {
        // Arrange
        var name = "Conjured";
        var items = new List<Item> { new() { Name = name, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));
    }
}