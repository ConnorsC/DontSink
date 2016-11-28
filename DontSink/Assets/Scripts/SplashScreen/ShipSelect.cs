using UnityEngine;

public class ShipSelect : MonoBehaviour{
    private GameObject playerShip;
    private GameManagerScript manager;
    private GameObject selectedShip;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void OnMouseDown()
    {
        if (manager.CanSelectShip)
        { 

            if (gameObject.tag== "Brig")
            {
                manager.GetPlayer().Ship=(new BrigObject());
                selectedShip = GameObject.FindGameObjectWithTag("Brig");
                manager.GetPlayer().Ship.ShipModel = selectedShip;
                manager.DontDestroy(selectedShip);
            }
            else if (gameObject.tag == "Corvette")
            {
                manager.GetPlayer().Ship = (new CorvetteObject());
                selectedShip = GameObject.FindGameObjectWithTag("Corvette");
                manager.GetPlayer().Ship.ShipModel = selectedShip;
                manager.DontDestroy(selectedShip);
            }
            else if (gameObject.tag == "Dreadnought")
            {
                manager.GetPlayer().Ship = (new DreadnoughtObject());
                selectedShip = GameObject.FindGameObjectWithTag("Dreadnought");
                print("not destroying");
                manager.GetPlayer().Ship.ShipModel = selectedShip;
                manager.DontDestroy(selectedShip);
            }
            manager.SetIsland(1);
            manager.SetLevel(1);
            manager.CanSelectShip = false;
        }
        
        manager.LoadLevel("MapScreen");
            
    }

}
