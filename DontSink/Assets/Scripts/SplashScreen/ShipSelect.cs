using UnityEngine;

public class ShipSelect : MonoBehaviour{
    private GameObject playerShip;
    private GameManagerScript manager;
    private GameObject selectedShip;
    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private GameObject brig;
    private GameObject corvette;
    private GameObject dreadnought;


    public void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
        guiStyleBack.border = new RectOffset();
        brig = GameObject.FindGameObjectWithTag("Brig");
        corvette = GameObject.FindGameObjectWithTag("Corvette");
        dreadnought = GameObject.FindGameObjectWithTag("Dreadnought");
        print("starting up");
    }

    public void Awake()
    {
        print("waking up");
    }

    public void OnMouseDown()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        if (gameObject.tag== "Brig")
        {
            manager.GetPlayer().Ship=(new BrigObject());
            manager.GetPlayer().Ship.ShipModel = brig;
            manager.DontDestroy(brig);
        }
        else if (gameObject.tag == "Corvette")
        {
            manager.GetPlayer().Ship = (new CorvetteObject());
            manager.GetPlayer().Ship.ShipModel = corvette;
            manager.DontDestroy(corvette);
        }
        else if (gameObject.tag == "Dreadnought")
        {
            manager.GetPlayer().Ship = (new DreadnoughtObject());
            manager.GetPlayer().Ship.ShipModel = dreadnought;
            manager.DontDestroy(dreadnought);
        }

        manager.SetIsland(1);
        manager.SetLevel(1);
        manager.LoadLevel("MapScreen");
            
    }

    private void OnMouseEnter()
    {
        print("mouse enter");

        if (gameObject.tag == "Brig")
        {
            currentToolTipText = "A Great starting ship with balanced stats \n \n Health: "+ health + "\n Hull: "+hull +"\nDamage" +damage +"/nInventory Space: "+inventory;
        }
        else if (gameObject.tag == "Corvette")
        {
            currentToolTipText = "This is a boat";
        }
        else if (gameObject.tag == "Dreadnought")
        {
            currentToolTipText = "This is a boat";
        }


    }


    private void OnMouseExit()
    {
        currentToolTipText = "";
    }


    private void OnGUI()
    {
        if (currentToolTipText != "")
        {
            var x = 0;// Event.current.mousePosition.x;
            var y = 0;//Event.current.mousePosition.y;
            GUI.Label(new Rect(x, y, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x, y, 300, 60), currentToolTipText, guiStyleFore);
            
        }
    }
}
