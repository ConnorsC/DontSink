using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CannonUIController : MonoBehaviour
{
    private GameObject button;
    private Slider cooldownBar;
    private Text text;

    public float cooldown = 10;
    public string cannonName = "Cannon";
    private float cooldownTimer;

    private EnemyShipObject enemyShip;
    private PlayerShipObject playerShip;

    // Use this for initialization
    void Start()
    {
        GameManagerScript manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>(); 
        enemyShip = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;
        playerShip = manager.GetPlayer().Ship;
        button = this.gameObject.transform.parent.Find("CannonSelect").gameObject;
        cooldownBar = this.gameObject.transform.parent.Find("CannonCooldown").GetComponent<Slider>();
        text = button.transform.Find("CannonName").GetComponent<Text>();

        text.text = cannonName;
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldown;
        cooldownTimer = 0.0f;
    }
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UiUpdate>().gameOver && !GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UiUpdate>().pause)
        {
            if (cooldownTimer < cooldown)
                cooldownTimer += Time.deltaTime;
            cooldownBar.value = cooldownTimer;
        }
    }
    public void Click()
    {
        if (cooldownTimer >= cooldown && playerShip.CurrentHealth > 0)
        {
            cooldownTimer = 0.0f;
            int playerDamage = playerShip.CurrentDamage;
            //int playerDamage = 10;
            enemyShip.TakeDamage(playerDamage);
        }
    }
}
