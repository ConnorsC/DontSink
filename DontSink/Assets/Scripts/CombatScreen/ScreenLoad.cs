using UnityEngine;
using System.Collections;

public class ScreenLoad : MonoBehaviour {

    private GameObject playerShip;
    private PlayerShipObject playerShipObject;
    private GameManagerScript manager;
    private EnemyIslandObject enemyIsland;
    private GameObject enemyShip;
    private EnemyShipObject enemyShipObject;

    static string cannonUIPath = "Objects/UI/CannonUI";
    static string enemyCannonUIPath = "Objects/UI/EnemyCannon";
    static string enemyCannonTag = "EnemyCannonUI";

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        

        enemyIsland = manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject;
        enemyShipObject = enemyIsland.Ship;
        enemyShip = Instantiate(Resources.Load(enemyShipObject.ShipModel, typeof(GameObject))) as GameObject;
        string enemyShipTag = enemyIsland.Ship.ShipModel.Substring(14, enemyIsland.Ship.ShipModel.Length - 14);
        enemyShip.tag = enemyShipTag;
        SetEnemyTransform();

        playerShipObject = manager.GetPlayer().Ship;
        playerShip = playerShipObject.ShipModel;
        SetPlayerTransform();

        SetPlayerCannons();
        SetEnemyCannons(); 
    }
    private void SetPlayerTransform()
    {
        playerShip.transform.position = new Vector3(-7f, 0f, -14f);
        playerShip.transform.Rotate(new Vector3(0f, -90f, 0f));
        playerShip.transform.localScale = new Vector3(2f, 2f, 2.5f);
    }
    private void SetEnemyTransform()
    {
        enemyShip.transform.position = new Vector3(12f, 0f, -14f);
        enemyShip.transform.Rotate(new Vector3(0f, -90f, 0f));
        enemyShip.transform.localScale = new Vector3(2f, 2f, 2.5f);
    }
    private void SetPlayerCannons()
    {
        int cannonNumber = 1;
        GameObject canvas = GameObject.FindGameObjectWithTag("CombatUI");
        //foreach (CannonObject cannon in playerShipObject.GetCannons())
        //{
        for (int j = 0; j < 8; j++)
        {
            GameObject cannonUI = Instantiate(Resources.Load(cannonUIPath, typeof(GameObject))) as GameObject;
            CannonUIController cannonController = cannonUI.transform.Find("Click").GetComponent<CannonUIController>();
            cannonController.cannonName = "Cannon " + cannonNumber;
            cannonController.cooldown = 3;// cannon.Fire_Rate;
            cannonUI.transform.SetParent(canvas.transform);
            if (cannonNumber <= 4)
                cannonUI.transform.localPosition = new Vector3(0f, -((cannonNumber - 1) * 20), 0f);
            else if (4 < cannonNumber && cannonNumber <= 8)
                cannonUI.transform.localPosition = new Vector3(100f, -((cannonNumber - 5) * 20), 0f);
            cannonUI.transform.localScale = new Vector3(1f, 1f, 1f);
            cannonNumber++;
        }
    }
    private void SetEnemyCannons()
    {
        int cannonNumber = 1;
        GameObject canvas = GameObject.FindGameObjectWithTag("CombatUI");
        //foreach (CannonObject cannon in enemyShipObject.GetCannons())
        //{
        for (int j = 0; j < 2; j++)
        {
            GameObject enemyCannonUI = Instantiate(Resources.Load(enemyCannonUIPath, typeof(GameObject))) as GameObject;
            EnemyCannonUI enemyCannonControllerUI = enemyCannonUI.transform.Find("CannonCooldown").GetComponent<EnemyCannonUI>();
            enemyCannonControllerUI.cooldown = 2+cannonNumber;// cannon.Fire_Rate;
            enemyCannonUI.transform.SetParent(canvas.transform);
            if (cannonNumber <= 4)
                enemyCannonUI.transform.localPosition = new Vector3(0f, -((cannonNumber - 1) * 15), 0f);
            enemyCannonUI.transform.localScale = new Vector3(1f, 1f, 1f);
            enemyCannonUI.tag = enemyCannonTag;
            cannonNumber++;
        }
    }
}
