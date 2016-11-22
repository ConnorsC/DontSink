using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScreenLoad : GameDriver {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;
    private MapGeneration mapGenerator;
    private List<IslandObject> islands;
    static string islandPrefabPath = "Objects/Islands/Island";

    // Use this for initialization
    void Start () {
        mapGenerator = new MapGeneration();
        playerShip = Instantiate(Resources.Load(manager.GetPlayer().Ship.getPrefabPath, typeof(GameObject))) as GameObject;

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            playerShip.transform.position = new Vector3(-7.9f, 0f, -17f);

        }

        // Call to set up the generation of the island objects
        islands = mapGenerator.GenerateMap(manager.GetLevel());
        SetIslands();
    }

    private void SetIslands()
    {
        switch (manager.GetLevel())
        {
            case 1:
                SetLevel1Map();
                break;
            default:
                break;
        }
    }
    private void SetLevel1Map()
    {
        int i = 1;
        foreach (IslandObject island in islands)
        {
            if (island is StartIslandObject)
            {
                island.IslandModel = Instantiate(Resources.Load(islandPrefabPath, typeof(GameObject))) as GameObject;
            }
            else if (island is MerchantIslandObject)
            {
                island.IslandModel = Instantiate(Resources.Load(islandPrefabPath, typeof(GameObject))) as GameObject;
            }
            else if (island is EnemyIslandObject)
            {
                island.IslandModel = Instantiate(Resources.Load(islandPrefabPath, typeof(GameObject))) as GameObject;
            }
            else if (island is DistressIslandObject)
            {
                island.IslandModel = Instantiate(Resources.Load(islandPrefabPath, typeof(GameObject))) as GameObject;
            }
            else if (island is EndIslandObject)
            {
                island.IslandModel = Instantiate(Resources.Load(islandPrefabPath, typeof(GameObject))) as GameObject;
            }
            else
            {
                print("The island type is not specified!");
            }
            switch (i)
            {
                case 1:
                    island.IslandModel.transform.Translate(-7.75f,0.0f,-5.5f);
                    break;
                case 2:
                    island.IslandModel.transform.Translate(-4f, 0.0f, 0.0f);
                    break;
                case 3:
                    island.IslandModel.transform.Translate(0.0f, 0.0f, -8.0f);
                    break;
                case 4:
                    island.IslandModel.transform.Translate(1.0f, 0.0f, -2.5f);
                    break;
                case 5:
                    island.IslandModel.transform.Translate(11.5f, 0.0f, -4f);
                    break;
                case 6:
                    island.IslandModel.transform.Translate(7f, 0.0f, 1f);
                    break;
                case 7:
                    island.IslandModel.transform.Translate(2.5f, 0.0f, -4.5f);
                    break;
                case 8:
                    island.IslandModel.transform.Translate(18f, 0.0f, -2f);
                    break;
                case 9:
                    break;
            }
            i++;
        }
    }
}
