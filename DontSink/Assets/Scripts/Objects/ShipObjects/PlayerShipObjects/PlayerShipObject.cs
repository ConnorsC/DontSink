using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipObject : ShipObject
{

    public PlayerShipObject() { }
    public PlayerShipObject(int health, int speed, int damage, HullObject hull, List<ItemObject> items, List<CrewObject> crew, GameObject shipModel, CannonBallShooter cannonBallShooter, string prefabPath) : base(health, speed, damage,hull,items,crew,shipModel, cannonBallShooter, prefabPath)
    {
        
    }
}
