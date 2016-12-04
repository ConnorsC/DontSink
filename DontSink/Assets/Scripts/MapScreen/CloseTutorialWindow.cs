using UnityEngine;
using System.Collections;

public class CloseTutorialWindow : MonoBehaviour {


    public void OnMouseDown()
    {

        GameObject tutUi = GameObject.FindGameObjectWithTag("TutorialUI");
        tutUi.SetActive(false);

    }
    }
