﻿using UnityEngine;

public class ShipSelect : MonoBehaviour{
    private GameObject playerShip;
    private GameManagerScript manager;
    private GameObject selectedShip;
    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack1;
    private GUIStyle guiStyleBack2;
    private GameObject brig;
    private GameObject corvette;
    private GameObject dreadnought;
    public Texture2D imageTexture = null;

    public void Start()
    {

        //imageTexture.wrapMode = TextureWrapMode.Clamp;
        //guiStyleBack.normal.background = imageTexture;

        guiStyleFore = new GUIStyle();
        SetupStyle(guiStyleFore);
        guiStyleFore.normal.textColor = Color.white;

        guiStyleBack1 = new GUIStyle();
        SetupStyle(guiStyleBack1);

        guiStyleBack2 = new GUIStyle();
        SetupStyle(guiStyleBack2);

        brig = GameObject.FindGameObjectWithTag("Brig");
        corvette = GameObject.FindGameObjectWithTag("Corvette");
        dreadnought = GameObject.FindGameObjectWithTag("Dreadnought");
    }

    public void SetupStyle(GUIStyle currStyle) {

        currStyle.fontSize = 24;
        currStyle.alignment = TextAnchor.UpperCenter;
        currStyle.wordWrap = true;
        currStyle.border = new RectOffset();


    }

    public void OnMouseDown()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        if (gameObject.tag == "Brig")
        {
            manager.GetPlayer().Ship = (new BrigObject());
            manager.GetPlayer().Ship.ShipModel = brig;
            manager.GetPlayer().PlayerShipTag = "Brig";
            manager.DontDestroy(brig);
            Destroy(this);
        }
        else if (gameObject.tag == "Corvette")
        {
            manager.GetPlayer().Ship = (new CorvetteObject());
            manager.GetPlayer().Ship.ShipModel = corvette;
            manager.GetPlayer().PlayerShipTag = "Corvette";
            manager.DontDestroy(corvette);
            Destroy(this);
        }
        else if (gameObject.tag == "Dreadnought")
        {
            manager.GetPlayer().Ship = (new DreadnoughtObject());
            manager.GetPlayer().Ship.ShipModel = dreadnought;
            manager.GetPlayer().PlayerShipTag = "Dreadnought";
            manager.DontDestroy(dreadnought);
            Destroy(this);
        }
        manager.SetIsland(1);
        manager.SetLevel(2);
        manager.LoadLevel("MapScreen");
    }

    private void OnMouseEnter()
    {

        if (gameObject.tag == "Brig")
        {
            currentToolTipText = "\nBrig\nA Great starting ship with balanced stats \n \n Health: "+ 10 + "\n Speed: "+10 +"\nDamage: " +10 +"\nInventory Space: "+100;
        }
        else if (gameObject.tag == "Corvette")
        {
            currentToolTipText = "\nCorvette\nA Fast Ship \n \n Health: " + 8 + "\n Speed: " + 14 + "\nDamage: " + 8 + "\nInventory Space: " + 80;
        }
        else if (gameObject.tag == "Dreadnought")
        {
            currentToolTipText = "\nDreadnought\nA Strong ship but slow ship\n \n Health: " + 12 + "\n Speed: " + 6 + "\nDamage: " + 12 + "\nInventory Space: " + 120;
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
            imageTexture.wrapMode = TextureWrapMode.Repeat;

            //guiStyleBack.normal.background = imageTexture;
            guiStyleBack1.normal.background = imageTexture;
            //where to place the label


            var x = Screen.width/2 -400;

            var y = Screen.height/2 -200;

            GUI.Label(new Rect(x, y + 2, 300, 400), currentToolTipText, guiStyleBack1);
            GUI.Label(new Rect(x, y - 2, 300, 400), currentToolTipText, guiStyleBack2);
            GUI.Label(new Rect(x + 2, y, 300, 400), currentToolTipText, guiStyleBack2);
            GUI.Label(new Rect(x - 2, y, 300, 400), currentToolTipText, guiStyleBack2);
            GUI.Label(new Rect(x, y, 300, 400), currentToolTipText, guiStyleFore);
            
            
        }
    }
}
