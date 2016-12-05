using UnityEngine;
using System.Collections;

public class DistressClick : MonoBehaviour
{
    private GameManagerScript manager;
    private GameObject leaveButton; 

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        leaveButton = GameObject.FindGameObjectWithTag("LeaveUI");
        leaveButton.SetActive(false);
    }

    public void Help()
    {

    }

    public void LeaveAlone()
    {
        GameObject distressShip = GameObject.FindGameObjectWithTag("DistressShip1");
        ShipSink sink = distressShip.AddComponent<ShipSink>();
        sink.sinkSpeed = 3;
        RemoveUI();
        CreateLeaveButton();
    }
    public void ReturnToMap()
    {
        manager.LoadLevel("MapScreen");
    }
    private void RemoveUI()
    {
        GameObject distressUI = GameObject.FindGameObjectWithTag("DistressUI");
        distressUI.SetActive(false);
    }
    private void CreateLeaveButton()
    {
        leaveButton.SetActive(true);
    }
}
