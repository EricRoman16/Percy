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
    public bool LevelWon = false;
    public GameObject OptionsMenu;
    public GameObject PauseMenuUI;
    public GameObject WinLoseMenu;
    public GameObject Lose;
    public GameObject Win;
    private AudioSource AS;
    public GameObject level;



    void Start()
    {
        PauseMenuUI.SetActive(false);
        AS = level.GetComponent<AudioSource>();
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

    public void WinLoseScreen()
    {
        WinLoseMenu.SetActive(true);
        if (LevelWon)
        {
            Lose.SetActive(false);
            Win.SetActive(true);
        }
        else
        {
            Win.SetActive(false);
            Lose.SetActive(true);
        }
    }
}
