using UnityEngine;
using System.Collections;

public class RacerObject : CrewObject
{
    //Fields
    private double speed_buff;

    //Accessors
    public double Speed_Buff { get { return speed_buff; } set { speed_buff = value; } }
}
