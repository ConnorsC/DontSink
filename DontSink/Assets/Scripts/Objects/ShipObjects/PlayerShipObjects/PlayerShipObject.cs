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
    public PlayerShipObject(int health, int speed, int damage, List<ItemObject> items, GameObject shipModel) : base(health, speed, damage,items,shipModel)

    { }


}
