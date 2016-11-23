using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandMouseOverScript : MonoBehaviour
{
    public int island;
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
	
	}
	
	void OnMouseOver ()
    {
	    switch(island)
        {
            case 1:
                overlay = Instantiate(Resources.Load(island1, typeof(GameObject))) as GameObject;
                break;
            case 2:
                overlay = Instantiate(Resources.Load(island2, typeof(GameObject))) as GameObject;
                break;
            case 3:
                overlay = Instantiate(Resources.Load(island3, typeof(GameObject))) as GameObject;
                break;
            case 4:
                overlay = Instantiate(Resources.Load(island4, typeof(GameObject))) as GameObject;
                break;
            case 5:
                overlay = Instantiate(Resources.Load(island5, typeof(GameObject))) as GameObject;
                break;
            case 6:
                overlay = Instantiate(Resources.Load(island6, typeof(GameObject))) as GameObject;
                break;
            case 7:
                overlay = Instantiate(Resources.Load(island7, typeof(GameObject))) as GameObject;
                break;
            case 8:
                overlay = Instantiate(Resources.Load(island8, typeof(GameObject))) as GameObject;
                break;
            default:
                break;
        }
	}

    void OnMouseExit()
    {
        GameObject[] overlays = GameObject.FindGameObjectsWithTag("IslandOverlayLine");
        foreach (GameObject line in overlays)
        {
            Destroy(line);
        }
    }
}
