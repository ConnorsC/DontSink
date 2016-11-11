using UnityEngine;
using System.Collections;

public class EnemyIslandObject : IslandObject
{
    //Fields
    private EnemyShipObject ship;

    //Accessors
    public EnemyShipObject Ship { get { return ship; } set { ship = value; } }
}
