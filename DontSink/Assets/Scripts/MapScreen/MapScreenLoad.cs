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

        // manager.SetIsland(1);
        // Call to set up the generation of the island objects
        if(manager.LastGeneratedMap != manager.GetLevel())
        {
            manager.Islands = mapGenerator.GenerateMap(manager.GetLevel());
            manager.LastGeneratedMap = manager.GetLevel();
        }
        SetIslands(manager.Islands);

        //move playership
        SetShipPos(manager.GetIsland());


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
            case 3:
                SetLevel3Map(islands);
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
            switch (i-1)
            {
                case 0:
                    island.IslandModel.transform.position = new Vector3(-7.75f,0.1f,-14.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 1;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 1;
                    island.ConnectedIsland = new List<int>{2,3,2,3};
                    island.IslandNumber = 1;
                    break;
                case 1:
                    island.IslandModel.transform.position = new Vector3(-4f,0.1f, -7.0f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 2;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 2;
                    island.ConnectedIsland = new List<int> { 1, 4,1,4 };
                    island.IslandNumber = 2;
                    break;
                case 2:
                    
                    island.IslandModel.transform.position = new Vector3(0.0f,0.1f, -17.0f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 3;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 3;
                    island.ConnectedIsland = new List<int> { 1, 7,1,7};
                    island.IslandNumber = 3;
                    break;
                case 3:
                    island.IslandModel.transform.position = new Vector3(1.0f,0.1f, -10f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 4;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 4;
                    island.ConnectedIsland = new List<int> { 7, 6,2,2 };
                    island.IslandNumber = 4;
                    break;
                case 4:
                    island.IslandModel.transform.position = new Vector3(11f,0.1f, -13f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 5;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 5;
                    island.ConnectedIsland = new List<int> { 8, 7 ,6,7};
                    island.IslandNumber = 5;
                    break;
                case 5:
                    island.IslandModel.transform.position = new Vector3(7f,0.1f, -8f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 6;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 6;
                    island.ConnectedIsland = new List<int> { 5, 4,7,4 };
                    island.IslandNumber = 6;
                    break;
                case 6:
                    island.IslandModel.transform.position = new Vector3(4.5f,0.1f, -13.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 7;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 7;
                    island.ConnectedIsland = new List<int> { 4, 3, 5, 6};
                    island.IslandNumber = 7;
                    break;
                case 7:
                    island.IslandModel.transform.position = new Vector3(18f,0.1f, -11f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 8;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 8;
                    island.ConnectedIsland = new List<int> { 5,5,5,5 };
                    island.IslandNumber = 8;
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
            switch (i-1)
            {
                case 0:
                    island.IslandModel.transform.position = new Vector3(-15.7f,0.1f, -12.8f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 1;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 1;
                    island.ConnectedIsland = new List<int> { 2, 2, 10, 10 };
                    island.IslandNumber = 1;
                    break;
                case 1:
                    island.IslandModel.transform.position = new Vector3(-10.9f,0.1f, -8.75f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 2;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 2;
                    island.ConnectedIsland = new List<int> { 1, 3, 4, 5 };
                    island.IslandNumber = 2;
                    break;
                case 2:
                    island.IslandModel.transform.position = new Vector3(-15.63f,0.1f, -3.9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 3;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 3;
                    island.ConnectedIsland = new List<int> { 2, 3, 2, 3 };
                    island.IslandNumber = 3;
                    break;
                case 3:
                    island.IslandModel.transform.position = new Vector3(-3.2f,0.1f, -9.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 4;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 4;
                    island.ConnectedIsland = new List<int> { 2, 5, 2, 6};
                    island.IslandNumber = 4;
                    break;
                case 4:
                    island.IslandModel.transform.position = new Vector3(-5.78f,0.1f, -4.35f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 5;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 5;
                    island.ConnectedIsland = new List<int> { 2, 2, 4, 4 };
                    island.IslandNumber = 5;
                    break;
                case 5:
                    island.IslandModel.transform.position = new Vector3(4.3f,0.1f, -9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 6;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 6;
                    island.ConnectedIsland = new List<int> { 13, 7, 8, 4 };
                    island.IslandNumber = 6;
                    break;
                case 6:
                    island.IslandModel.transform.position = new Vector3(8.87f,0.1f, -3.53f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 7;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 7;
                    island.ConnectedIsland = new List<int> { 6, 8, 6, 8 };
                    island.IslandNumber = 7;
                    break;
                case 7:
                    island.IslandModel.transform.position = new Vector3(11.72f,0.1f, -8.7f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 8;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 8;
                    island.ConnectedIsland = new List<int> { 6, 7, 9, 9 };
                    island.IslandNumber = 8;
                    break;
                case 8: //end island
                    island.IslandModel.transform.position = new Vector3(15.85f,0.1f, -13.28f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 9;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 9;
                    island.ConnectedIsland = new List<int> { 8, 8, 16, 16 };
                    island.IslandNumber = 9;
                    break;
                case 9:
                    island.IslandModel.transform.position = new Vector3(-12,0.1f, -18.3f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 10;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 10;
                    island.ConnectedIsland = new List<int> { 12, 1, 12, 1 };
                    island.IslandNumber = 10;
                    break;
                case 10:
                    island.IslandModel.transform.position = new Vector3(1f,0.1f, -24f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 11;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 11;
                    island.ConnectedIsland = new List<int> { 14, 14, 12, 12 };
                    island.IslandNumber = 11;
                    break;
                case 11:
                    island.IslandModel.transform.position = new Vector3(-4.6f,0.1f, -20.44f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 12;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 12;
                    island.ConnectedIsland = new List<int> { 11, 11, 10, 10 };
                    island.IslandNumber = 12;
                    break;
                case 12:
                    island.IslandModel.transform.position = new Vector3(4.82f,0.1f, -14.9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 13;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 13;
                    island.ConnectedIsland = new List<int> { 14, 14, 6, 6 };
                    island.IslandNumber = 13;
                    break;
                case 13:
                    island.IslandModel.transform.position = new Vector3(6.7f,0.1f, -20.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 14;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 14;
                    island.ConnectedIsland = new List<int> { 13, 15, 11, 11};
                    island.IslandNumber = 14;
                    break;
                case 14:
                    island.IslandModel.transform.position = new Vector3(13f,0.1f, -23.1f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 15;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 15;
                    island.ConnectedIsland = new List<int> { 16, 16, 14, 14 };
                    island.IslandNumber = 15;
                    break;
                case 15:
                    island.IslandModel.transform.position = new Vector3(17.43f,0.1f, -18.37f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 16;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 16;
                    island.ConnectedIsland = new List<int> { 9, 9, 15, 15 };
                    island.IslandNumber = 16;
                    break;

                default:
                    break;
            }
            i++;
        }
    }

    private void SetLevel3Map(List<IslandObject> islands)
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
            switch (i-1)
            {
                case 0:
                    island.IslandModel.transform.position = new Vector3(-15.7f,0.1f, -12.8f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 1;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 1;
                    island.ConnectedIsland = new List<int> { 2, 2, 10, 10 };
                    island.IslandNumber = 1;
                    break;
                case 1:
                    island.IslandModel.transform.position = new Vector3(-11.23f,0.1f, -9f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 2;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 2;
                    island.ConnectedIsland = new List<int> { 1, 3, 4, 10 };
                    island.IslandNumber = 2;
                    break;
                case 2:
                    island.IslandModel.transform.position = new Vector3(-7.43f,0.1f, -4.13f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 3;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 3;
                    island.ConnectedIsland = new List<int> { 2, 2, 4, 4 };
                    island.IslandNumber = 3;
                    break;
                case 3:
                    island.IslandModel.transform.position = new Vector3(-3.2f,0.1f, -9.5f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 4;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 4;
                    island.ConnectedIsland = new List<int> { 2,2 ,5,7 };
                    island.IslandNumber = 4;
                    break;
                case 4:
                    island.IslandModel.transform.position = new Vector3(2.87f,0.1f, -11.62f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 5;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 5;
                    island.ConnectedIsland = new List<int> { 14, 6, 4, 4 };
                    island.IslandNumber = 5;
                    break;
                case 5:
                    island.IslandModel.transform.position = new Vector3(8.87f,0.1f, -8.3f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 6;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 6;
                    island.ConnectedIsland = new List<int> { 5, 5, 16, 16 };
                    island.IslandNumber = 6;
                    break;
                case 6:
                    island.IslandModel.transform.position = new Vector3(1.27f,0.1f, -6);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 7;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 7;
                    island.ConnectedIsland = new List<int> { 4,4,5,5 };
                    island.IslandNumber = 7;
                    break;
                case 7:
                    island.IslandModel.transform.position = new Vector3(20.63f,0.1f, -2.3f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 8;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 8;
                    island.ConnectedIsland = new List<int> { 16, 16, 16, 16 };
                    island.IslandNumber = 8;
                    break;
                case 8: //end island
                    island.IslandModel.transform.position = new Vector3(22.9f,0.1f, -13.68f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 9;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 9;
                    island.ConnectedIsland = new List<int> { 16, 16, 16, 16 };
                    island.IslandNumber = 9;
                    break;
                case 9:
                    island.IslandModel.transform.position = new Vector3(-8.97f,0.1f, -14.45f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 10;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 10;
                    island.ConnectedIsland = new List<int> { 1, 2, 11, 11};
                    island.IslandNumber = 10;
                    break;
                case 10:
                    island.IslandModel.transform.position = new Vector3(-6.91f,0.1f, -20.44f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 11;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 11;
                    island.ConnectedIsland = new List<int> { 10, 12, 13, 13 };
                    island.IslandNumber = 11;
                    break;
                case 11:
                    island.IslandModel.transform.position = new Vector3(0.28f,0.1f, -23.67f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 12;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 12;
                    island.ConnectedIsland = new List<int> { 11, 11, 13, 13 };
                    island.IslandNumber = 12;
                    break;
                case 12:
                    island.IslandModel.transform.position = new Vector3(0.5f,0.1f, -17.89f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 13;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 13;
                    island.ConnectedIsland = new List<int> { 11, 12, 14, 14 };
                    island.IslandNumber = 13;
                    break;
                case 13:
                    island.IslandModel.transform.position = new Vector3(6.13f,0.1f, -16.2f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 14;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 14;
                    island.ConnectedIsland = new List<int> { 13, 5, 15, 15 };
                    island.IslandNumber = 14;
                    break;
                case 14:
                    island.IslandModel.transform.position = new Vector3(12.44f,0.1f, -15.12f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 15;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 15;
                    island.ConnectedIsland = new List<int> { 16, 16, 14, 14 };
                    island.IslandNumber = 15;
                    break;
                case 15:
                    island.IslandModel.transform.position = new Vector3(16.92f,0.1f, -10.19f);
                    island.IslandModel.GetComponent<IslandClickScript>().island = 16;
                    island.IslandModel.GetComponent<IslandMouseOverScript>().island = 16;
                    island.ConnectedIsland = new List<int> { 8, 9, 6, 15 };
                    island.IslandNumber = 16;
                    break;

                default:
                    break;
            }
            i++;
        }
    }

    private void SetShipPos(int island)
    {
        print("The current island is: " + island);

        List<IslandObject> islands = manager.Islands;
        playerShip.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        playerShip.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        
        playerShip.transform.position = (islands[island-1].IslandModel.transform.position + new Vector3(-1f,0f,1f));

    }
}
