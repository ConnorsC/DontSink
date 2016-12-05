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
        manager.LoadLevel("MapScreen");
        switch (island)
        {
            case 1:
                if(manager.GetIsland() == 1 || manager.GetIsland() == 2 || manager.GetIsland() == 3)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }else
                    print("Island cannot be selected from this island!");
                break;
            case 2:
                if (manager.GetIsland() == 1 || manager.GetIsland() == 2 || manager.GetIsland() == 4)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 3:
                if (manager.GetIsland() == 1 || manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 4:
                if (manager.GetIsland() == 2 || manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 6 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 5:
                if (manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7 || manager.GetIsland() == 8)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 6:
                if (manager.GetIsland() == 4 || manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7 )
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 7:
                if (manager.GetIsland() == 3 || manager.GetIsland() == 4 || manager.GetIsland() == 5 || manager.GetIsland() == 6 || manager.GetIsland() == 7)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            case 8:
                if (manager.GetIsland() == 5 || manager.GetIsland() == 8)
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
                else
                    print("Island cannot be selected from this island!");
                break;
            default:
                print("Island cannot be selected!");
                break;
        }
    }
    private void LoadLevel()
    {
        // Will have more options soon
        if (manager.Islands[island-1] is MerchantIslandObject)
            manager.LoadLevel("PortScreen");
        else if (manager.Islands[island-1] is EnemyIslandObject)
            manager.LoadLevel("CombatScreen");
        else if (manager.Islands[island-1] is StartIslandObject)
            print("Start Island Type");
        else if (manager.Islands[island-1] is EndIslandObject)
            print("End Island Type");
        else if (manager.Islands[island-1] is DistressIslandObject)
            manager.LoadLevel("DistressScreen");
        else
            print("Incorrect Island Type");
    }
    
}
