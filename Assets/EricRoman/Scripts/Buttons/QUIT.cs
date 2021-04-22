using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QUIT : MonoBehaviour
{
    public void quitGame() 
    {
        Debug.Log("Game has stopped!");
        Application.Quit();
    }
}
