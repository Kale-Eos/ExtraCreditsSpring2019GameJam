using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    string sceneName1 = "Level1";
    [SerializeField]
    string sceneName2 = "Level2";
    [SerializeField]
    string sceneName3 = "Level3";
    [SerializeField]
    string sceneNameFree = "FreeRoam";

    public void Loader1()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene1", 1);                             // loads onto the Level 1 scene
    }

    public void Loader2()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene2", 1);                             // loads onto the Level 2 scene
    }

    public void Loader3()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene3", 1);                             // loads onto the Level 2 scene
    }

    public void LoaderFree()
    {
        anim.SetTrigger("End");
        Invoke("LoadSceneFreeRoam", 1);                      // loads onto the Free Roam scene
    }

    void LoadScene1()
    {
        SceneManager.LoadScene(sceneName1);                  // function onto the Level 1 scene
    }

    void LoadScene2()
    {
        SceneManager.LoadScene(sceneName2);                  // function onto the Level 2 scene
    }

    void LoadScene3()
    {
        SceneManager.LoadScene(sceneName3);                  // function onto the Level 2 scene
    }

    void LoadSceneFreeRoam()
    {
        SceneManager.LoadScene(sceneNameFree);               // function onto the tutorial scene
    }
}
