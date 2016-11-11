using UnityEngine;
using System.Collections;

public class RepairmanObject : CrewObject
{
    //Fields
    private int repair_rate;
    private double max_repair; //The max percentage of ship damage taken that he can repair

    //Accessors
    public int Repair_Rate { get { return repair_rate; } set { repair_rate = value; } }
    public double Max_Repair { get { return max_repair; } set { max_repair = value; } }
}