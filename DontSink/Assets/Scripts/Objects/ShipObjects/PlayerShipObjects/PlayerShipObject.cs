using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipObject : ShipObject
{

    public PlayerShipObject() { }
    public PlayerShipObject(int health, int speed, int damage, List<ItemObject> items, GameObject shipModel, string prefabPath) : base(health, speed, damage,items,shipModel,prefabPath)
    {
    }


}
