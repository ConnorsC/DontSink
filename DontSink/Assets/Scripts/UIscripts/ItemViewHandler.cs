using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemViewHandler : MonoBehaviour {
    // Use this for initialization
    private int index;

    void Start () {
	
	}
	
    public int GetIndex()
    {
        return index;
    }

    public void PushIndex()
    {

    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void SetImage(Sprite imageSprite)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("ItemImage"))
            {
                //Sprite newImage = Resources.Load("Images/cannon") as Sprite;
                //child.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/cannon") as Sprite;
                child.GetComponent<Image>().sprite = imageSprite;
            }
        }
    }

    public void SetName(string name)
    {
        
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("ItemName"))
            {
                child.GetComponent<Text>().text = name;
                
            }
            
        }
        //gameObject.transform.FindChild("item_info_panel/item_name").GetComponent<Text>().text = name;
        
    }

    public void SetDesc(string desc)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("ItemDesc"))
            {
                child.GetComponent<Text>().text = desc;

            }
        }
    }

    public void SetCost(int cost)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("ItemCost"))
            {
                child.GetComponent<Text>().text = "$ " + cost.ToString();

            }
        }
    }

    public void DeleteObject()
    {
        Destroy(this.gameObject);
    }


}
