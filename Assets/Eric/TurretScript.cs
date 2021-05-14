using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float DetectRadius;
    public GameObject player;
    public float distX;
    public float distY;
    public float angle;
    public float dangle;
    public bool detected;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Determine Distance
        distX = Mathf.Abs(player.transform.position.x - transform.position.x);
        distY = Mathf.Abs(player.transform.position.y - transform.position.y);
        if (distX < DetectRadius && distY < DetectRadius)
        {
            detected = true;
        }
        else
        {
            detected = false;
        }
        //Determine Angle
        angle = Mathf.Atan2(distY, distX);
        dangle = Mathf.Rad2Deg * angle;
        //Determine Sprite Frame
        //Shoot bullet
        //
    }
}
