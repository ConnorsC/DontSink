using UnityEngine;
using System.Collections;

public class MapScreenLoad : GameDriver {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;

    // Use this for initialization
    void Start () {

        playerShip = Instantiate(Resources.Load(manager.GetPlayer().Ship.getPrefabPath, typeof(GameObject))) as GameObject;

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            playerShip.transform.position = new Vector3(-7.9f, 0f, -17f);

        }

    }
}
