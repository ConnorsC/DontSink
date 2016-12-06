using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DreadnoughtObject : PlayerShipObject
{

    static System.Collections.Generic.List<ItemObject> items;
    static System.Collections.Generic.List<CrewObject> crew;
    static HullObject hull;
    static GameObject shipModel;
    static string prefabPath = "Objects/Ships/BlackPearl";

    public DreadnoughtObject() : base(120, 6, 12, hull,items, crew, shipModel,prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Dreadnought");
        items = new List<ItemObject>();
    }
}
