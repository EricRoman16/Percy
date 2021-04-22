using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
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

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelName);
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadCredits()
    {
        StartCoroutine(LoadLevel("Credits"));
    }
    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel("Level1"));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel("MainMenu"));
    }
}

    
