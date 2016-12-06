using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CannonUIController : MonoBehaviour
{
    private GameObject button;
    private GameObject cooldownBarObject;
    private Slider cooldownBar;
    private Text text;

    public float cooldown = 10;
    public string cannonName = "Cannon";
    private float cooldownTimer;
    public int cannonNumber;

    private EnemyShipObject enemyShip;
    private PlayerShipObject playerShip;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private CannonBallShooter cannoBallShooter;
    private GameManagerScript manager;

    private GameObject update;
    private bool isBoss = false;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        cannoBallShooter = manager.GetPlayer().Ship.CannonBallShooter;
        if (manager.Islands[manager.GetIsland() - 1] is EndIslandObject)
            isBoss = true;

        audioClip = Resources.Load<AudioClip>("Audio/CannonSound");
        audioSource = GameObject.FindGameObjectWithTag("GameAudio").GetComponent<AudioSource>();

        if (isBoss)
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EndIslandObject).Ship;
        else
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;

        playerShip = manager.GetPlayer().Ship;
        button = this.gameObject.transform.parent.Find("CannonSelect").gameObject;
        cooldownBarObject = this.gameObject.transform.parent.Find("CannonCooldown").gameObject;
        cooldownBar = cooldownBarObject.GetComponent<Slider>();
        text = button.transform.Find("CannonName").GetComponent<Text>();

        text.text = cannonName;
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldown;
        cooldownTimer = 0.0f;

        update = GameObject.FindGameObjectWithTag("UIUpdate");
    }
    void Update()
    {
        bool conditional;
        if (isBoss)
            conditional = !update.GetComponent<BossScreenUpdate>().gameOver && !update.GetComponent<BossScreenUpdate>().pause;
        else
            conditional = !update.GetComponent<UiUpdate>().gameOver && !update.GetComponent<UiUpdate>().pause;
        if (conditional)
        {
            if (cooldownTimer < cooldown)
                cooldownTimer += Time.deltaTime;
            else 
            {
                cooldownBarObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;

                text.color = Color.red;
            }
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

            cooldownBarObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            audioSource.PlayOneShot(audioClip);
            GameObject player = manager.GetPlayer().Ship.ShipModel;
            cannoBallShooter = GameObject.FindGameObjectWithTag(manager.GetPlayer().PlayerShipTag).GetComponent<CannonBallShooter>();
            cannoBallShooter.Shoot(cannonNumber, player);
            text.color = Color.white;
        }
    }
}
