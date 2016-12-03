using UnityEngine;
using System.Collections;

public class ShipSink : MonoBehaviour {

    public int sinkSpeed;
    private bool rotate =true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (rotate)
        {
            transform.Rotate(Vector3.forward* 3 * Time.deltaTime);
            transform.Translate(Vector3.down * sinkSpeed / 10 * Time.deltaTime);

            if(transform.eulerAngles.z >= 80)
                rotate = false;
            
        }

        else
        {
            transform.Translate(Vector3.left * sinkSpeed / 10 * Time.deltaTime);
        }
	}
}
