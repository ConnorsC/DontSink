using UnityEngine;

public class DreadnoughtObject : PlayerShipObject
{

    static System.Collections.Generic.List<ItemObject> items;
    static GameObject shipModel;
    static string prefabPath = "Objects/Ships/Dreadnought";

    public DreadnoughtObject() : base(10, 10, 10, items,shipModel,prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Dreadnought");
        
    }
}
