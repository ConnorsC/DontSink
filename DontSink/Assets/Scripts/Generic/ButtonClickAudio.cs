using UnityEngine;
using System.Collections;

public class ButtonClickAudio : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip audioClip;
	
    void Start()
    {
        audioClip = Resources.Load<AudioClip>("Audio/button_click");
        audioSource = GameObject.FindGameObjectWithTag("GameAudio").GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
