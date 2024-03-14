# Gilded Rose starting position in Csharp Core

## Build the project

Use your normal build tools. 

## Run the TextTest fixture from the Command-Line

For e.g. 10 days:

```
GildedRoseTests/bin/Debug/net8.0/GildedRoseTests 10
```

You should make sure the command shown above works when you execute it in a terminal before trying to use TextTest (see below). If your tooling has placed the executable somewhere else, you will need to adjust the path above.


## Run the TextTest approval test that comes with this project

There are instructions in the [TextTest Readme](../texttests/README.md) for setting up TextTest. You will need to specify the GildedRoseTests executable and interpreter in [config.gr](../texttests/config.gr). Uncomment this line:

    executable:${TEXTTEST_HOME}/csharpcore/GildedRoseTests/bin/Debug/net8.0/GildedRoseTests

# Assumptions made during development
1. Aged Brie upgrade with the same rate as normal items degrade.
2. Backstage passes increase by 1 when sellin days greater than 10
3. Item name matches to pattern when pattern is contained (exact words) in the item.name.
4. Did not touch the Item class, as I don't want to get shot by the goblin in the corner!
   - If I did, I would probably remove the public setters, introduce factory methods to instantiate an item and make sure that when an item is created, it is valid. For example Sulfuras items should have a quality of 80. Curently a sulfuras item could be created with a different quality value.

