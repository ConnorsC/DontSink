using UnityEngine;
using System.Collections;

public class MapScreenLoad : MonoInterface {

    // Use this for initialization
    void Start () {
	
	}
    
    void OnLoad()
    {
        
        if (manager.GetLevel() == 1) {
            manager.GetPlayer().transform.position = new Vector3(-8f, 0f, -6.5f);

        }

    }	

}
