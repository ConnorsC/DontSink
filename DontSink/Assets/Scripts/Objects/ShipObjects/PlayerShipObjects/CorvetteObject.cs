using UnityEngine;
using System.Collections;

public class CorvetteObject : PlayerShipObject
{

    static Texture corvetteMat;
    static System.Collections.Generic.List<ItemObject> items;
    static GameObject shipModel;
    static string preFabPath = "Objects/Ships/Dreadnought";

    public CorvetteObject() : base(10, 10, 10, items,shipModel,preFabPath) { 


        }


}
