using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandGenerator : MonoBehaviour
{
    private static System.Random rnd = new System.Random();

    public List<IslandObject> GenerateIslands(List<int> islands, int level)
    {
        List<IslandObject> ret = new List<IslandObject>();
        foreach (int isle in islands)
        {
            IslandObject tmp = GenerateIsland(isle, level);
            if(tmp != null)
                ret.Add(tmp);
        }
        return ret;
    }
    private IslandObject GenerateIsland(int isle, int level)
    {
        switch (isle)
        {
            case 0:
                return GenerateStartIsland(level);
            case 1:
                return GenerateMerchantIsland(level);
            case 2:
                return GenerateEnemyShip(level);
            case 3:
                return GenerateDistressShip(level);
            case 4:
                return GenerateEndIsland(level);
            default:
                return null;
        }
    }
    private MerchantIslandObject GenerateMerchantIsland(int lvl) // Adding no items to shops yet as there are none to add
    {
        List<ShopObject> shops = new List<ShopObject>();
        shops.Add(new NavalShop());
        shops.Add(new TavernObject());
        return new MerchantIslandObject(shops);
    }
    private EnemyIslandObject GenerateEnemyShip(int lvl)
    {
        ItemObject boon = new ItemObject(); // Adding no boon as we have no items atm
        int difficulty = rnd.Next(lvl/2, lvl+1); // Randomly select the difficulty based on the current level
        EnemyShipObject ship = new EnemyShipObject(boon, difficulty);
        return new EnemyIslandObject(ship);
    }
    private DistressIslandObject GenerateDistressShip(int lvl)
    {
        ItemObject boon = new ItemObject(); // Adding no boon as we have no items atm
        NeutralShipObject ship = new NeutralShipObject(boon);
        return new DistressIslandObject();
    }
    private StartIslandObject GenerateStartIsland(int lvl) // I don't know how we are going to be generating the text/story for this island yet so there is nothing here
    {
        return new StartIslandObject();
    }
    private EndIslandObject GenerateEndIsland(int lvl) // not sue what we are doing for the final island yet, mini boss fight? Or just chill to move on to the next level?
    {
        return new EndIslandObject();
    }
}
