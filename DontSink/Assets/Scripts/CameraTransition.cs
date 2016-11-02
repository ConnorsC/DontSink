using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {

    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 0.0000002f;
    public GameObject objectToMove;
    public int gameState;

    public void OnMouseDown()
    {
        objectToMove.transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
