using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public bool levelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (levelFinished)
        {
            LoadNextLevel();
            levelFinished = false;
        }
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitToBase()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToTitle()
    {
        SceneManager.LoadScene(0);
    }



    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}

    
