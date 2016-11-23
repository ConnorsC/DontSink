using UnityEngine;

public class DreadnoughtObject : PlayerShipObject
{

    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<ItemObject> crew;
    static HullObject hull;
    static GameObject shipModel = GameObject.FindGameObjectWithTag("Dreadnought");
    static string prefabPath = "Objects/Ships/Dreadnought";

    public DreadnoughtObject() : base(10, 10, 10, hull, items, crew,shipModel,prefabPath) {


    }
}
