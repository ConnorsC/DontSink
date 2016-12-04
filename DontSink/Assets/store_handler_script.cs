using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class store_handler_script : MonoBehaviour {

    int itemCount = 0, columnCount = 1;
    List<ItemObject> itemList;
    int currentIndex = 0;


	// Use this for initialization
	void Start () {
        itemList = new List<ItemObject>();
        DemoData();//demo data (remove this)
        PopulateList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PopulateList()
    {
        foreach (ItemObject item in itemList)
        {
            InsertItemPrefab(item);
        }
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
        newItem.GetComponent<ItemViewHandler>().SetIndex(itemCount - 1);
        //newItem.GetComponent<ItemViewHandler>().SetImage(GetItemImage(item));
        newItem.GetComponent<Button>().onClick.AddListener(() => 
            UpdateShipStats(newItem.GetComponent<ItemViewHandler>().GetIndex()));
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
        return item.Name;
        //return "";
    }

    public int GetItemCost(ItemObject item)
    {
        return item.Value;
        //return 0; 
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

    public void PopulateShipStats()
    {

    }

    public void UpdateShipStats(int index)
    {
        ItemObject item = itemList[index];
        print(item.Name);
        
    }

    public void DemoData()
    {
        //demo method to populate list and display items in store
        CannonObject temp1 = new CannonObject();
        temp1.Damage = 20;
        temp1.Fire_Rate = 10;
        temp1.Name = "BIG BOI POW GUN";
        temp1.Value = 900;

        RacerObject temp2 = new RacerObject();
        temp2.Speed_Buff = 10;
        temp2.Name = "Racer Dan";
        temp2.Value = 22;

        RepairmanObject temp3 = new RepairmanObject();
        temp3.Repair_Rate = 20;
        temp3.Max_Repair = 100;
        temp3.Name = "Repairman Steve";
        temp3.Value = 84;

        /*HullObject temp4 = new HullObject();
        temp4.MaxHealth = 20;
        temp4.CurrentHealth = 20;
        temp4.Damage_Reduction = 2;
        temp4.Name = "Bigger Boards";
        temp4.Value = 9999;*/

        ScoutObject temp5 = new ScoutObject();
        temp5.Vision_Increase = 50;
        temp5.Name = "Scouter Scoot Man";
        temp5.Value = 1;

        CannoneerObject temp6 = new CannoneerObject();
        temp6.Damage_Buff = 3;
        temp6.Name = "Shooter McGee";
        temp6.Value = 44;

        SailObject temp7 = new SailObject();
        temp7.Speed = 20;
        temp7.Name = "Sailor Regi";
        temp7.Value = 44;

        AddItem(temp1);
        AddItem(temp2);
        AddItem(temp3);
        //AddItem(temp4);
        AddItem(temp5);
        AddItem(temp6);
        AddItem(temp7);




    }
}
