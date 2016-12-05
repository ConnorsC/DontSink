using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistressClick : MonoBehaviour
{
    private static System.Random rnd = new System.Random();

    private GameManagerScript manager;
    private GameObject leaveButton;
    private GameObject payoutPopup;
    private DistressIslandObject distressIsland;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        leaveButton = GameObject.FindGameObjectWithTag("LeaveUI");
        leaveButton.SetActive(false);
        payoutPopup = GameObject.FindGameObjectWithTag("PayoutPopup");
        payoutPopup.SetActive(false);
        distressIsland = manager.Islands[manager.GetIsland() - 1] as DistressIslandObject;

        if (distressIsland.Defeated == 1)
            RemoveUI();
        else if (distressIsland.Defeated == 2)
            RemoveDistress();
    }

    public void Help()
    {
        distressIsland.Defeated = 1;

        payoutPopup.SetActive(true);
        payoutPopup.transform.Find("Text").GetComponent<Text>().text = RewardPlayer();

        RemoveUI();
    }

    public void OK()
    {
        payoutPopup.SetActive(false);
    }

    public void LeaveAlone()
    {
        distressIsland.Defeated = 2;
        GameObject distressShip = GameObject.FindGameObjectWithTag("DistressShip1");
        ShipSink sink = distressShip.AddComponent<ShipSink>();
        sink.sinkSpeed = 3;
        RemoveUI();
    }

    public void ReturnToMap()
    {
        manager.LoadLevel("MapScreen");
    }

    private void RemoveDistress()
    {
        GameObject distressShip = GameObject.FindGameObjectWithTag("DistressShip1");
        distressShip.SetActive(false);
        RemoveUI();
    }

    private void RemoveUI()
    {
        GameObject distressUI = GameObject.FindGameObjectWithTag("DistressUI");
        distressUI.SetActive(false);
        CreateLeaveButton();
    }

    private void CreateLeaveButton()
    {
        leaveButton.SetActive(true);
    }

    private string RewardPlayer()
    {
        int reward = rnd.Next(0, 10);

        if (reward >= 9 && manager.GetPlayer().Ship.CurrentHealth > 10)
        {
            manager.GetPlayer().Ship.CurrentHealth -= 10;
            return "Your ship was damaged attempting to aid the distressed ship";
        }
        else
        {
            if (distressIsland.Ship.Boon == null)
            {
                int gold = rnd.Next(3, 5 + 2*manager.GetLevel());
                manager.GetPlayer().Gold += gold;
                return "'Hearty thanks fer ye help. Take 'tis as payment.' \n\nThe captain hands you " + gold + " gold";
            }
            else
            {
                manager.GetPlayer().Ship.AddItem(distressIsland.Ship.Boon);
                return "'I hope this item will help you on your travels.' \n\nThe captain gives you " + distressIsland.Ship.Boon.Name;
            }
        }
    }
}
