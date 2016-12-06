using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IslandClickScript : MonoBehaviour {

    public int island;
    private GameManagerScript manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            manager.LoadLevel("MapScreen");
            List<int> connectedIslands = FindIsland(island).ConnectedIsland;
            for(int x = 0; x <= connectedIslands.Capacity-1; x++)
            {
                if(connectedIslands[x] == manager.GetIsland())
                {
                    manager.SetIsland(island);
                    LoadLevel();
                }
            }

        }
    }

    public IslandObject FindIsland(int islandToFind)
    {
        List<IslandObject> islands = manager.Islands;

        for (int x = 0; x <= islands.Count; x++)
        {

            if (islands[x].IslandNumber == islandToFind)
            {
                return islands[x];
            }
        }

        print("couldent find island: " + islandToFind);
        return null;
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
            manager.LoadLevel("BossScene");
        else if (manager.Islands[island-1] is DistressIslandObject)
            manager.LoadLevel("DistressScreen");
        else
            print("Incorrect Island Type");
    }
    
}
