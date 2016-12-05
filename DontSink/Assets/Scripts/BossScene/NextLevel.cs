using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
    GameManagerScript manager;

	public void ClickNextLevel()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        manager.SetLevel(manager.GetLevel()+1);
        manager.SetIsland(1);
        manager.LoadLevel("MapScreen");
    }
}
