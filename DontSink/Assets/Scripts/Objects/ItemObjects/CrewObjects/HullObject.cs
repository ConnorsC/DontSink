using UnityEngine;
using System.Collections;

public class HullObject : ItemObject
{
    //Fields
    private int damage_reduction;
    private int health;

    //Accessors
    public int Damage_Reduction { get { return damage_reduction; } set { damage_reduction = value; } }
    public int Health { get { return health; } set { health = value; } }

    public HullObject() { }
    public HullObject(int dr, int hp)
    {
        this.damage_reduction = dr;
        this.health = hp;
    }

    public void TakeDamage()
    {
        if (health <= damage_reduction)
        {
            health = 0;
            DestroyHull();
        }
        else
            health -= damage_reduction;
    }
    private void DestroyHull()
    { }
}
