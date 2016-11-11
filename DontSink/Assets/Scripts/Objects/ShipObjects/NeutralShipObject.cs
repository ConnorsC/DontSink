using UnityEngine;
using System.Collections;

public class NeutralShipObject : ShipObject
{
    //Fields 
    private ItemObject boon;

    //Accessors
    public ItemObject Boon { get { return boon; } set { boon = value; } }
}
