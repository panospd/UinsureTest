﻿using System;
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
                then: item => item.SellIn--);
        }
    }

    private static void ApplyQualityAdjustmentTo(Item item, Func<Item, int>? adjustment, Action<Item> then)
    {
        if (adjustment is null) return;

        item.Quality = Math.Min(50, Math.Max(0, item.Quality + adjustment(item)));
        then(item);
    }

    private static Func<Item, int>? AdjustmentFor(Item currentItem)
    {
        return currentItem switch
        {
            var item when item.Is("Backstage passes") => (item) =>
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
            var item when item.Is("Aged Brie") => (item) => -1 * NormalItemAdjustment(item)
            ,
            var item when item.Is("Conjured") => (item) => 2 * NormalItemAdjustment(item)
            ,
            var item when item.Is("Sulfuras") => null,
            _ => NormalItemAdjustment
        };
    }

    private static Func<Item, int> NormalItemAdjustment => (item) =>
    {
        var adjustment = -1;
        return item.SellIn > 0 ? adjustment : adjustment * 2;
    };

}