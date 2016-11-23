using UnityEngine;

public class ShipSelect : MonoBehaviour{
    private GameObject playerShip;
    private GameManagerScript manager;
    private GameObject selectedShip;

    public void OnMouseDown()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        if (gameObject.tag=="ship1")
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
            selectedShip = GameObject.FindGameObjectWithTag("Dreadnought");
            print("not destrtoying");
            manager.GetPlayer().Ship.ShipModel = selectedShip;
            manager.DontDestroy(selectedShip);
        }

        manager.SetIsland(1);
        manager.SetLevel(1);
        manager.LoadLevel("MapScreen");
            
    }

}
