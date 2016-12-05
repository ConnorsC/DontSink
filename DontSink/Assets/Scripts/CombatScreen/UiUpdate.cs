using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour
{
    private static System.Random rnd = new System.Random();

    public bool gameOver = false;
    public bool pause = true;

    private PlayerShipObject player;
    private EnemyShipObject enemy;
    private Slider playerHealthBar;
    private Slider playerHull;
    private Slider enemyHealthBar;
    private Slider enemyHull;

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
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        gameOverObject = GameObject.FindGameObjectWithTag("GameOver");
        gameOverObject.SetActive(gameOver);

        leaveButton = GameObject.FindGameObjectWithTag("LeaveUI");
        leaveButton.SetActive(false);

        payoutPopup = GameObject.FindGameObjectWithTag("PayoutPopup");
        if ((manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Defeated == false)
            payoutPopup.transform.Find("Text").GetComponent<Text>().text = PirateThreat();
        else
            payoutPopup.SetActive(false);

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
        if ((manager.Islands[manager.GetIsland() - 1] as EnemyIslandObject).Defeated == true)
        {
            string enemyShipName = enemy.ShipModel;
            string enemyShipTag = enemyShipName.Substring(14, enemyShipName.Length - 14);
            GameObject.FindGameObjectWithTag(enemyShipTag).SetActive(false);
            RemoveUI();
            CreateLeaveButton();
        }
        else if (!gameOver && !pause)
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
            {
                EmptyBar(playerHealthBar);
                GameOver();
            }
            if (enemyHealthBar.value == 0)
            {
                EmptyBar(enemyHealthBar);
                DestroyEnemyShip();
            }
            if (playerHull.value == 0)
                EmptyBar(playerHull);
            if (enemyHull.value == 0)
                EmptyBar(enemyHull);
        }
    }
    void EmptyBar(Slider bar)
    {
        Color ded = Color.black;
        bar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = ded;
    }
    void DestroyEnemyShip()
    {
        string enemyShipName = enemy.ShipModel;
        string enemyShipTag = enemyShipName.Substring(14, enemyShipName.Length-14);
        GameObject enemyShip = GameObject.FindGameObjectWithTag(enemyShipTag);
        ShipSink sink = enemyShip.AddComponent<ShipSink>();
        sink.sinkSpeed = 4;
        //GameObject.FindGameObjectWithTag(enemyShipTag).SetActive(false);
        //enemyHealthBar.gameObject.SetActive(false);
        //enemyHull.gameObject.SetActive(false);
        //GameObject[] enemyCannons = GameObject.FindGameObjectsWithTag("EnemyCannonUI");
        //foreach(GameObject enemyCannonUI in enemyCannons)
        //{
        //    enemyCannonUI.SetActive(false);
        //}
        RemoveUI();
        CreateLeaveButton();
        CollectPayout();
        //Will later be called by clicking a button
        //ReturnToMap();

    }
    void GameOver()
    {
        gameOver = true;
        gameOverObject.SetActive(gameOver);

        ShipSink sink = player.ShipModel.AddComponent<ShipSink>();
        sink.sinkSpeed = 3;
    }
    void RemoveUI()
    {
        GameObject combatUI = GameObject.FindGameObjectWithTag("CombatUI");
        combatUI.SetActive(false);
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
    string RewardPlayer()
    {
        
        if (enemy.Boon == null)
        {
            int gold = rnd.Next(2 + manager.GetLevel(), 5 + 2 * manager.GetLevel());
            manager.GetPlayer().Gold += gold;
            return "You collect " + gold + " gold from the ship in the looting.";
        }
        else
        {
            manager.GetPlayer().Ship.AddItem(enemy.Boon);
            return "You are able to salvage " + enemy.Boon.Name + "from the wreckage.";
        }
    }
    string PirateThreat()
    {
        switch (rnd.Next(0, 4))
        {
            case 0:
                return "We'll be havin’ yer gold!";
            case 1:
                return "Men, it's plunderin’ time!";
            case 2:
                return "I'll plunder yer coffer ye barnacle bottomed sluggard!";
            case 3:
                return "Dead men tell no tales!";
            case 4:
                return "Hoist ‘em over th’ yardom!";
            case 5:
                return "Surrender or die ye lice infested salt hog!";
            case 6:
                return "I'll cut out yer tongue an’ feed ta th’ sharks!";
            case 7:
                return "We’ll dance th’ hornpipe oer’ yer grave!";
            case 8:
                return "Give us th’ gold ye slovenly milk maid!";
            case 9:
                return "Prepare fer yer doom!";
            case 10:
                return "Feed ‘em to th’ sharks!";
            default:
                return "";
        }
    }
}
