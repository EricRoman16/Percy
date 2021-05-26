using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_UI_Handler : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool MusicPlaying = true;
    public GameObject OptionsMenu;
    public GameObject PauseMenuUI;
    public AudioSource AS;
    



    void Start()
    {
        PauseMenuUI.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Pause()
    {
        OptionsMenu.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ToggleMusic()
    {
        if(MusicPlaying)
        {
            AS.Pause();
            MusicPlaying = false;
        }
        else
        {
            AS.Play();
            MusicPlaying = true;
        }
        
    }

    public void Options()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(4);
    }
}
