using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IslandClickScript : MonoBehaviour {

    public int island;
    private GameManagerScript manager;

    // Use this for initialization
    void Start()
    {
        manager = manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void OnMouseDown()
    {
        switch (island)
        {
            case 1:
                if(manager.GetIsland() == 1 || manager.GetIsland() == 2 || manager.GetIsland() == 3)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 2:
                if (manager.GetIsland() == 1 || manager.GetIsland() == 2 || manager.GetIsland() == 4)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 3:
                if (manager.GetIsland() == 1 || manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 4:
                if (manager.GetIsland() == 2 || manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 6 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 5:
                if (manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7 || manager.GetIsland() == 8)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 6:
                if (manager.GetIsland() == 4 || manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7 )
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 7:
                if (manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            case 8:
                if (manager.GetIsland() == 7 || manager.GetIsland() == 8)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
        }
    }
    private void LoadLevel()
    {
        // Will have more options soon
        manager.LoadLevel("CombatScreen");
    }
    
}
