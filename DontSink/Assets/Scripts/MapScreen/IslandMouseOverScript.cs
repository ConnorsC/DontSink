using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandMouseOverScript : MonoBehaviour
{
    public int island;
    private GameManagerScript manager;
    private LineRenderer islandLine;
    public Material lineMaterial;
    static string island1 = "Objects/Lines/OverlayIsland1";
    static string island2 = "Objects/Lines/OverlayIsland2";
    static string island3 = "Objects/Lines/OverlayIsland3";
    static string island4 = "Objects/Lines/OverlayIsland4";
    static string island5 = "Objects/Lines/OverlayIsland5";
    static string island6 = "Objects/Lines/OverlayIsland6";
    static string island7 = "Objects/Lines/OverlayIsland7";
    static string island8 = "Objects/Lines/OverlayIsland8";
    GameObject overlay;
    // Use this for initialization

    void Start () {

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        islandLine = GetComponent<LineRenderer>();
        islandLine.SetVertexCount(8);
        islandLine.SetWidth(.2f, .2f);
        islandLine.material = lineMaterial;
    }
	
	void OnMouseOver ()
    {

        List<int> connectedIslands = FindIsland(island).ConnectedIsland;

        int target1 = connectedIslands[0];
        int target2 = connectedIslands[1];
        int target3 = connectedIslands[2];
        int target4 = connectedIslands[3];
        print("my Island: " + island + " connections :\n " + connectedIslands[0] +"   "+ connectedIslands[1] + "   " + connectedIslands[2] + "   " + connectedIslands[3]);
    
        islandLine.enabled=true;

        if (target1 != 0) {
            islandLine.SetPosition(0, transform.position);
            islandLine.SetPosition(1, FindIsland(target1).IslandModel.transform.position);
            islandLine.SetPosition(2, transform.position);
        }
        if (target2  != 0) {       
            islandLine.SetPosition(3, FindIsland(target2).IslandModel.transform.position);
            islandLine.SetPosition(4, transform.position);
        }
        if (target3 != 0)
        {
            islandLine.SetPosition(5, FindIsland(target3).IslandModel.transform.position);
            islandLine.SetPosition(6, transform.position);
        }
        if (target4 != 0)
        {
            islandLine.SetPosition(7, FindIsland(target4).IslandModel.transform.position);
        }
    }

    public IslandObject FindIsland(int islandToFind)
    {
        List<IslandObject> islands = manager.Islands;

        for(int x =0; x<= islands.Count; x++)
        {

            if(islands[x].IslandNumber == islandToFind)
            {
                return islands[x];
            }
        }

        print("couldent find island: " + islandToFind);
        return null;
    }

    void OnMouseExit()
    {
        islandLine.enabled = false;
        GameObject[] overlays = GameObject.FindGameObjectsWithTag("IslandOverlayLine");
        foreach (GameObject line in overlays)
        {
            Destroy(line);
        }
    }
}
