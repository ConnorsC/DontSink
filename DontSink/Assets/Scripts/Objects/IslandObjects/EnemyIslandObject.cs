using UnityEngine;
using System.Collections;

public class EnemyIslandObject : IslandObject
{
    //Fields
    private EnemyShipObject ship;
    private bool defeated = false;

    //Accessors
    public EnemyShipObject Ship { get { return ship; } set { ship = value; } }
    public bool Defeated { get { return defeated; } set { defeated = value; } }

    public EnemyIslandObject() { }
    public EnemyIslandObject(EnemyShipObject ship)
    {
        this.ship = ship;
    }
}
