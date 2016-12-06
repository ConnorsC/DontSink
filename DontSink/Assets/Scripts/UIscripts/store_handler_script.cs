using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class store_handler_script : MonoBehaviour {

    int itemCount = 0;
    List<ItemObject> itemList;
    List<GameObject> itemPrefabList;
    int currentIndex = -1;

    //create vars for shipstats panel
    GameObject shipNamePanel ;
    GameObject shipImagePanel;
    GameObject shipStatsPanel;
    GameObject shipHullHealthPanel ;
    GameObject shipHullResistPanel;
    GameObject shipSailPanel ;
    GameObject shipAttackPanel ;
    GameObject shipFirePanel ;
    GameManagerScript manager;
    GameObject itemListPanel;
    GameObject goldText;

    // Use this for initialization
    void Start () {
        itemList = new List<ItemObject>();
        
        itemPrefabList = new List<GameObject>();
        //set vars for shipstatspanel
        shipNamePanel = GameObject.FindGameObjectWithTag("StoreShipNamePanel");
        shipImagePanel = GameObject.FindGameObjectWithTag("StoreShipImagePanel");
        //shipStatsPanel = GameObject.FindGameObjectWithTag("StoreShipStatsPanel");//not referenced so commented out for now
        shipHullHealthPanel = GameObject.FindGameObjectWithTag("StoreShipHullHealthPanel");
        shipHullResistPanel = GameObject.FindGameObjectWithTag("StoreShipHullResistPanel");
        shipSailPanel = GameObject.FindGameObjectWithTag("StoreShipSailPanel");
        shipAttackPanel = GameObject.FindGameObjectWithTag("StoreShipAttackPanel");
        shipFirePanel = GameObject.FindGameObjectWithTag("StoreShipFirePanel");
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        itemListPanel = GameObject.FindGameObjectWithTag("ItemScrollViewContent");
        goldText = GameObject.FindGameObjectWithTag("PlayerGoldText");
        CallItemList();
        UpdateGoldText();
        //DemoData();//demo data (comment this)
        PopulateList();
        PopulateShipStats();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PopulateList()
    {

        //clear before populating
        ClearScrollView();

        foreach (ItemObject item in itemList)
        {
            InsertItemPrefab(item);
        }
        
    }

    public void ClearScrollView()
    {
        
        int len = itemPrefabList.Count;
        for(int i = 0; i < len; i++)
        {
            GameObject temp = itemPrefabList[0];
            itemPrefabList.RemoveAt(0);
            Destroy(temp);
        }
        RectTransform itemPanelSize = itemListPanel.GetComponent<RectTransform>();
        itemPanelSize.sizeDelta = new Vector2(0, 350);//reset panel size
        itemCount = 0;//reset item count before populating
    }

    public void UpdateGoldText()
    {
        goldText.GetComponent<Text>().text = "$" + manager.GetPlayer().Gold;
    }

    public void InsertItemPrefab(ItemObject item)
    {
        
        GameObject itemPrefab = (GameObject)Resources.Load("UI_Elements/itemview_panel");
        GameObject itemPanel = GameObject.FindGameObjectWithTag("ItemScrollViewContent");
        RectTransform itemPanelSize = itemPanel.GetComponent<RectTransform>();
        float panelHeight = itemPanelSize.rect.height;
        
        GameObject newItem = Instantiate(itemPrefab, new Vector3(0,itemCount*-60,0) , Quaternion.identity) as GameObject;
        itemCount++;
        newItem.name = "itemPrefab " + itemCount;
        //print("item:" + newItem.name);
        newItem.transform.SetParent(itemPanel.transform, false);
        newItem.GetComponent<ItemViewHandler>().SetName(GetItemName(item));
        newItem.GetComponent<ItemViewHandler>().SetCost(GetItemCost(item));
        newItem.GetComponent<ItemViewHandler>().SetDesc(GetItemDesc(item));
        newItem.GetComponent<ItemViewHandler>().SetIndex(itemCount - 1);
        newItem.GetComponent<ItemViewHandler>().SetImage(GetItemImage(item));
        newItem.GetComponent<Button>().onClick.AddListener(() => 
            UpdateShipStats(newItem.GetComponent<ItemViewHandler>().GetIndex()));
        if (itemCount * 60 > itemPanelSize.rect.height) {
            itemPanelSize.sizeDelta = new Vector2(0, panelHeight+60);
        }
        itemPrefabList.Add(newItem);

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
        return item.Icon; 
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
            desc = "Damage reduction: " + temp.Damage_Reduction +
                       "\nShield health: " + temp.MaxHealth;
        }
        else if (item is MiscObject)
        {
            //MiscObject temp = item as MiscObject;
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
            desc = "Reload Buff: " + System.Math.Round(temp.Reload_Buff,2) +
                   "\nSpeed Buff: " + System.Math.Round(temp.Speed_Buff,2) + 
                   "\nRepair Rate: " + temp.Repair_Rate;
        }
        else if(item is CrewObject)
        {
            CrewObject temp = item as CrewObject;
            desc = "Reload Buff: " + System.Math.Round(temp.Reload_Buff, 2) + 
                   "\nSpeed Buff: " + System.Math.Round(temp.Speed_Buff, 2);
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
        //SetPanelStats(shipHullHealthPanel, manager.GetPlayer().Ship.Hull.MaxHealth, manager.GetPlayer().Ship.Hull.MaxHealth);
        //SetPanelStats(shipHullResistPanel, manager.GetPlayer().Ship.Hull.Damage_Reduction, manager.GetPlayer().Ship.Hull.Damage_Reduction);
        HullHandler(0,0);
        SetPanelStats(shipSailPanel, manager.GetPlayer().Ship.CurrentSpeed, manager.GetPlayer().Ship.CurrentSpeed);
        SetPanelStats(shipAttackPanel, manager.GetPlayer().Ship.BaseDamage, manager.GetPlayer().Ship.BaseDamage);
        SetPanelStats(shipFirePanel, (int)(manager.GetPlayer().Ship.ReloadMultiplier), (int)(manager.GetPlayer().Ship.ReloadMultiplier));
    }


    //because hull can be null, added this method to catch error (not optimal, should be handled elsewhere)
    public void HullHandler(int default1, int default2)
    {
        if( manager.GetPlayer().Ship.Hull != null)
        {
            SetPanelStats(shipHullHealthPanel, manager.GetPlayer().Ship.Hull.MaxHealth, manager.GetPlayer().Ship.Hull.MaxHealth);
            SetPanelStats(shipHullResistPanel, manager.GetPlayer().Ship.Hull.Damage_Reduction, manager.GetPlayer().Ship.Hull.Damage_Reduction);
        }
        else
        {
            SetPanelStats(shipHullHealthPanel, default1, default2);
            SetPanelStats(shipHullResistPanel, default1, default2);
        }
    }

    public void UpdateShipStats(int index)
    {
        if(index < 0 || index >= itemCount)
        {
            PopulateShipStats();//insert basic data
            return;//dont run if no item selected
        }
        SetIndex(index);
        ItemObject item = itemList[index];
        
        shipNamePanel.GetComponentInChildren<Text>().text = "Your Ship";
        SetPanelImage(shipImagePanel, GetShipStatusSprite());
        HullHandler(0,0);
        SetPanelStats(shipSailPanel, manager.GetPlayer().Ship.CurrentSpeed, manager.GetPlayer().Ship.CurrentSpeed);
        SetPanelStats(shipAttackPanel, manager.GetPlayer().Ship.BaseDamage, manager.GetPlayer().Ship.BaseDamage);
        SetPanelStats(shipFirePanel, (int)(manager.GetPlayer().Ship.ReloadMultiplier), (int)(manager.GetPlayer().Ship.ReloadMultiplier));


        //update panel based on the type of item selected (not optimal but it works)
        if (item is CannonObject)
        {
            CannonObject temp = item as CannonObject;
            SetPanelStats(shipAttackPanel, manager.GetPlayer().Ship.BaseDamage, temp.Damage);
            SetPanelStats(shipFirePanel, (int)(manager.GetPlayer().Ship.ReloadMultiplier), temp.Fire_Rate);

            //TODO DO THIS =================================================
        }
        else if (item is HullObject)
        {
            HullObject temp = item as HullObject;
            if(manager.GetPlayer().Ship.Hull != null)
            {
                SetPanelStats(shipHullHealthPanel, manager.GetPlayer().Ship.Hull.MaxHealth, temp.MaxHealth);
                SetPanelStats(shipHullResistPanel, manager.GetPlayer().Ship.Hull.Damage_Reduction, temp.Damage_Reduction);
            }
            else
            { 
                SetPanelStats(shipHullHealthPanel, 0, temp.MaxHealth);
                SetPanelStats(shipHullResistPanel, 0, temp.Damage_Reduction);
            }
            
        }
        else if (item is MiscObject)
        {
            return;
            //do nothing
        }
        else if (item is SailObject)
        {
            SailObject temp = item as SailObject;
            SetPanelStats(shipSailPanel, manager.GetPlayer().Ship.CurrentSpeed, temp.Speed);
        }
        else if (item is RepairmanObject)
        {
            RepairmanObject temp = item as RepairmanObject;
            SetPanelStats(shipSailPanel, manager.GetPlayer().Ship.CurrentSpeed, (int)(manager.GetPlayer().Ship.CurrentSpeed * temp.Speed_Buff));
            SetPanelStats(shipFirePanel, (int)(manager.GetPlayer().Ship.ReloadMultiplier), (int)(manager.GetPlayer().Ship.ReloadMultiplier * temp.Reload_Buff));
        }
        else if (item is CrewObject)
        {
            CrewObject temp = item as CrewObject;
            SetPanelStats(shipSailPanel, manager.GetPlayer().Ship.CurrentSpeed, (int)(manager.GetPlayer().Ship.CurrentSpeed * temp.Speed_Buff));
            SetPanelStats(shipFirePanel, (int)(manager.GetPlayer().Ship.ReloadMultiplier), (int)(manager.GetPlayer().Ship.ReloadMultiplier * temp.Reload_Buff));
        }
        else
        {
            //do nothing for now
        }
    }

    public Sprite GetShipStatusSprite()
    {
        Sprite targetSprite;
        double shipHealth = (((float)manager.GetPlayer().Ship.CurrentHealth) / ((float)manager.GetPlayer().Ship.MaxHealth)) * 100;

        
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

    public void ResetIndex()
    {
        currentIndex = -1;
        PopulateShipStats();
    }

    public int GetIndex()
    {
        return currentIndex;
    }

    public void SetIndex(int index)
    {
        currentIndex = index;
    }

    public void PurchaseItem()
    {
        if(currentIndex < 0 || currentIndex >= itemCount)
        {
            print("No Item Selected");
        }
        else
        {
            int itemCost = itemList[currentIndex].Value;
            if (manager.GetPlayer().Gold < itemCost)//check cost
            {
                print("Not enough gold");
                return;
            }
            //ItemObject item = itemList[currentIndex];
            if (itemList[currentIndex] is RepairmanObject)
            {
                //RepairmanObject temp = item as RepairmanObject;
                manager.GetPlayer().Ship.AddCrew(itemList[currentIndex] as RepairmanObject);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else if (itemList[currentIndex] is CrewObject)
            {
                //CrewObject temp = item as CrewObject;
                manager.GetPlayer().Ship.AddCrew(itemList[currentIndex] as CrewObject);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else if (itemList[currentIndex] is SailObject)
            {
                SailObject temp = itemList[currentIndex] as SailObject;
                
                manager.GetPlayer().Ship.AddItem(temp);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else if (itemList[currentIndex] is CannonObject)
            {
                //CannonObject temp = item as CannonObject;

                manager.GetPlayer().Ship.AddItem(itemList[currentIndex]);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else if(itemList[currentIndex] is HullObject)
            {
                manager.GetPlayer().Ship.AddItem(itemList[currentIndex]);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else if (itemList[currentIndex] is ItemObject)
            {
                //print(item.Name);
                manager.GetPlayer().Ship.AddItem(itemList[currentIndex]);
                itemList.Remove(itemList[currentIndex]);
                itemCount--;
                UpdateItemList();
            }
            else
            {
                print("Item could not be added: invalid item");
                return;
            }
            manager.GetPlayer().Gold -= itemCost;//set player gold
            UpdateGoldText();//update UI
            ResetIndex();
            PopulateList();
         
        }
    }

    public void CallItemList()
    {
        itemList = manager.GetItemList();
    }

    public void UpdateItemList()
    {
        manager.SetItemList(itemList);
    }

   

    public void DemoData()
    {
        //demo method to populate list and display items in store
        CannonObject temp1 = new CannonObject();
        temp1.Damage = 20;
        temp1.Fire_Rate = 10;
        temp1.Name = "Basic Cannon";
        temp1.Icon = Resources.Load<Sprite>("Images/cannon");
        temp1.Value = 1;

        CrewObject temp2 = new CrewObject();
        temp2.Reload_Buff = 2;
        temp2.Speed_Buff = 1;
        temp2.Name = "Sailor Joe";
        temp2.Icon = Resources.Load<Sprite>("Images/sailoricon");
        temp2.Value = 1;

        RepairmanObject temp3 = new RepairmanObject();
        temp3.Repair_Rate = 20;
        temp3.Max_Repair = 100;
        temp3.Name = "Repairman Steve";
        temp3.Icon = Resources.Load<Sprite>("Images/sailoricon2");
        temp3.Value = 1;

        HullObject temp4 = new HullObject(2,20);
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        //temp4.Damage_Reduction = 2;
        temp4.Name = "Bigger Boards";
        temp4.Icon = Resources.Load<Sprite>("Images/hullicon");
        temp4.Value = 1;

        CrewObject temp5 = new CrewObject();
        temp5.Reload_Buff = 10;
        temp5.Speed_Buff = 2;
        temp5.Name = "Scouter Scoot Man";
        temp5.Icon = Resources.Load<Sprite>("Images/pirateicon");
        temp5.Value = 1;

        HullObject temp6 = new HullObject(5,20);
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        //temp6.Damage_Reduction = 2;
        temp6.Name = "Biggerer Boards";
        temp6.Icon = Resources.Load<Sprite>("Images/reinforcedhullicon");
        temp6.Value = 1;

        SailObject temp7 = new SailObject(Resources.Load<Sprite>("Images/sailboaticon100"), "Sails", 1, 20);
        /*temp7.Speed = 20;
        temp7.Name = "Sails";
        temp7.Icon = Resources.Load<Sprite>("Images/sailboaticon100");
        temp7.Value = 44;*/

        HullObject temp8 = new HullObject(10,20);
        //temp4.MaxHealth = 20;
        //temp4.CurrentHealth = 20;
        //temp8.Damage_Reduction = 2;
        temp8.Name = "Super Heavy Boards";
        temp8.Icon = Resources.Load<Sprite>("Images/superreinforcedhullicon");
        temp8.Value = 1;



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
