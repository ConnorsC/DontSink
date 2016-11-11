using UnityEngine;
using System.Collections;

public class IslandObject
{
    public enum Relationship { Friendly, Neutral, Hostile };
    //Fields
    private Material island_texture;
    private Relationship relation;

    //Accessors
    private Material Island_Texture { get { return island_texture; } set { island_texture = value; } }
    private Relationship Relation { get { return relation; } set { relation = value; } }
}
