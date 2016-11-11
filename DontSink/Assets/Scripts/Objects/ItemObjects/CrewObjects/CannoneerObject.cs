using UnityEngine;
using System.Collections;

public class CannoneerObject : CrewObject
{
    //Fields
    private double damage_buff;

    //Accessors
    public double Damage_Buff { get { return damage_buff; } set { damage_buff = value; } }
}
