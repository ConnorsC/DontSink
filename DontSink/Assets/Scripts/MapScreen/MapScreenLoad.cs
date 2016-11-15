using UnityEngine;
using System.Collections;

public class MapScreenLoad : GameDriver {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;

    // Use this for initialization
    void Start () {
        print("map loaded managerlvl:" + manager.GetLevel());

        playerShip = new GameObject("something");
        //playerShip = manager.GetPlayerShip().ShipModel;

        if(playerShip == null)
        {
            print("it's null");
        }
        

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            Instantiate(playerShip, new Vector3(-8f, 0f, -6.5f), Quaternion.identity);
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
