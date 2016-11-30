using UnityEngine;
using System.Collections;

public class ScreenLoad : MonoBehaviour {

    private GameObject playerShip;
    private GameManagerScript manager;
    private EnemyIslandObject enemyIsland;
    private GameObject enemyShip;

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        enemyIsland = manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject;
        enemyShip = Instantiate(Resources.Load(enemyIsland.Ship.ShipModel, typeof(GameObject))) as GameObject;
        
        playerShip = manager.GetPlayer().Ship.ShipModel;
        playerShip.transform.position = new Vector3(-7f,0f,-16f);
        playerShip.transform.Rotate(new Vector3(0f,-90f,0f));
        playerShip.transform.localScale = new Vector3(2f, 2.5f, 2.5f);

        enemyShip.transform.position = new Vector3(12f, 0f, -16f);
        enemyShip.transform.Rotate(new Vector3(0f, -90f, 0f));
        enemyShip.transform.localScale = new Vector3(2f, 2.5f, 2.5f);
    }
}
