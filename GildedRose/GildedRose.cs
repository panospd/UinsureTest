using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            Item item = _items[i];

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            var adjustment = AdjustmentFor(item);
            ApplyQualityAdjustment(item, adjustment(item));

            item.SellIn = item.SellIn - 1;
        }
    }

    private void ApplyQualityAdjustment(Item item, int adjustment)
    {
        item.Quality += adjustment;

        if (item.Quality < 0)
        {
            item.Quality = 0;
        }

        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
    }

    private Func<Item, int> AdjustmentFor(Item item)
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