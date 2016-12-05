using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class store_handler_script : MonoBehaviour {

    int itemCount = 0, columnCount = 1;
    List<ItemObject> itemList;
    int currentIndex = 0;

    //create vars for shipstats panel
    GameObject shipNamePanel ;
    GameObject shipImagePanel;
    GameObject shipStatsPanel;
    GameObject shipHullPanel ;
    GameObject shipSailPanel ;
    GameObject shipAttackPanel ;
    GameObject shipFirePanel ;
    GameManagerScript manager;

    // Use this for initialization
    void Start () {
        itemList = new List<ItemObject>();

        //set vars for shipstatspanel
        shipNamePanel = GameObject.FindGameObjectWithTag("StoreShipNamePanel");
        shipImagePanel = GameObject.FindGameObjectWithTag("StoreShipImagePanel");
        shipStatsPanel = GameObject.FindGameObjectWithTag("StoreShipStatsPanel");
        shipHullPanel = GameObject.FindGameObjectWithTag("StoreShipHullPanel");
        shipSailPanel = GameObject.FindGameObjectWithTag("StoreShipSailPanel");
        shipAttackPanel = GameObject.FindGameObjectWithTag("StoreShipAttackPanel");
        shipFirePanel = GameObject.FindGameObjectWithTag("StoreShipFirePanel");
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        DemoData();//demo data (remove this)
        PopulateList();
        PopulateShipStats();
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
        //print("item:" + newItem.name);
        newItem.transform.SetParent(itemPanel.transform, false);
        newItem.GetComponent<ItemViewHandler>().SetName(GetItemName(item));
        newItem.GetComponent<ItemViewHandler>().SetCost(GetItemCost(item));
        newItem.GetComponent<ItemViewHandler>().SetDesc(GetItemDesc(item));
        newItem.GetComponent<ItemViewHandler>().SetIndex(itemCount - 1);
        newItem.GetComponent<ItemViewHandler>().SetImage(GetItemImage(item));//STATIC VALUES UNTIL ITEMS ARE IMPORTED
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

    public Sprite GetItemImage(ItemObject item)
    {
        return item.Icon; //"Images/cannon";//NOT FINAL==================
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
        if (item is CannonObject)
        {
            CannonObject temp = item as CannonObject;
            desc = "Fire rate: " + temp.Fire_Rate + 
                   "\nDamage: " + temp.Damage;
        }
        else if (item is HullObject)
        {
            HullObject temp = item as HullObject;
            try
            {
                desc = "Damage reduction: " + temp.Damage_Reduction +
                       "\nShield health: " + temp.MaxHealth;
            }
            catch //TEMPORARY UNTIL FIXED
            {
                desc = "Damage reduction: 0" + 
                       "\nShield health: 0 " ;
            }
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
        else if (item is RepairmanObject)
        {
            RepairmanObject temp = item as RepairmanObject;
            desc = "Reload Buff: " + temp.Reload_Buff +
                   "\nSpeed Buff: " + temp.Speed_Buff + 
                   "\nRepair Rate: " + temp.Repair_Rate;
        }
        else if(item is CrewObject)
        {
            CrewObject temp = item as CrewObject;
            desc = "Reload Buff: " + temp.Reload_Buff + 
                   "\nSpeed Buff: " + temp.Speed_Buff;
        }
        else
        {
            desc = "Unknown Object";
        }
        return desc;
    }

    public void PopulateShipStats()
    {
        shipNamePanel.GetComponentInChildren<Text>().text = "Your Ship";
        SetPanelImage(shipImagePanel, GetShipStatusSprite());
        SetPanelStats(shipHullPanel, 100, 100);
        SetPanelStats(shipSailPanel, 100, 100);
        SetPanelStats(shipAttackPanel, 100, 100);
        SetPanelStats(shipFirePanel, 100, 100);
    }

    public void UpdateShipStats(int index)
    {
        ItemObject item = itemList[index];
        //GameObject shipPanel = GameObject.FindGameObjectWithTag("ItemScrollViewContent");
        //print(item.Name);
        shipNamePanel.GetComponentInChildren<Text>().text = "Your Ship";
        SetPanelImage(shipImagePanel, GetShipStatusSprite());
        SetPanelStats(shipHullPanel, 100, 105 );
        SetPanelStats(shipSailPanel, 100, 110);
        SetPanelStats(shipAttackPanel, 100, 100);
        SetPanelStats(shipFirePanel, 100, 90);


    }

    public Sprite GetShipStatusSprite()
    {
        Sprite targetSprite;
        double shipHealth = (((float)manager.GetPlayer().Ship.CurrentHealth) / ((float)manager.GetPlayer().Ship.MaxHealth)) * 100;
        print("Ship Health: " + manager.GetPlayer().Ship.CurrentHealth);
        print("Ship Health: " + manager.GetPlayer().Ship.MaxHealth);
        print("Ship Health: " + shipHealth);
        //double shipHealth = 13;
        if(shipHealth > 75)
        {
            targetSprite = Resources.Load<Sprite>("Images/sailboaticon100");
        }
        else if(shipHealth > 50)
        {
            targetSprite = Resources.Load<Sprite>("Images/sailboaticon75");
        }
        else if (shipHealth > 25)
        {
            targetSprite = Resources.Load<Sprite>("Images/sailboaticon50");
        }
        else
        {
            targetSprite = Resources.Load<Sprite>("Images/sailboaticon25");
        }

        return targetSprite;
    }

    public void SetPanelImage(GameObject target, Sprite image)
    {
        foreach (Transform child in target.transform)
        {
            if (child.IsChildOf(target.transform))
            {
                child.GetComponentInChildren<Image>().sprite = image;
            }  
        }
    }

    public void SetPanelStats(GameObject target, int current, int withItem)
    {
        int valueChange = withItem - current;
       
        foreach (Transform child in target.transform)
        {
            if (child.CompareTag("StoreShipValueCurrent"))
            {
                child.GetComponent<Text>().text = ""+ withItem;
            }
            else if (child.CompareTag("StoreShipValueWithItem"))
            {
                string sign = "";
                Color32 clr;
                if (valueChange < 0)
                {
                    clr = new Color32(210,51,5,255);//red
                }
                else if (valueChange > 0)
                {
                    clr = new Color32(0, 255, 55,255); //green
                    sign = "+";
                }
                else
                {
                    clr = new Color32(208, 202, 0,255);//yellowish
                }
                child.GetComponent<Text>().color = clr;
                child.GetComponent<Text>().text = "( "+ sign + valueChange +" )";
            }
        }
    }


    public void DemoData()
    {
        //demo method to populate list and display items in store
        CannonObject temp1 = new CannonObject();
        temp1.Damage = 20;
        temp1.Fire_Rate = 10;
        temp1.Name = "Basic Cannon";
        temp1.Icon = Resources.Load<Sprite>("Images/cannon");
        temp1.Value = 50;

        CrewObject temp2 = new CrewObject();
        temp2.Reload_Buff = 2;
        temp2.Speed_Buff = 1;
        temp2.Name = "Sailor Joe";
        temp2.Icon = Resources.Load<Sprite>("Images/sailoricon");
        temp2.Value = 50;

        RepairmanObject temp3 = new RepairmanObject();
        temp3.Repair_Rate = 20;
        temp3.Max_Repair = 100;
        temp3.Name = "Repairman Steve";
        temp3.Icon = Resources.Load<Sprite>("Images/sailoricon2");
        temp3.Value = 84;

        HullObject temp4 = new HullObject();
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        temp4.Damage_Reduction = 2;
        temp4.Name = "Bigger Boards";
        temp4.Icon = Resources.Load<Sprite>("Images/hullicon");
        temp4.Value = 10;

        CrewObject temp5 = new CrewObject();
        temp5.Reload_Buff = 10;
        temp5.Speed_Buff = 2;
        temp5.Name = "Scouter Scoot Man";
        temp5.Icon = Resources.Load<Sprite>("Images/pirateicon");
        temp5.Value = 1;

        HullObject temp6 = new HullObject();
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        temp6.Damage_Reduction = 2;
        temp6.Name = "Biggerer Boards";
        temp6.Icon = Resources.Load<Sprite>("Images/reinforcedhullicon");
        temp6.Value = 30;

        SailObject temp7 = new SailObject();
        temp7.Speed = 20;
        temp7.Name = "Sailor Regi";
        temp7.Icon = Resources.Load<Sprite>("Images/pirateicon2");
        temp7.Value = 44;

        HullObject temp8 = new HullObject();
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        temp8.Damage_Reduction = 2;
        temp8.Name = "Super Heavy Boards";
        temp8.Icon = Resources.Load<Sprite>("Images/superreinforcedhullicon");
        temp8.Value = 100;



        AddItem(temp1);
        AddItem(temp2);
        AddItem(temp3);
        AddItem(temp4);
        AddItem(temp5);
        AddItem(temp6);
        AddItem(temp7);
        AddItem(temp8);




    }
}
