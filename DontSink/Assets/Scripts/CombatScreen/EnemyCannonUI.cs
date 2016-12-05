﻿using UnityEngine;
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

    private GameObject update;
    private bool isBoss = false;

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        if (manager.Islands[manager.GetIsland() - 1] is EndIslandObject)
            isBoss = true;

        if (isBoss)
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EndIslandObject).Ship;
        else
            enemyShip = (manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Ship;
        playerShip = manager.GetPlayer().Ship;

        cooldownBar = this.gameObject.GetComponent<Slider>();
        cooldownBar.maxValue = cooldown;
        cooldownBar.value = cooldownTimer;

        update = GameObject.FindGameObjectWithTag("UIUpdate");
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
                cooldownTimer = 0.0f;
                int enemyDamage = 10; //enemyShip.CurrentDamage;
                playerShip.TakeDamage(enemyDamage);
            }

            cooldownBar.value = cooldownTimer;
        }
    }
}
