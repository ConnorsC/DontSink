using UnityEngine;
using System.Collections;

public class EnemyShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;
    private int difficulty;

    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }
    public int Difficulty { get { return difficulty; } set { difficulty = value; } }
}
