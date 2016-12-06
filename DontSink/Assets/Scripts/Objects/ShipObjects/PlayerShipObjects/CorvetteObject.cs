using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CorvetteObject : PlayerShipObject
{

    static Texture corvetteMat;
    static HullObject hull;
    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static GameObject shipModel;
    static CannonBallShooter cannonBallShooter;
    static string preFabPath = "Objects/Ships/Xebec";

    public CorvetteObject() : base(80, 14, 8, hull,items, crew, shipModel, cannonBallShooter, preFabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Corvette");
        cannonBallShooter = shipModel.GetComponent<CannonBallShooter>();
        items = new List<ItemObject>();
    }


}
