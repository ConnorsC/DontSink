using UnityEngine;
using System.Collections;

public class GameDriver : MonoBehaviour {

    public GameManagerScript manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
