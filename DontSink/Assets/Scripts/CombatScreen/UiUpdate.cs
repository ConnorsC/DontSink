using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour
{
    private PlayerShipObject player;
    private EnemyShipObject enemy;
    private Slider playerHealthBar;
    private Slider playerHull;
    private Slider enemyHealthBar;
    private Slider enemyHull;

    private GameManagerScript manager;

    // Use this for initialization
    void Awake ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        if (manager.GetPlayer() == null)
        {
            print("null ship");
            return;
        }

        player = manager.GetPlayer().Ship;
        enemy = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;

        // Get player & enemy healthbar and hull bar. // Possibly unsafe
        playerHealthBar = this.gameObject.transform.parent.Find("PlayerHealth").Find("HealthBar").gameObject.GetComponent<Slider>();
        playerHull = this.gameObject.transform.parent.Find("HullUI").Find("HullHP").gameObject.GetComponent<Slider>();

        enemyHealthBar = this.gameObject.transform.parent.Find("EnemyUI").Find("HealthBar").gameObject.GetComponent<Slider>();
        enemyHull = this.gameObject.transform.parent.Find("EnemyUI").Find("HullHP").gameObject.GetComponent<Slider>();

        // Set values for player and enemy hp
        playerHealthBar.maxValue = player.MaxHealth;
        playerHealthBar.value = player.CurrentHealth;
        enemyHealthBar.maxValue = enemy.MaxHealth;
        enemyHealthBar.value = enemy.CurrentHealth;

        // Set values for player and enemy hull hp if applicable
        if (player.Hull != null)
        {
            playerHull.maxValue = player.Hull.MaxHealth;
            playerHull.value = player.Hull.CurrentHealth;
        }
        else
        {
            playerHull.maxValue = 0;
            playerHull.value = 0;
        }
        if(enemy.Hull != null)
        {
            enemyHull.maxValue = enemy.Hull.MaxHealth;
            enemyHull.value = enemy.Hull.CurrentHealth;
        }
        else
        {
            enemyHull.maxValue = 0;
            enemyHull.value = 0;
        }
    }

    void Update ()
    {
        // Update health
        playerHealthBar.value = player.CurrentHealth;
        enemyHealthBar.value = enemy.CurrentHealth;
        // Update hull hp if applicable
        if (player.Hull != null)
            playerHull.value = player.Hull.CurrentHealth;
        if (enemy.Hull != null)
            enemyHull.value = enemy.Hull.CurrentHealth;

        // If any bar reaches 0 set the bar color to black
        if (playerHealthBar.value == 0)
            EmptyBar(playerHealthBar);
        if (enemyHealthBar.value == 0)
            EmptyBar(enemyHealthBar);
        if (playerHull.value == 0)
            EmptyBar(playerHull);
        if (enemyHull.value == 0)
            EmptyBar(enemyHull);

    }
    void EmptyBar(Slider bar)
    {
        Color ded = Color.black;
        bar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = ded;
    }
}
