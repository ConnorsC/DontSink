using UnityEngine;
using System.Collections;

public class EnemyShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;
    private int difficulty;
    private string shipModel;
    //tmp
    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static GameObject something;
    static string prefabPath = "Objects/Ships/Galleon";


    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }
    public int Difficulty { get { return difficulty; } set { difficulty = value; } }
    new public string ShipModel { get { return shipModel; } set { shipModel = value; } }

    public EnemyShipObject() { }
    public EnemyShipObject(ItemObject boon, int difficulty) : base(  100, 10, 10, null, items, crew, something, prefabPath)
    {
        this.boon = boon;
        this.difficulty = difficulty;
    }
}
