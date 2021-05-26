using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditRoller : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    private GameObject[] screens = new GameObject[5];
    public int swapcount = 5;
    public int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        screens[0] = s1;
        screens[1] = s2;
        screens[2] = s3;
        screens[3] = s4;
        screens[4] = s5;

        for(int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            screens[current % swapcount].SetActive(false);
            current++;
            screens[current % swapcount].SetActive(true);

        }
    }
}
