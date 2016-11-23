using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManagerScript : GameDriver{

    // Use this for initialization

    public static PlayerInformation playerInfo;

    private int currentIsland =1;
    private int currentLevel = 1;
    private string lastScene;
    private static bool spawned = false;
    private List<IslandObject> islands;

    public GameManagerScript()
    {
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
    public List<IslandObject> Islands { get { return islands;} set { islands = value; } }
}
