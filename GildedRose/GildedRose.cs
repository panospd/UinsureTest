﻿using System;
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
                var adjustment = -1;

                if (item.SellIn <= 0)
                {
                    adjustment *= 2;
                }

                item.Quality = Math.Max(0, item.Quality + adjustment);
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
                        var adjustment = item.SellIn switch
                        {
                            <= 0 => -item.Quality,
                            <= 5 => 3,
                            <= 10 => 2,
                            _ => 1
                        };

                        item.Quality = Math.Min(50, item.Quality + adjustment);
                    }
                }
            }

            item.SellIn = item.SellIn - 1;
        }
    }
}