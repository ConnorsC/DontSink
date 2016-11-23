using UnityEngine;
using System.Collections;

public class ScreenLoad : MonoBehaviour {

    private GameObject playerShip;
    private GameManagerScript manager;

    // Use this for initialization
    void Start () {

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        playerShip = manager.GetPlayer().Ship.ShipModel;
        playerShip.transform.position = new Vector3(-10f,0f,-10f);
        playerShip.transform.Rotate(new Vector3(0f,-90f,0f));
    }
}
