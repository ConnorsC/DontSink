using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossScreenUpdate : MonoBehaviour
{
    public bool gameOver = false;
    public bool pause = true;

    private PlayerShipObject player;
    private EnemyShipObject boss;
    private Slider playerHealthBar;
    private Slider playerHull;
    private Slider bossHealthBar;
    private Slider bossHull;

    private GameManagerScript manager;

    static string gameOverPath = "Objects/UI/GameOver";
    private GameObject gameOverObject;

    private GameObject leaveButton;
    private GameObject payoutPopup;

    public void Pause(bool pse)
    {
        pause = pse;
        payoutPopup.SetActive(pse);
    }
    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        gameOverObject = GameObject.FindGameObjectWithTag("GameOver");
        gameOverObject.SetActive(gameOver);

        leaveButton = GameObject.FindGameObjectWithTag("LeaveUI");
        leaveButton.SetActive(false);

        payoutPopup = GameObject.FindGameObjectWithTag("PayoutPopup");
        payoutPopup.transform.Find("Text").GetComponent<Text>().text = BossThreat();

        if (manager.GetPlayer() == null)
        {
            print("null ship");
            return;
        }

        player = manager.GetPlayer().Ship;
        boss = (manager.Islands[manager.GetIsland() - 1] as EndIslandObject).Ship;

        playerHealthBar = this.gameObject.transform.parent.Find("PlayerHealth").Find("HealthBar").gameObject.GetComponent<Slider>();
        playerHull = this.gameObject.transform.parent.Find("HullUI").Find("HullHP").gameObject.GetComponent<Slider>();

        bossHealthBar = this.gameObject.transform.parent.Find("EnemyUI").Find("HealthBar").gameObject.GetComponent<Slider>();
        bossHull = this.gameObject.transform.parent.Find("EnemyUI").Find("HullHP").gameObject.GetComponent<Slider>();

        // Set values for player and enemy hp
        playerHealthBar.maxValue = player.MaxHealth;
        playerHealthBar.value = player.CurrentHealth;
        bossHealthBar.maxValue = boss.MaxHealth;
        bossHealthBar.value = boss.CurrentHealth;

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
        if (boss.Hull != null)
        {
            bossHull.maxValue = boss.Hull.MaxHealth;
            bossHull.value = boss.Hull.CurrentHealth;
        }
        else
        {
            bossHull.maxValue = 0;
            bossHull.value = 0;
        }
    }

    void Update()
    {
        if (!gameOver && !pause)
        {
            // Update health
            playerHealthBar.value = player.CurrentHealth;
            bossHealthBar.value = boss.CurrentHealth;
            // Update hull hp if applicable
            if (player.Hull != null)
                playerHull.value = player.Hull.CurrentHealth;
            if (boss.Hull != null)
                bossHull.value = boss.Hull.CurrentHealth;

            // If any bar reaches 0 set the bar color to black
            if (playerHealthBar.value == 0)
            {
                EmptyBar(playerHealthBar);
                GameOver();
            }
            if (bossHealthBar.value == 0)
            {
                EmptyBar(bossHealthBar);
                DestroyEnemyShip();
            }
            if (playerHull.value == 0)
                EmptyBar(playerHull);
            if (bossHull.value == 0)
                EmptyBar(bossHull);
        }
    }
    void EmptyBar(Slider bar)
    {
        Color ded = Color.black;
        bar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = ded;
    }
    void DestroyEnemyShip()
    {
        string bossShipName = boss.ShipModel;
        string bossShipTag = bossShipName.Substring(14, bossShipName.Length - 14);
        GameObject enemyShip = GameObject.FindGameObjectWithTag(bossShipTag);
        ShipSink sink = enemyShip.AddComponent<ShipSink>();
        sink.sinkSpeed = 4;
        
        RemoveUI();
        CreateLeaveButton();
        CollectPayout();
    }
    void CreateLeaveButton()
    {
        leaveButton.SetActive(true);
    }
    void CollectPayout()
    {
        payoutPopup.SetActive(true);
        payoutPopup.transform.Find("Text").GetComponent<Text>().text = RewardPlayer();
    }
    void RemoveUI()
    {
        GameObject combatUI = GameObject.FindGameObjectWithTag("CombatUI");
        combatUI.SetActive(false);
    }
    void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(gameOver);

        ShipSink sink = player.ShipModel.AddComponent<ShipSink>();
        sink.sinkSpeed = 3;
    }
    string RewardPlayer()
    {

        if (boss.Boon == null)
        {
            int gold = 8 * manager.GetLevel();
            manager.GetPlayer().Gold += gold;
            return "You collect " + gold + " gold from the ship in the looting.";
        }
        else
        {
            manager.GetPlayer().Ship.AddItem(boss.Boon);
            return "You are able to salvage " + boss.Boon.Name + "from the wreckage.";
        }
    }
    private string BossThreat()
    {
        string ret = "";
        switch (manager.GetLevel())
        {
            case 1:
                ret += "Davy Jones be not here, let me take ye to his locker!";
                break;
            case 2:
                ret += "Ye wench be in another castle, jim laddie!";
                break;
            case 3:
                ret += "Be ready to meet ye salty sea-dog 'o a father in th' depths, boy!";
                break;
        }
        return ret;
    }
}
