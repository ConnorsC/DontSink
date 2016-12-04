using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class store_handler_script : MonoBehaviour {

    int itemCount = 0, columnCount = 1;
    List<ItemObject> itemList;


	// Use this for initialization
	void Start () {
        itemList = new List<ItemObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InsertItemPrefab(ItemObject item)
    {
        
        GameObject itemPrefab = (GameObject)Resources.Load("UI_Elements/itemview_panel");
        GameObject itemPanel = GameObject.FindGameObjectWithTag("ItemScrollViewContent");
        RectTransform itemPanelSize = itemPanel.GetComponent<RectTransform>();
        float panelHeight = itemPanelSize.rect.height;
        float panelWidth = itemPanelSize.rect.width;
        
        GameObject newItem = Instantiate(itemPrefab, new Vector3(0,itemCount*-60,0) , Quaternion.identity) as GameObject;
        itemCount++;
        newItem.name = "itemPrefab " + itemCount;
        print("item:" + newItem.name);
        
        newItem.transform.SetParent(itemPanel.transform, false);
        newItem.GetComponent<ItemViewHandler>().SetName(GetItemName(item));
        newItem.GetComponent<ItemViewHandler>().SetCost(GetItemCost(item));
        newItem.GetComponent<ItemViewHandler>().SetDesc(GetItemDesc(item));
        //newItem.GetComponent<ItemViewHandler>().SetImage(GetItemImage(item));

        if (itemCount * 60 > itemPanelSize.rect.height) {
            itemPanelSize.sizeDelta = new Vector2(0, panelHeight+60);
        }

    }

    public void AddItem(ItemObject item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(ItemObject item)
    {
        itemList.Remove(item);
    }

    public void GetItemImage(ItemObject item)
    {
        if(item is RacerObject)
        {


        }
    }

    public string GetItemName(ItemObject item)
    {
        //return item.Name;
        return "";
    }

    public int GetItemCost(ItemObject item)
    {
        //return item.Value;
        return 0; 
        //return "$ " + item.Value;
    }

    public string GetItemDesc(ItemObject item)
    {
        string desc = "";
        if (item is CannoneerObject)
        {
            CannoneerObject temp = item as CannoneerObject;
            desc = "Changes your damage by " + temp.Damage_Buff;
        }
        else if (item is RacerObject)
        {
            RacerObject temp = item as RacerObject;
            desc = "Changes your speed by " + temp.Speed_Buff;
        }
        else if (item is RepairmanObject)
        {
            RepairmanObject temp = item as RepairmanObject;
            desc = "Changes your max repair by " + temp.Max_Repair +
                   "\nChanges your repair rate by " + temp.Repair_Rate;
            
        }
        else if (item is ScoutObject)
        {
            ScoutObject temp = item as ScoutObject;
            desc = "Changes vision by " + temp.Vision_Increase;
        }
        else if (item is CannonObject)
        {
            CannonObject temp = item as CannonObject;
            desc = "Fire rate: " + temp.Fire_Rate + 
                   "\nDamage: " + temp.Damage;
        }
        else if (item is HullObject)
        {
            HullObject temp = item as HullObject;
            desc = "Damage reduction: " + temp.Damage_Reduction +
                   "\nShield health: " + temp.MaxHealth;
        }
        else if (item is MiscObject)
        {
            MiscObject temp = item as MiscObject;
            desc = "Misc Object";
        }
        else if (item is SailObject)
        {
            SailObject temp = item as SailObject;
            desc = "Speed: " + temp.Speed;
        }
        else
        {
            desc = "Unknown Object";
        }
        return desc;
    }


    public void DemoData()
    {
        //demo method to populate list and display items in store
        //InsertItemPrefab();
        CannonObject temp1 = new CannonObject();
        temp1.Damage = 20;
        temp1.Fire_Rate = 10;
        InsertItemPrefab(temp1);

    }
}
