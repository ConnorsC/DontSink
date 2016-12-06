using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueObject : MonoBehaviour {

    private bool firstLevel = true;



    private enum dType
    {
        Unknown = 0,
        Tavern,
        Market,
        Shipwrite
    };

    private dType type = 0;

    public DialogueObject()
    {

    }

    public DialogueObject(int type)
    {
        this.type = (dType)type;
    }

    public void dialogueSwitch(int item)
    {
        switch (item)
        {
            case 1:
                print("Buy Screen");
                if (firstLevel)
                {
                    print("Type:"+getDTypeString());
                    HandleButton(1, "Menu was opened");
                }
                else
                {
                    print("Not first screen");
                }
                break;

            case 2:

                print("Dialogue option disabled");
                HandleButton(2, "No time for talking.");
                break;

            case 3:
                print("Leave");
                HandleButton(3, "As you were.");
                break;
        }
    }

    public string getDTypeString()
    {
        switch (type)
        {
            case dType.Tavern:
                return "Tavern";
            case dType.Market:
                return "Market";
            case dType.Shipwrite:
                return "Shipwrite";
            default:
                return "Unknown";
        }
    }

    public void CallBuyScreen()
    {
        //open market menu here
        int s = 1;
        s++;//does nothing blah
    }

    public void HandleButton(int btnNumber, string btnText)
    {
        switch (btnNumber)
        {
            case 1:
                GameObject.FindGameObjectWithTag("Btn1").transform.FindChild("Text").GetComponent<Text>().text = btnText;
                break;
            case 2:
                GameObject.FindGameObjectWithTag("Btn2").transform.FindChild("Text").GetComponent<Text>().text = btnText;
                break;
            case 3:
                GameObject.FindGameObjectWithTag("Btn3").transform.FindChild("Text").GetComponent<Text>().text = btnText;
                break;
        }
    }
}
