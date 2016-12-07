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

    public BrigObject() : base(100, 10, 10, hull, CreateCannons(), crew, shipModel,cannonBallShooter,prefabPath) {
        shipModel = GameObject.FindGameObjectWithTag("Brig");
        cannonBallShooter = shipModel.GetComponent<CannonBallShooter>();
        items = new List<ItemObject>();
    }
    private static System.Collections.Generic.List<ItemObject> CreateCannons()
    {
        System.Collections.Generic.List<ItemObject> items = new System.Collections.Generic.List<ItemObject>();
        ItemGeneratorScript gen = new ItemGeneratorScript();
        items.Add(gen.makeCannon(7, 0, 5, Resources.Load<Sprite>("Images/cannon"), "Basic Cannon"));
        items.Add(gen.makeCannon(6, 0, 5, Resources.Load<Sprite>("Images/cannon"), "Basic Cannon"));
        items.Add(gen.makeCannon(5, 0, 5, Resources.Load<Sprite>("Images/cannon"), "Basic Cannon"));
        items.Add(gen.makeCannon(4, 0, 5, Resources.Load<Sprite>("Images/cannon"), "Basic Cannon"));
        return items;
    }
}
