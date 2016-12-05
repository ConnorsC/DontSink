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
    private Text clarificationText;
    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        GameObject tmp = GameObject.FindGameObjectWithTag("DistressText");
        GameObject txt = GameObject.FindGameObjectWithTag("ClarificationText");
        if (tmp != null)
        {
            distressText = tmp.GetComponent<Text>();
            distressText.text = DistressText();
            clarificationText = txt.GetComponent<Text>();
            clarificationText.text = ClarificationText();
        }

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
        string ret;
        switch (rnd.Next(0,4))
        {
            case 0:
                ret = "'Me ship be briken!'";
                break;
            case 1:
                ret = "'Me hull be breach!'";
                break;
            case 2:
                ret = "'Har, me ship be sink!'";
                break;
            case 3:
                ret = "'Th’ ship's goin’ below, a hand!'";
                break;
            default:
                ret = "";
                break;
        }
        return ret;
    }
    private string ClarificationText()
    {
        return "They're sinking, what do you do?";
    }

}
