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

            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                var adjustment = AdjustmentFor(item);
                item.Quality = Math.Max(0, item.Quality + adjustment(item));
            }
            else
            {
                if (item.Quality < 50)
                {
                    if (item.Name == "Aged Brie")
                    {
                        var adjustment = 1;

                        if (item.SellIn <= 0)
                        {
                            adjustment *= 2;
                        }

                        item.Quality = Math.Min(50, item.Quality + adjustment);
                    }

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        var adjustment = AdjustmentFor(item);
                        item.Quality = Math.Min(50, item.Quality + adjustment(item));
                    }
                }
            }

            item.SellIn = item.SellIn - 1;
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