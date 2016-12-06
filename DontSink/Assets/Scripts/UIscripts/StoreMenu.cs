using UnityEngine;
using System.Collections;

public class StoreMenu : MonoBehaviour {
    private bool showMenu;
    private int menuType;
    private GameObject storeMenu;
    // Use this for initialization
    void Start () {
        storeMenu = GameObject.FindGameObjectWithTag("BuyMenu");
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
        storeMenu.SetActive(isVisible);
        //GameObject.FindGameObjectWithTag("DialogueBackground").SetActive(!showMenu);
        //GameObject.FindGameObjectWithTag("BuyMenu").SetActive(showMenu);
    }
}
