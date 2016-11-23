using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour {
    Animator anim;
    /*public void onClick()
    {
        print("load level!");
        LoadDialogueScene();
    }*/

    public void LoadDialogueScene()
    {

        anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        int campan = Animator.StringToHash("TavernSceneLoad");
        anim.SetTrigger(campan);
        StartCoroutine(wait());
        //SceneManager.LoadScene("DialogueScreen");
    }

    public void LoadPortScene()
    {
        SceneManager.LoadScene("PortScreen");
    }

    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapScreen");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("DialogueScreen");
    }
}
