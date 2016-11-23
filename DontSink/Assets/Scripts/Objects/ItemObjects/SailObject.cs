using UnityEngine;
using System.Collections;

public class SailObject : ItemObject
{
    //Fields
    private int speed;

    //Accessors
    public int Speed { get { return speed; } set { speed = value; } }
}