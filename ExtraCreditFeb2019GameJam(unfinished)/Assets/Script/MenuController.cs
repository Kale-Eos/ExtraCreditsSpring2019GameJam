using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    AudioManager audioManager;
    public Animator anim;

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }
    }

    // UI Sound Control ////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]                                        // instantiates field
    string hoverOverSound = "ButtonHover";                  // instantiates Hover Over Sound
    [SerializeField]                                        // instantiates field
    string pressButtonSound = "ButtonPress";                // instantiates Press Button Sound

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);             // all buttons makes a sound when hovering
    }

    public void OnMouseDown()
    {
        audioManager.PlaySound(pressButtonSound);           // all buttons makes a sound when pressed
    }

    // Level BGM Control ///////////////////////////////////////////////////////////////////////////////////
    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       // loads onto the tutorial scene
        audioManager.PlaySound("Level1_BGM");                                       // Plays Level1_BGM
        audioManager.StopSound("Music");                                            // Stops main menu music
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);       // loads onto the tutorial scene
        audioManager.PlaySound("Level2_BGM");                                       // Plays Level2_BGM
        audioManager.StopSound("Music");                                            // Stops main menu music
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);       // loads onto the tutorial scene
        audioManager.PlaySound("Level3_BGM");                                       // Plays Level1_BGM
        audioManager.StopSound("Music");                                            // Stops main menu music
    }

    //   public void PlayCredits()
    //   {
    //       audioManager.StopSound("Music");            // Stops main menu music
    //       audioManager.StopSound("Level1_BGM");       // Stops level 1 music
    //   }

    //    public void CreditsTransition()
    //    {
    //        audioManager.StopSound("Music");            // Stops main menu music
    //        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
    //        audioManager.PlaySound("Credits_BGM");      // Plays Credits_BGM
    //    }


    public void BackToMainMenu()
    {
        audioManager.StopSound("Level1_BGM");       // Stops level 1 music
        audioManager.PlaySound("Music");            // Restarts main menu music
    }

    public void CreditsToMainMenu()
    {
        audioManager.StopSound("Credits_BGM");       // Stop playing Credits_BGM
        audioManager.PlaySound("Music");             // Restarts main menu music
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");     // types out ~Quitting Game~
        Application.Quit();             // and quits game
    }
}