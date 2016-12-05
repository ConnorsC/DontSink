using UnityEngine;
using System.Collections;

public class HullObject : ItemObject
{
    //Fields
    private int damage_reduction;
    private MaxCurrentPair<int> health;

    //Accessors
    public int Damage_Reduction { get { return damage_reduction; } set { damage_reduction = value; } }
    public int MaxHealth { get { return health.Max; } set { health.Max = value; } }
    public int CurrentHealth { get { return health.Current; } set { health.Current = value; } }

    public HullObject() { }
    public HullObject(int dr, int hp)
    {
        this.damage_reduction = dr;
        this.health = new MaxCurrentPair<int>(hp);
    }

    public void TakeDamage()
    {
        if (health.Current <= damage_reduction)
        {
            health.Current = 0;
            DestroyHull();
        }
        else
            health.Current -= damage_reduction;
    }
    private void DestroyHull()
    { }
}
