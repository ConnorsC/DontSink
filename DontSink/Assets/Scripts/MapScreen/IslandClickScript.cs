using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IslandClickScript : GameDriver {

    public int island;

    // Use this for initialization
    void Start()
    {

    }

    public void OnMouseDown()
    {
        manager.SetIsland(island);
        //print("Island: " + island);
        manager.LoadLevel("GameScreen");
    }
    
}
