using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipObject
{
    //Fields
    private int health;
    private int speed;
    private int damage;
    private List<ItemObject> items;
    private GameObject shipModel;
    private string prefabPath;

    public ShipObject()
    {

    }

    public ShipObject(int health, int speed, int damage, List<ItemObject> items, GameObject shipModel, string prefabPath)
    {
        this.health = health;
        this.speed = speed;
        this.damage = damage;
        this.items = items;
        this.shipModel = shipModel;
        this.prefabPath = prefabPath;
    }

    //Accessors
    public int Health { get { return health; } set { health = value; } }
    public int Speed { get { return speed; } set { speed = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public List<ItemObject> Items { get { return items; } set { items = value; } }
    public GameObject ShipModel { get { return shipModel; } set { shipModel = value; } }
    public string getPrefabPath { get { return prefabPath; } set { prefabPath = value; } }
}
