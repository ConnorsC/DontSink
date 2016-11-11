using UnityEngine;
using System.Collections;

public class ScoutObject : CrewObject
{
    //Fields
    private int vision_increase;

    //Accessors
    public int Vision_Increase { get { return vision_increase; } set { vision_increase = value; } }
}
