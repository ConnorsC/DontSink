using UnityEngine;
using System.Collections;

public class EndIslandObject : IslandObject
{
    private EnemyShipObject ship;
    public EnemyShipObject Ship { get { return ship; } set { ship = value; } }

    public EndIslandObject() { }
    public EndIslandObject(EnemyShipObject ship)
    {
        this.ship = ship;
    }
}
