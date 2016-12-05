using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistressLoad : MonoBehaviour
{
    private static System.Random rnd = new System.Random();

    private GameObject playerShip;
    private PlayerShipObject playerShipObject;
    private GameManagerScript manager;

    private Text distressText;
    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        distressText = GameObject.FindGameObjectWithTag("DistressText").GetComponent<Text>();
        distressText.text = DistressText();

        playerShipObject = manager.GetPlayer().Ship;
        playerShip = playerShipObject.ShipModel;
        SetPlayerTransform();
    }
	
    private void SetPlayerTransform()
    {
        playerShip.transform.position = new Vector3(-7f, 0f, -14f);
        playerShip.transform.Rotate(new Vector3(0f, -90f, 0f));
        playerShip.transform.localScale = new Vector3(2f, 2f, 2.5f);
    }
    private string DistressText()
    {
        switch (rnd.Next(0,4))
        {
            case 0:
                return "Me ship be briken";
            case 1:
                return "Me hull be breach";
            case 2:
                return "Har, me ship be sink";
            case 3:
                return "Th’ ship's goin’ below, a hand";
            default:
                return "";
        }
    }
}
