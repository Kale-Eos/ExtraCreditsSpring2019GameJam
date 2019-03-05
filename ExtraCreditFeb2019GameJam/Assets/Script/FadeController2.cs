using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController2 : MonoBehaviour
{
    public Animator anim;
    public string sceneName;

    public void Loader()
    {
        anim.SetTrigger("End");
        Invoke("LoadScene", 1);                             // loads onto the tutorial scene
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);                  // loads onto the tutorial scene
    }
}