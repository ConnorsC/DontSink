using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrigObject : PlayerShipObject
{
    //public string prefabPath = "";
    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static HullObject hull;
    static GameObject shipModel;
    static CannonBallShooter cannonBallShooter;
    static string prefabPath = "Objects/Ships/Galleon";

    public BrigObject() : base(100, 10, 10, hull,items, crew, shipModel,cannonBallShooter,prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Brig");
        cannonBallShooter = shipModel.GetComponent<CannonBallShooter>();
        items = new List<ItemObject>();
    }
}
