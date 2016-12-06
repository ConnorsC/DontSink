using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DreadnoughtObject : PlayerShipObject
{

    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static HullObject hull;
    static GameObject shipModel;
    static CannonBallShooter cannonBallShooter;
    static string prefabPath = "Objects/Ships/BlackPearl";

    public DreadnoughtObject() : base(120, 6, 12, hull,items, crew, shipModel, cannonBallShooter, prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Dreadnought");
        cannonBallShooter = shipModel.GetComponent<CannonBallShooter>();
        items = new List<ItemObject>();
    }
}
