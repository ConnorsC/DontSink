using UnityEngine;
using System.Collections;

public class CannonBallShooter : MonoBehaviour {


    public GameObject cannonBall;
    private int force = 1000;

	// Use this for initialization
	void Start () {
	
	}

    public void Shoot(int cannon,GameObject ship,bool isPlayer)
    {

        if (isPlayer)
        {

            float cannonPosition = (cannon * 1.0f);
            var cannonball = (GameObject)Instantiate(cannonBall, ship.transform.position + new Vector3(0f, 1f, cannonPosition),
                                                                        cannonBall.transform.rotation);
            cannonball.GetComponent<Rigidbody>().AddForce(transform.forward * -force);
            Destroy(cannonball, 1f);

        }
        else
        {
            float cannonPosition = (cannon * 1.0f);
            var cannonball = (GameObject)Instantiate(cannonBall, ship.transform.position + new Vector3(0f, 1f, cannonPosition),
                                                                        cannonBall.transform.rotation);
            cannonball.GetComponent<Rigidbody>().AddForce(transform.forward * -force);
            Destroy(cannonball, 1f);
        }
    }
}
