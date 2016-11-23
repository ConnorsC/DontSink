using UnityEngine;
using System.Collections;

public class CorvetteObject : PlayerShipObject
{

    static Texture corvetteMat;
    static HullObject hull;
    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static GameObject shipModel;
    static string preFabPath = "Objects/Ships/Dreadnought";

    public CorvetteObject() : base(10, 10, 10, hull,items, crew, shipModel,preFabPath) { 


        }


}
