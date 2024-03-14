using System;
using System.Collections.Generic;

namespace GildedRoseKata;

#nullable enable
public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            ApplyQualityAdjustmentTo(
                item,
                AdjustmentFor(item),
                item => item.SellIn--);
        }
    }

    private static void ApplyQualityAdjustmentTo(Item item, Func<Item, int>? adjustment, Action<Item> after)
    {
        if (adjustment is null) return;

        item.Quality += adjustment(item);

        if (item.Quality < 0)
        {
            item.Quality = 0;
        }

        if (item.Quality > 50)
        {
            item.Quality = 50;
        }

        after(item);
    }

    private static Func<Item, int>? AdjustmentFor(Item item)
    {
        return item.Name switch
        {
            "Backstage passes to a TAFKAL80ETC concert" => (item) =>
            {
                return item.SellIn switch
                {
                    <= 0 => -item.Quality,
                    <= 5 => 3,
                    <= 10 => 2,
                    _ => 1
                };
            }
            ,
            "Aged Brie" => (item) =>
            {
                var adjustment = 1;

                if (item.SellIn <= 0)
                {
                    adjustment *= 2;
                }

                return adjustment;
            }
            ,
            "Sulfuras, Hand of Ragnaros" => null,
            _ => (item) =>
            {
                var adjustment = -1;

                if (item.SellIn <= 0)
                {
                    adjustment *= 2;
                }

                return adjustment;
            }
        };
    }
}