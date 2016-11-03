using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    // Use this for initialization

    public static GameManagerScript instance = null;

    private int currentIsland =1;
    private int currentLevel = 1;


    public GameObject player;
    public PlayerInformation playerInfo;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }


    void Start () {
	
        playerInfo= player.GetComponent<PlayerInformation>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetPlayer()
    {
        return player;
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

    public void SetPlayerShip(GameObject ship)
    {
        playerInfo.setShip(ship);
    }

    public void LoadLevel(string levelToload)
    {
        SceneManager.LoadScene(levelToload);
    }


}
