using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShipSelect : GameDriver{


    public void OnMouseDown()
    {
        manager.SetPlayerShip(gameObject);
        manager.LoadLevel("MapScreen");
            
    }

}
