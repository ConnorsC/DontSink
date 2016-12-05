using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapScreenLoad : MonoBehaviour {

    Quaternion rotation = new Quaternion();
    GameObject playerShip;
    private MapGeneration mapGenerator;
    static string islandPrefabPath = "Objects/Islands/Island";
    static string islandFlagPrefabPath = "Objects/Islands/FinalIslandFlag";
    private GameManagerScript manager;
    public GameObject TutorialUi;

    // Use this for initialization
    void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        TutorialUi.SetActive(false);
        mapGenerator = new MapGeneration();

        playerShip = manager.GetPlayer().Ship.ShipModel;

        if (manager.GetLevel() == 1)
        {
            print("loading 1");
            SetShipPos(manager.GetIsland());
            //playerShip.transform.position = new Vector3(-7.9f, 0f, -17f);
            //playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        }
        // manager.SetIsland(1);
        // Call to set up the generation of the island objects
        if(manager.LastGeneratedMap != manager.GetLevel())
        {
            manager.Islands = mapGenerator.GenerateMap(manager.GetLevel());
            manager.LastGeneratedMap = manager.GetLevel();
        }
        SetIslands(manager.Islands);

        if (manager.GetPlayer().LoadTurotial)
        {
            TutorialUi.SetActive(true);
            manager.GetPlayer().LoadTurotial = false;
        }

    }

    private void SetIslands(List<IslandObject> islands)
    {
        switch (manager.GetLevel())
        {
            case 1:
                SetLevel1Map(islands);
                break;
            case 2:
                SetLevel2Map(islands);
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
        // Denote teh last island
        GameObject flag = Instantiate(Resources.Load(islandFlagPrefabPath, typeof(GameObject))) as GameObject;
        flag.transform.position = new Vector3(18f, -.9f, -11f);
    }

    private void SetLevel2Map(List<IslandObject> islands)
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
                    island.IslandModel.transform.position = new Vector3(-15.7f, 0.0f, -12.8f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 1;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 1;
                    break;
                case 2:
                    island.IslandModel.transform.position = new Vector3(-10.9f, 0.0f, -8.75f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 2;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 2;
                    break;
                case 3:
                    island.IslandModel.transform.position = new Vector3(-15.63f, 0.0f, -3.9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 3;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 3;
                    break;
                case 4:
                    island.IslandModel.transform.position = new Vector3(-3.2f, 0.0f, -9.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 4;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 4;
                    break;
                case 5:
                    island.IslandModel.transform.position = new Vector3(-2.27f, 0.0f, -2.33f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 5;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 5;
                    break;
                case 6:
                    island.IslandModel.transform.position = new Vector3(4.3f, 0.0f, -9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 6;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 6;
                    break;
                case 7:
                    island.IslandModel.transform.position = new Vector3(8.87f, 0.0f, -3.53f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 7;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 7;
                    break;
                case 8:
                    island.IslandModel.transform.position = new Vector3(16.9f, 0.0f, -7f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 8;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 8;
                    break;
                case 9: //end island
                    island.IslandModel.transform.position = new Vector3(23, 0.0f, -13.68f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 9;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 9;
                    break;
                case 10:
                    island.IslandModel.transform.position = new Vector3(-12, 0.0f, -18.3f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 10;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 10;
                    break;
                case 11:
                    island.IslandModel.transform.position = new Vector3(-16.26f, 0.0f, -24f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 10;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 10;
                    break;
                case 12:
                    island.IslandModel.transform.position = new Vector3(-4.6f, 0.0f, -20.44f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 11;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 11;
                    break;
                case 13:
                    island.IslandModel.transform.position = new Vector3(9.77f, 0.0f, -16.2f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 12;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 12;
                    break;
                case 14:
                    island.IslandModel.transform.position = new Vector3(6.7f, 0.0f, -3.2f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 13;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 13;
                    break;
                case 15:
                    island.IslandModel.transform.position = new Vector3(13f, 0.0f, -23.1f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 14;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 14;
                    break;
                case 16:
                    island.IslandModel.transform.position = new Vector3(21.5f, 0.0f, -22.65f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 15;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 15;
                    break;

                default:
                    break;
            }
            i++;
        }
    }

    private void SetShipPos(int island)
    {
        switch (island)
        {
            case 1:
                playerShip.transform.position = new Vector3(-9.5f, 0f, -16f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                playerShip.transform.position = new Vector3(-5.75f, 0f, -8.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 3:
                playerShip.transform.position = new Vector3(-1.75f, 0f, -18.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 4:
                playerShip.transform.position = new Vector3(-1.25f, 0f, -11.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 5:
                playerShip.transform.position = new Vector3(9.25f, 0f, -14.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 6:
                playerShip.transform.position = new Vector3(5.25f, 0f, -9.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 7:
                playerShip.transform.position = new Vector3(3.75f, 0f, -14.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 8:
                playerShip.transform.position = new Vector3(17.25f, 0f, -12.5f);
                playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                playerShip.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            default:
                break;
        }
    }
}
