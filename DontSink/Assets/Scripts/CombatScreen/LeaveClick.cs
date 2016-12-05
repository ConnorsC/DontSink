using UnityEngine;
using System.Collections;

public class LeaveClick : MonoBehaviour
{
    private GameManagerScript manager;
    private EnemyIslandObject enemyIsland;

    public void ReturnToMap()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        enemyIsland = manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject;
        enemyIsland.Defeated = true;

        manager.LoadLevel("MapScreen");
    }
}
