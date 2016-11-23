using UnityEngine;
using System.Collections;

public class ScreenLoad : MonoBehaviour {

    private GameObject playerShip;
    private GameManagerScript manager;

    // Use this for initialization
    void Start () {

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        playerShip = manager.GetPlayer().Ship.ShipModel;
        playerShip.transform.position = new Vector3(-10f,0f,-9f);
        playerShip.transform.Rotate(Vector3.up);
    }
}
