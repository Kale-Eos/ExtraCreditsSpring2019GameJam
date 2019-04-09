using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController3 : MonoBehaviour
{
    public Animator anim;
    public string sceneName;

    public void Loader()
    {
        Time.timeScale = 1f;                                // time is unfrozen
        anim.SetTrigger("End");
        Invoke("LoadScene", 1);                             // loads onto the tutorial scene
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);                  // loads onto the tutorial scene
    }
}