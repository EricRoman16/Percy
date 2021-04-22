using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource ao;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        ao.Play();
    }

    void Update()
    {
        ao.volume = slider.value;
    }
}
