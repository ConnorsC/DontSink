using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : GameDriver{

    // Use this for initialization

    public static PlayerInformation playerInfo;

    private int currentIsland =1;
    private int currentLevel = 1;
    private string lastScene;

    public GameManagerScript()
    {
    }

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(this);

        //Sets this to not be destroyed when reloading scene

        DontDestroyOnLoad(this);
        playerInfo = new PlayerInformation();

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

}
