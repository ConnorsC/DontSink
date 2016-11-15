using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipSelect : GameDriver{


    public void OnMouseDown()
    {
        if(gameObject.tag=="ship1")
        {
            manager.SetPlayerShip(new BrigObject());
        }
        else if (gameObject.tag == "ship2")
        {
            manager.SetPlayerShip(new CorvetteObject());
        }
        else if (gameObject.tag == "Dreadnought")
        {
            manager.SetPlayerShip(new DreadnoughtObject());
        }

        manager.SetIsland(1);
        manager.SetLevel(1);
        manager.LoadLevel("MapScreen");
            
    }

}
