using UnityEngine;
using System.Collections;

public class DistressClick : MonoBehaviour
{
    private GameManagerScript manager;
    private GameObject leaveButton;
    private DistressIslandObject distressIsland;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        leaveButton = GameObject.FindGameObjectWithTag("LeaveUI");
        leaveButton.SetActive(false);
        distressIsland = manager.Islands[manager.GetIsland() - 1] as DistressIslandObject;

        if (distressIsland.Defeated == 1)
            RemoveUI();
        else if (distressIsland.Defeated == 2)
            RemoveDistress();
    }

    public void Help()
    {
        distressIsland.Defeated = 1;

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
}
