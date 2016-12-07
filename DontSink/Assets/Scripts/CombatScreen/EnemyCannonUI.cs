using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCannonUI : MonoBehaviour
{
    public float cooldown = 10;
    public int damage = 0;

    private Slider cooldownBar;
    private float cooldownTimer = 0;
    private GameManagerScript manager;
    private EnemyShipObject enemyShip;
    private GameObject enemyShipGameObject;
    private PlayerShipObject playerShip;
    private AudioSource audioSource;
    private AudioClip audioClip;

    private GameObject update;
    private bool isBoss = false;

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        audioClip = Resources.Load<AudioClip>("Audio/CannonSound2");
        audioSource = GameObject.FindGameObjectWithTag("GameAudio").GetComponent<AudioSource>();

        

        if (manager.Islands[manager.GetIsland() - 1] is EndIslandObject)
            isBoss = true;

        if (isBoss)
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EndIslandObject).Ship;
        else
        {
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;
        }
        playerShip = manager.GetPlayer().Ship;
        //enemyShipGameObject = GameObject.FindGameObjectWithTag(enemyShip.ShipModel.Substring(enemyShip.ShipModel.Length - 14));

        cooldownBar = this.gameObject.GetComponent<Slider>();
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldownTimer;

        update = GameObject.FindGameObjectWithTag("UIUpdate");
        if (!isBoss && GameObject.FindGameObjectWithTag(enemyShip.ShipModel.Substring(enemyShip.ShipModel.Length - 10))!=null)
            enemyShipGameObject = GameObject.FindGameObjectWithTag(enemyShip.ShipModel.Substring(enemyShip.ShipModel.Length - 10));
        else if (isBoss && GameObject.FindGameObjectWithTag(enemyShip.ShipModel.Substring(enemyShip.ShipModel.Length - 9)) != null)
            enemyShipGameObject = GameObject.FindGameObjectWithTag(enemyShip.ShipModel.Substring(enemyShip.ShipModel.Length - 9));
    }

    // Update is called once per frame
    void Update ()
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

            if (cooldownTimer >= cooldown && enemyShip.CurrentHealth > 0)
            {
                audioSource.PlayOneShot(audioClip);
                //this should work if i can get the prefab on screen
                //enemyShip.CannonBallShooter.Shoot(1, enemyShipModel, false);
                cooldownTimer = 0.0f;
                int enemyDamage = 10; //enemyShip.CurrentDamage;
                playerShip.TakeDamage(enemyDamage);
            }

            cooldownBar.value = cooldownTimer;
        }
    }
}
