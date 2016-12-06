using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

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
        //int shop_island = 1; // For the presentation set the shop island to island 2
        int distress_island = rnd.Next(1, end_island); // Random number: 1<=shop_island<end_island
        while (shop_island == distress_island) // Ensure that we aren't trying to add the shop and distress islands to the same island number
            distress_island = rnd.Next(1, end_island);
        for (int i = 0; i < end_island + 1; i++)
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

    private List<IslandObject> GenerateLevelTwo()
    {
        List<int> islands = new List<int>();
        IslandGenerator island_gen = new IslandGenerator();
        const int level = 2;
        const int totalIslands = 16;
        int shop_island1;
        int shop_island2;
        int shop_island3;
        int distress_island1;
        int distress_island2;

        //9 is the end island 
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16 };

        int index = rnd.Next(ints.Count);
        shop_island1 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        shop_island2 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        shop_island3 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        distress_island1 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        distress_island2 = ints[index];
        ints.RemoveAt(index);

        for (int i = 0; i < totalIslands + 1; i++)
        {
            if (i == 0)
                islands.Add(0); // Start Island
            else if (i == shop_island1 || i == shop_island2 || i == shop_island3)
                islands.Add(1); // Merchant Island

            else if (i == distress_island1 || i == distress_island2)
                islands.Add(3); // Distress Island

            else if (i == 9)
                islands.Add(4); // End Island
            else
                islands.Add(2);// Enemy Island
        }
        return island_gen.GenerateIslands(islands, level);
    }

    private List<IslandObject> GenerateLevelThree()
    {
        List<int> islands = new List<int>();
        IslandGenerator island_gen = new IslandGenerator();
        const int level = 3;
        const int totalIslands = 16;
        int shop_island1;
        int shop_island2;
        int shop_island3;
        int distress_island1;
        int distress_island2;

        //9 is the end island 
        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16 };

        int index = rnd.Next(ints.Count);
        shop_island1 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        shop_island2 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        shop_island3 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        distress_island1 = ints[index];
        ints.RemoveAt(index);

        index = rnd.Next(ints.Count);
        distress_island2 = ints[index];
        ints.RemoveAt(index);

        for (int i = 0; i < totalIslands + 1; i++)
        {
            if (i == 0)
                islands.Add(0); // Start Island
            else if (i == shop_island1 || i == shop_island2 || i == shop_island3)
                islands.Add(1); // Merchant Island

            else if (i == distress_island1 || i == distress_island2)
                islands.Add(3); // Distress Island

            else if (i == 9)
                islands.Add(4); // End Island
            else
                islands.Add(2);// Enemy Island
        }
        return island_gen.GenerateIslands(islands, level);
    }
}
