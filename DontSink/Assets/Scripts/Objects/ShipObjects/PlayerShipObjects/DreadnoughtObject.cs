using UnityEngine;

public class DreadnoughtObject : PlayerShipObject
{

    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static HullObject hull;
    static GameObject shipModel;
    //static string prefabPath = "Objects/Ships/Dreadnought";
    static string prefabPath = "Objects/Ships/BlackPerl";

    public DreadnoughtObject() : base(10, 10, 10, hull,items, crew, shipModel,prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Dreadnought");
        
    }
}
