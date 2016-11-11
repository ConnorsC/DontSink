using UnityEngine;
using System.Collections;

public class DistressIslandObject : IslandObject
{
    //Fields
    private NeutralShipObject ship;

    //Accessors
    public NeutralShipObject Ship { get { return ship; } set { ship = value; } }
}
