using UnityEngine;
using System.Collections;

public class GameDriver : MonoBehaviour {

    public GameManagerScript manager;
    public static GameDriver instance = null;

    // Use this for initialization
    void Start () {

    }

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
