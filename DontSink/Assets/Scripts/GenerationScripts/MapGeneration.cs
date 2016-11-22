using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGeneration
{
    private static System.Random rnd = new System.Random();

    public List<IslandObject> GenerateMap(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return GenerateLevelOne();
            case 2:
                return GenerateLevelTwo();
            case 3:
                return GenerateLevelThree();
            default:
                return null;
        }
    }
    private List<IslandObject> GenerateLevelOne()
    {
        List<int> islands = new List<int>();
        IslandGenerator island_gen = new IslandGenerator();
        const int level = 1;
        const int end_island = 7;
        int shop_island = rnd.Next(1, end_island); // Random number: 1<=shop_island<end_island
        int distress_island = rnd.Next(1, end_island); // Random number: 1<=shop_island<end_island
        while(shop_island== distress_island) // Ensure that we aren't trying to add the shop and distress islands to the same island number
            distress_island = rnd.Next(1, end_island);
        for (int i = 0; i < end_island+1; i++)
        {
            if (i == 0)
                islands.Add(0); // Start Island
            else if (i == shop_island)
                islands.Add(1); // Merchant Island
            else if (i == distress_island)
                islands.Add(3); // Distress Island
            else if (i == end_island)
                islands.Add(4); // End Island
            else
                islands.Add(2);// Enemy Island
        }
        return island_gen.GenerateIslands(islands, level);
    }
    // Nothing yet for levels two and three as we have no levels two and three yet
    private List<IslandObject> GenerateLevelTwo()
    {
        return new List<IslandObject>();
    }
    private List<IslandObject> GenerateLevelThree()
    {
        return new List<IslandObject>();
    }
}
