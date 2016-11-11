using UnityEngine;
using System.Collections;

public class SailObject : ItemObject
{
    //Fields
    private double speed;

    //Accessors
    public double Speed { get { return speed; } set { speed = value; } }
}