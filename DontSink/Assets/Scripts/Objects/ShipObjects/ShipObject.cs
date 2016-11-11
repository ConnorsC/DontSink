using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipObject
{
    //Fields
    private int health;
    private int speed;
    private int damage;
    private Material ship_texture;
    private List<ItemObject> items;

    //Accessors
    public int Health { get { return health; } set { health = value; } }
    public int Speed { get { return speed; } set { speed = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public Material Ship_Texture { get { return ship_texture; } set { ship_texture = value; } }
    public List<ItemObject> Items { get { return items; } set { items = value; } }
}
