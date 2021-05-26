using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseUpgradeButtons : MonoBehaviour
{
    public Button h1;
    public Button h2;
    public Button h3;
    public Button speed;
    public Button shield;
    public Button smoke;

    public Saving player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health == 0)
        {
            h1.interactable = true;
            h2.interactable = true;
            h3.interactable = true;
        }
        else if (player.health == 1)
        {
            h1.interactable = false;
            h2.interactable = true;
            h3.interactable = true;
        }
        else if (player.health == 2)
        {
            h1.interactable = false;
            h2.interactable = false;
            h3.interactable = true;
        }
        else if (player.health == 3)
        {
            h1.interactable = false;
            h2.interactable = false;
            h3.interactable = false;
        }
        if(player.speed == true)
        {
            speed.interactable = false;
        }
        else
        {
            speed.interactable = true;
        }
        if (player.smoke == true)
        {
            smoke.interactable = false;
        }
        else
        {
            smoke.interactable = true;
        }
        if (player.shield == true)
        {
            shield.interactable = false;
        }
        else
        {
            shield.interactable = true;
        }
    }
}
