using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManagerScript : GameDriver {

    // Use this for initialization

    public static PlayerInformation playerInfo;

    private int currentIsland = 1;
    private int currentLevel = 1;
    private string lastScene;
    private static bool spawned = false;
    private bool canSelectShip = true;
    private int lastGeneratedMap = -1;
    private List<IslandObject> islands;
    private List<ItemObject> itemList1;
    private List<ItemObject> itemList2;
    private List<ItemObject> itemList3;

    public GameManagerScript()
    {
        canSelectShip = true;
    }

    public void Reset()
    {
        spawned = false;
        DestroyPlayerShip();
        DestroyImmediate(gameObject);
    }
    private void DestroyPlayerShip()
    {
        Destroy(playerInfo.Ship.ShipModel);
    }

    void Awake()
    {
        if (spawned == false)
        {
            spawned = true;
            DontDestroyOnLoad(gameObject);
            playerInfo = new PlayerInformation();

        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    void Start () {
        GenerateItemLists();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public PlayerInformation GetPlayer()
    {
        return playerInfo;
    }

    public void SetIsland(int x)
    {
        currentIsland = x;
    }
    public int GetIsland()
    {
        return currentIsland;
    }

    public void SetLevel(int x)
    {
        currentLevel = x;
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public void LoadLevel(string levelToload)
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelToload);
    }
    public void LoadLastScene() {
        SceneManager.LoadScene(lastScene);
    }
    public void DontDestroy(GameObject gameObject)
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StopAudio()
    {
        gameObject.GetComponent<AudioSource>().Pause();
    }
    public void StartAudio()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    public List<ItemObject> GetItemList()
    {
        //based on level, return the item set
        if (GetLevel() == 1)
            return itemList1;
        else if (GetLevel() == 2)
            return itemList2;
        else if (GetLevel() == 3)
            return itemList3;
        else
            return new List<ItemObject>();//else return an empty list to prevent null pointers
    }
    public List<ItemObject> GetItemList(int level)
    {
        //based on level, return the item set
        if (level == 1)
            return itemList1;
        else if (level == 2)
            return itemList2;
        else if (level == 3)
            return itemList3;
        else
            return new List<ItemObject>();//else return an empty list to prevent null pointers
    }

    public void SetItemList(List<ItemObject> desiredList)
    {
        //based on level, set item lists
        if (GetLevel() == 1)
            itemList1 = desiredList;
        else if (GetLevel() == 2)
            itemList2 = desiredList;
        else if (GetLevel() == 3)
            itemList3 = desiredList;
        else
            return;
    }

    public void SetItemList(List<ItemObject> desiredList, int level)
    {
        //based on level, set the item lists
        if (level == 1)
            itemList1 = desiredList;
        else if (level == 2)
            itemList2 = desiredList;
        else if (level == 3)
            itemList3 = desiredList;
        else
            return;
    }

    public void GenerateItemLists()
    {
        System.Random rnd = new System.Random();
        ItemGeneratorScript gen = new ItemGeneratorScript();
        itemList1 = gen.GenerateItems(1, rnd);
        itemList2 = gen.GenerateItems(2, rnd);
        itemList3 = gen.GenerateItems(3, rnd);
    }

    public List<IslandObject> Islands { get { return islands;} set { islands = value; } }
    public bool CanSelectShip { get { return canSelectShip; } set { canSelectShip = value; } }
    public int LastGeneratedMap { get { return lastGeneratedMap; } set { lastGeneratedMap = value; } }
}
