using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetViolume : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("volume");
    }
}
