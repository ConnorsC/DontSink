using UnityEngine;
using System.Collections;

public class MapScreenLoad : GameDriver {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;

    // Use this for initialization
    void Start () {
        print("map loaded managerlvl:" + manager.GetLevel());

        //playerShip = new GameObject("something");
        //playerShip = manager.GetPlayerShip().ShipModel;
        playerShip = Instantiate(Resources.Load("Objects/Ships/Dreadnought", typeof(GameObject))) as GameObject;

        if (playerShip == null)
        {
            print("it's null");
        }
        

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            playerShip.transform.position = new Vector3(-7.9f, 0f, -17f);
            //Instantiate(manager.GetPlayerShip().ShipModel, new Vector3(-8f, 0f, -6.5f), rotation);

        }

    }
    
    void OnLoad()
    {
        print("map loaded managerlvl:" + manager.GetLevel());
        
        if (manager.GetLevel() == 1) {
            print("loading 1");
            Instantiate(manager.GetPlayerShip().ShipModel, new Vector3(-8f, 0f, -6.5f), rotation);

        }

    }	

}
