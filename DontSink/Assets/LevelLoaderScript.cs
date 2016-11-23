using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour {

    public void onClick()
    {
        print("load level!");
        LoadDialogueScene();
    }

    public void LoadDialogueScene()
    {
        SceneManager.LoadScene("DialogueScreen");
    }

    public void LoadPortScene()
    {
        SceneManager.LoadScene("PortScreen");
    }
}
