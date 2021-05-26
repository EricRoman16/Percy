using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePrefs : MonoBehaviour
{
    public Slider vol;
    // Start is called before the first frame update
    void Start()
    {
        vol.value = PlayerPrefs.GetFloat("volume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", vol.value);
    }
}
