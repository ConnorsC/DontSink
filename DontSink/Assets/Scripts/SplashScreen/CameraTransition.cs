using UnityEngine;
using System.Collections;

public class CameraTransition : MonoBehaviour {

    Animator anim;

    public void OnMouseDown()
    {
        anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        int campan = Animator.StringToHash("MenuSelect");
        anim.SetTrigger(campan);
    }
}
