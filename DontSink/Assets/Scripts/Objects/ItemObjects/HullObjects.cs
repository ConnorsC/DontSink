using UnityEngine;
using System.Collections;

public class HullObjects : ItemObject
{
    //Fields
    private int damage_reduction;
    private int health;

    //Accessors
    public int Damage_Reduction { get { return damage_reduction; } set { damage_reduction = value; } }
    public int Health { get { return health; } set { health = value; } }
}
