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

    // Start is called before the first frame update
    void Start()
    {
        s1.SetActive(true);
        s2.SetActive(false);
        s3.SetActive(false);
        s4.SetActive(false);
        s5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if () { };
    }
}
