using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(Mathf.Floor(Input.GetAxisRaw("Horizontal")), 0f, 0f);
            //Vector3.Lerp(transform.position, transform.position + new Vector3(-1f, 0f, 0f), .1f);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0f, Mathf.Floor(Input.GetAxisRaw("Vertical")), 0f);
        }
    }

    
}
