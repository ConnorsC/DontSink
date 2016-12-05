using UnityEngine;
using System.Collections;

public class DistressIslandObject : IslandObject
{
    //Fields
    private NeutralShipObject ship;
    private int defeated = 0;

    public DistressIslandObject(NeutralShipObject ship)
    {
        this.ship = ship;
    }

    //Accessors
    public NeutralShipObject Ship { get { return ship; } set { ship = value; } }
    public int Defeated { get { return defeated; } set { defeated = value; } }
}
