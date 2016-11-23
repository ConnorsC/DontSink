using UnityEngine;
using System.Collections;

public class IslandObject
{
    public enum Relationship { Friendly, Neutral, Hostile };
    //Fields
    private GameObject islandModel;
    private Relationship relation;

    //Accessors
    public GameObject IslandModel { get { return islandModel; } set { islandModel = value; } }
    public Relationship Relation { get { return relation; } set { relation = value; } }
}
