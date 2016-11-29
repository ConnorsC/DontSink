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
        if (manager.CanSelectShip)
        {
            if (gameObject.tag == "Brig")
            {
                manager.GetPlayer().Ship = (new BrigObject());
                manager.GetPlayer().Ship.ShipModel = brig;
                manager.DontDestroy(brig);
                Destroy(this);
            }
            else if (gameObject.tag == "Corvette")
            {
                manager.GetPlayer().Ship = (new CorvetteObject());
                manager.GetPlayer().Ship.ShipModel = corvette;
                manager.DontDestroy(corvette);
                Destroy(this);
            }
            else if (gameObject.tag == "Dreadnought")
            {
                manager.GetPlayer().Ship = (new DreadnoughtObject());
                manager.GetPlayer().Ship.ShipModel = dreadnought;
                manager.DontDestroy(dreadnought);
                Destroy(this);
            }

            manager.SetIsland(1);
            manager.SetLevel(1);
            manager.CanSelectShip = false;
        }
        manager.LoadLevel("MapScreen");
            
    }

    private void OnMouseEnter()
    {
        print("mouse enter");

        if (gameObject.tag == "Brig")
        {
            currentToolTipText = "Brig\nA Great starting ship with balanced stats \n \n Health: "+ 10 + "\n Speed: "+10 +"\nDamage: " +10 +"\nInventory Space: "+100;
        }
        else if (gameObject.tag == "Corvette")
        {
            currentToolTipText = "Corvette\nA Fast Ship \n \n Health: " + 8 + "\n Speed: " + 14 + "\nDamage: " + 8 + "\nInventory Space: " + 80;
        }
        else if (gameObject.tag == "Dreadnought")
        {
            currentToolTipText = "Dreadnought\nA Strong ship but slow ship\n \n Health: " + 12 + "\n Speed: " + 6 + "\nDamage: " + 12 + "\nInventory Space: " + 120;
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
            //where to place the label
            var x = 0;
            var y = 50;
            GUI.Label(new Rect(x, y, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x, y, 300, 60), currentToolTipText, guiStyleFore);
            
        }
    }
}
