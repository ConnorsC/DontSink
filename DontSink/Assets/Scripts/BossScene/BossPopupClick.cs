using UnityEngine;
using System.Collections;

public class BossPopupClick : MonoBehaviour
{
    public void Click()
    {
        if (GameObject.FindGameObjectWithTag("UIUpdate") != null)
            GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<BossScreenUpdate>().Pause(false);
        else if (GameObject.FindGameObjectWithTag("PayoutPopup") != null)
            GameObject.FindGameObjectWithTag("PayoutPopup").SetActive(false);
    }
}
