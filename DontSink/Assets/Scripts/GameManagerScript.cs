using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    // Use this for initialization

    public static GameManagerScript instance = null;
    public PlayerInformation playerInfo;

    private int currentIsland =1;
    private int currentLevel = 1;

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
        playerInfo = new PlayerInformation();
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

    public void SetPlayerShip(ShipObject ship)
    {
       playerInfo.Ship = new PlayerShipObject(ship);
    }

    public PlayerShipObject GetPlayerShip()
    {
       return playerInfo.Ship;
    }

    public void LoadLevel(string levelToload)
    {
        SceneManager.LoadScene(levelToload);
    }


}
