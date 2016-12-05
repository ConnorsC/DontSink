using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCannonUI : MonoBehaviour
{
    public float cooldown = 10;

    private Slider cooldownBar;
    private float cooldownTimer = 0;
    private GameManagerScript manager;
    private EnemyShipObject enemyShip;
    private PlayerShipObject playerShip;

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        enemyShip = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;
        playerShip = manager.GetPlayer().Ship;

        cooldownBar = this.gameObject.GetComponent<Slider>();
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldownTimer;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UiUpdate>().gameOver && !GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UiUpdate>().pause)
        {
            if (cooldownTimer < cooldown)
                cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= cooldown && enemyShip.CurrentHealth > 0)
            {
                cooldownTimer = 0.0f;
                int enemyDamage = 10; //enemyShip.CurrentDamage;
                playerShip.TakeDamage(enemyDamage);
            }

            cooldownBar.value = cooldownTimer;
        }
    }
}
