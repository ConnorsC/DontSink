using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipRepairScript : MonoBehaviour {

    GameObject shipRepairButton;
    int cost;
    GameManagerScript manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        //cost = manager.GetPlayer().Ship.
        shipRepairButton = GameObject.FindGameObjectWithTag("ShipRepairButton");
        cost = calculateCost();
        CheckForRepair();
        print("Script started");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getMissingHealth()
    {
        return manager.GetPlayer().Ship.MaxHealth - manager.GetPlayer().Ship.CurrentHealth;
    }

    public int calculateCost()
    {
        int tempCost = getMissingHealth() / 10;
        //int maxRepairVal = manager.GetPlayer().Gold * 10;

        if (tempCost > manager.GetPlayer().Gold)
        {
            tempCost = manager.GetPlayer().Gold;
        }

        //making sure nothing costs zero gold
        if(getMissingHealth() > 0 && manager.GetPlayer().Gold > 0 && tempCost == 0)
        {
            tempCost = 1;
        }

        return tempCost;
    }

    public void RepairShipMax()
    {
        if(cost == 0)
        {
            SetBtnText("No Repair Possible");
            return;//no repairs possible
        }
        int maxRepairVal = manager.GetPlayer().Gold * 10;
        int missingHealth = getMissingHealth();
        if(maxRepairVal < missingHealth)
        {
            manager.GetPlayer().Ship.CurrentHealth += maxRepairVal;
            manager.GetPlayer().Gold -= cost;
            print("ship repaired:");
        }
        else
        {
            manager.GetPlayer().Ship.CurrentHealth += missingHealth;
            manager.GetPlayer().Gold -= cost;
            print("ship repaired full:");
        }
        cost = 0;
        SetBtnText("Ship Repaired");
    }

    public void CheckForRepair()
    {
        if(getMissingHealth() > 0)
        {
            SetBtnText("Repair Ship(" + cost + "g)");
        }
        else
        {
            SetBtnText("Ship is Fully Repaired");
        }
    }

    public void SetBtnText(string text)
    {
        shipRepairButton.transform.FindChild("Text").GetComponent<Text>().text = text;
    }


}
