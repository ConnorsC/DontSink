using UnityEngine;
using System.Collections;

public class PayoutClick : MonoBehaviour
{
    public void Click()
    {
        if (GameObject.FindGameObjectWithTag("UIUpdate") != null)
            GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UiUpdate>().Pause(false);
        else if(GameObject.FindGameObjectWithTag("PayoutPopup") != null)
            GameObject.FindGameObjectWithTag("PayoutPopup").SetActive(false);
    }
}
