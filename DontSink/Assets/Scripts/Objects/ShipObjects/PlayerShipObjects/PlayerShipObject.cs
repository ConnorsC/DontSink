using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipObject : ShipObject
{
    private ShipObject playerShip;

    public PlayerShipObject(ShipObject ship)
    {
        playerShip = ship;
    }
    public PlayerShipObject() { }
    public PlayerShipObject(int health, int speed, int damage, HullObject hull, List<ItemObject> items, List<ItemObject> crew, GameObject shipModel, string prefabPath) : base(health, speed, damage,hull,items,crew,shipModel,prefabPath)
    {
    }
}
