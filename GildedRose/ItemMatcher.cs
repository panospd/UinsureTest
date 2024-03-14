using System.Text.RegularExpressions;

namespace GildedRoseKata;

public static class ItemMatcher
{
    public static bool Is(this Item item, string match)
    {
        return Regex.IsMatch(item.Name, $@"\b{match}\b");
    }
}
