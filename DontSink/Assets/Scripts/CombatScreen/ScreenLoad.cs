using UnityEngine;
using System.Collections;

public class ScreenLoad : GameDriver {

    GameObject playerShip;

    // Use this for initialization
    void Start () {

        playerShip = manager.GetPlayer().Ship.ShipModel;

        playerShip = Instantiate(Resources.Load(manager.GetPlayer().Ship.getPrefabPath, typeof(GameObject))) as GameObject;
        playerShip.transform.position = new Vector3(-10f,0f,-9f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
