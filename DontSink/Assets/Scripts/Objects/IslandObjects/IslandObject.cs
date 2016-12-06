using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandObject
{
    public enum Relationship { Friendly, Neutral, Hostile };
    //Fields
    private GameObject islandModel;
    private Relationship relation;
    private List<int> connectedIsland;
    private int islandNumber;

    //Accessors
    public GameObject IslandModel { get { return islandModel; } set { islandModel = value; } }
    public List<int> ConnectedIsland { get { return connectedIsland; } set { connectedIsland = value; } }
    public Relationship Relation { get { return relation; } set { relation = value; } }
    public int IslandNumber { get { return islandNumber; } set { islandNumber = value; } }
}
