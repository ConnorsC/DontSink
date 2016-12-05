using UnityEngine;
using System.Collections;

public class LeaveClick : MonoBehaviour
{
    public void ReturnToMap()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().LoadLevel("MapScreen");
    }
}
