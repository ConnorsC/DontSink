using UnityEngine;

public class ShipSelect : GameDriver{
    private GameObject playerShip;

    public void OnMouseDown()
    {
        if(gameObject.tag=="ship1")
        {
            manager.GetPlayer().Ship=(new BrigObject());
        }
        else if (gameObject.tag == "ship2")
        {
            manager.GetPlayer().Ship = (new CorvetteObject());
        }
        else if (gameObject.tag == "Dreadnought")
        {
            manager.GetPlayer().Ship = (new DreadnoughtObject());
        }

        manager.SetIsland(1);
        manager.SetLevel(1);
        manager.LoadLevel("MapScreen");
            
    }

}
