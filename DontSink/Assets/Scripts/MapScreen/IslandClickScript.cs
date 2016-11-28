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
        print("Clicked Island: " + island);
        print("Current Island: " + manager.GetIsland());
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
                if (manager.GetIsland() == 5 || manager.GetIsland() == 8)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                break;
            default:
                print("Island cannot be selected!");
                break;
        }
    }
    private void LoadLevel()
    {
        // Will have more options soon
        if (manager.Islands[island] is MerchantIslandObject)
            manager.LoadLevel("PortScreen");
        else if (manager.Islands[island] is EnemyIslandObject)
            manager.LoadLevel("CombatScreen");
        else if (manager.Islands[island] is StartIslandObject)
            print("Start Island Type");
        else if (manager.Islands[island] is EndIslandObject)
            print("End Island Type");
        else if (manager.Islands[island] is DistressIslandObject)
            print("Distress Island Type");
        else
            print("Incorrect Island Type");
    }
    
}
