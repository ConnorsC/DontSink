using UnityEngine;
using System.Collections;

public class CannonObject : ItemObject
{
    //Fields
    private int fire_rate;
    private int damage;

    public CannonObject() { }
    //Accessors
    public int Fire_Rate{ get { return fire_rate; } set { fire_rate = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
}
