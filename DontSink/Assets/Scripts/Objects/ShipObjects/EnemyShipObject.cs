using UnityEngine;
using System.Collections;

public class EnemyShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;
    private int difficulty;
    private string shipModel;


    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }
    public int Difficulty { get { return difficulty; } set { difficulty = value; } }
    new public string ShipModel { get { return shipModel; } set { shipModel = value; } }

    public EnemyShipObject() { }
    public EnemyShipObject(ItemObject boon, int difficulty)
    {
        this.boon = boon;
        this.difficulty = difficulty;
    }
}
