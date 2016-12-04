using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour
{
    private GameManagerScript manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }
    public void onClick()
    {
        manager.LoadLevel("SplashScreen");
        manager.Reset();
    }
}
