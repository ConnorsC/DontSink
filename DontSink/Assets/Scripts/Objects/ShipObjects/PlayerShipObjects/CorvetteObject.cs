using UnityEngine;
using System.Collections;

public class CorvetteObject : PlayerShipObject
{

    static Texture corvetteMat;
    static HullObject hull;
    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static GameObject shipModel;
    static string preFabPath = "Objects/Ships/Xebec";

    public CorvetteObject() : base(80, 14, 8, hull,items, crew, shipModel,preFabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Corvette");

    }


}
