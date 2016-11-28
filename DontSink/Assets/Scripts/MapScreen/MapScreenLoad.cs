using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScreenLoad : MonoBehaviour {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;
    private MapGeneration mapGenerator;
    static string islandPrefabPath = "Objects/Islands/Island";
    private GameManagerScript manager;

    // Use this for initialization
    void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        mapGenerator = new MapGeneration();

        playerShip = manager.GetPlayer().Ship.ShipModel;

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            playerShip.transform.position = new Vector3(-7.9f, 0f, -17f);
            playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        }
        // manager.SetIsland(1);
        // Call to set up the generation of the island objects
        if(manager.LastGeneratedMap != manager.GetLevel())
        {
            manager.Islands = mapGenerator.GenerateMap(manager.GetLevel());
            manager.LastGeneratedMap = manager.GetLevel();
        }
        SetIslands(manager.Islands);
    }

    private void SetIslands(List<IslandObject> islands)
    {
        switch (manager.GetLevel())
        {
            case 1:
                SetLevel1Map(islands);
                break;
            default:
                break;
        }
    }
    private void SetLevel1Map(List<IslandObject> islands)
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
                    island.IslandModel.transform.position = new Vector3(-7.75f,0.0f,-14.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 1;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 1;
                    break;
                case 2:
                    island.IslandModel.transform.position = new Vector3(-4f, 0.0f, -7.0f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 2;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 2;
                    break;
                case 3:
                    island.IslandModel.transform.position = new Vector3(0.0f, 0.0f, -17.0f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 3;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 3;
                    break;
                case 4:
                    island.IslandModel.transform.position = new Vector3(1.0f, 0.0f, -10f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 4;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 4;
                    break;
                case 5:
                    island.IslandModel.transform.position = new Vector3(11f, 0.0f, -13f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 5;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 5;
                    break;
                case 6:
                    island.IslandModel.transform.position = new Vector3(7f, 0.0f, -8f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 6;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 6;
                    break;
                case 7:
                    island.IslandModel.transform.position = new Vector3(4.5f, 0.0f, -13.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 7;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 7;
                    break;
                case 8:
                    island.IslandModel.transform.position = new Vector3(18f, 0.0f, -11f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 8;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 8;
                    break;
                default:
                    break;
            }
            i++;
        }
    }
}
