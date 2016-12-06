using UnityEngine;
using System.Collections;

public class SailObject : ItemObject
{
    //Fields
    private int speed;

    public SailObject(){}

    public SailObject(Sprite icon, string name, int val, int speed):base(icon, name, val)
    {
        this.speed = speed;
    }

    //Accessors
    public int Speed { get { return speed; } set { speed = value; } }
}