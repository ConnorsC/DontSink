using UnityEngine;
using System.Collections;

public class NeutralShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;

    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static HullObject hull;
    static GameObject shipModel;
    static string prefabPath = "Objects/Ships/DistressShip1";

    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }

    public NeutralShipObject() { }
    public NeutralShipObject(ItemObject boon) : base(100, 10, 10, hull, items, crew, shipModel, prefabPath)
    {
        this.boon = boon;
    }
}
