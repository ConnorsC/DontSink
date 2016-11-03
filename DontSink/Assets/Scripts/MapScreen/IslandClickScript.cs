using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IslandClickScript : MonoInterface {

    public int island;

    // Use this for initialization
    void Start()
    {

    }

    public void OnMouseDown()
    {

        manager.SetIsland(island);
        manager.LoadLevel("GameScreen");

    }
}
