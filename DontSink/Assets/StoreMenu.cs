﻿using UnityEngine;
using System.Collections;

public class StoreMenu : MonoBehaviour {
    private bool showMenu;
    private int menuType = 0;
    
    // Use this for initialization
    void Start () {
        showMenu = false;
        setMenuVisible(showMenu);
    }

    /*void Update()
    {
        


    }*/

    public void enableMenu()
    {
        setMenuVisible(true);
    }

    public void disableMenu()
    {
        setMenuVisible(false);
    }

    void setMenuVisible(bool isVisible)
    {
        showMenu = isVisible;
        //GameObject.FindGameObjectWithTag("DialogueBackground").SetActive(!showMenu);
        GameObject.FindGameObjectWithTag("BuyMenu").SetActive(showMenu);
    }
}
