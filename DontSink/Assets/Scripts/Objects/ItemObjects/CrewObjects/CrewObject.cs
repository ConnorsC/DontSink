using UnityEngine;
using System.Collections;

public class CrewObject : ItemObject
{
    //Fields
    private double speed_buff;
    private double reload_Buff;

    public CrewObject() { }
    //Accessors
    public double Speed_Buff { get { return speed_buff; } set { speed_buff = value; } }
    public double Reload_Buff { get { return reload_Buff; } set { reload_Buff = value; } }
}
