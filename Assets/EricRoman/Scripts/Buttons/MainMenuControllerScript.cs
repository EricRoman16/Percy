using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuControllerScript : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;

    // Start is called before the first frame update
    void Start()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void SwitchToOptions()
    {
        OptionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void SwitchToMain()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
