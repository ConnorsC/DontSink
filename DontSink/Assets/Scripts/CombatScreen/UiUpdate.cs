using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour {

    private ShipObject player;
    private GameObject temp;
    private Slider playerHealthBar;
    private Slider playerHull;
    private Slider enemyHealthBar;
    private Slider enemyHull;
    private int playerMaxHealth;
    private int PlayerMaxHull;
    private GameManagerScript manager;

    // Use this for initialization
    void Awake () {

        //get player ship
        //temp = GameObject.FindGameObjectWithTag("PlayerInstance");
        // temp = manager.GetPlayer().Ship;

        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        if (manager.GetPlayer() == null)
        {
            print("null ship");
        }

        player = manager.GetPlayer().Ship;
        //get player healthbar and hull bar. I dont think this is safe
        playerHealthBar = (GameObject.FindGameObjectWithTag("PlayerHealthBar")).GetComponent<Slider>();
        playerHull = (GameObject.FindGameObjectWithTag("PlayerHullBar")).GetComponent<Slider>();

        //get enemy healthbar and hull bar. I dont think this is safe
        //enemyHealthBar = (GameObject.FindGameObjectWithTag("EnemyHealthBar")).GetComponent<Slider>();
        //enemyHull = (GameObject.FindGameObjectWithTag("EnemyHullBar")).GetComponent<Slider>();

        playerMaxHealth = player.MaxHealth;

        //set max values
        playerHealthBar.maxValue = playerMaxHealth;
        //PlayerMaxHull = player.maxHull;

        
    }

    void FixedUpdate () {

        playerHealthBar.value = player.CurrentHealth;
        //playerHealthBar.value = player.hull;


	}
}
