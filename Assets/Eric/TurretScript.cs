﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretScript : MonoBehaviour
{
    public float DetectRadius;
    public GameObject player;
    public Vector2 distance;
    public float angle;
    public float dangle;
    public bool detected;

    //Frames
    public Sprite south;
    public Sprite southwest;
    public Sprite west;
    public Sprite northwest;
    public Sprite north;
    public Sprite northeast;
    public Sprite east;
    public Sprite southeast;

    //components
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Determine Distance

        distance = player.transform.position - transform.position;
        if (Mathf.Abs(distance.x) < DetectRadius && Mathf.Abs(distance.y) < DetectRadius)
        {
            /*if(Physics.Raycast(transform.position, distance, DetectRadius, 2))
            {
                detected = true;
                
            }
            else
            {
                Debug.Log("Within detection, failed raycast");
            }*/  //raycast for detection.  If disabled, can see through walls.  I think it's set wrong
            detected = true;
        }
        else
        {
            detected = false;
            
        }
        //Determine Angle
        angle = Mathf.Atan2(distance.x, distance.y);
        dangle = (Mathf.Rad2Deg * angle) + 180; //0 is -y so it's incorrect but whatever
        //Determine Sprite Frame
        if(detected == true)
        {
            if (dangle >= 22.5 && dangle <= 67.5)
            {
                sprite.sprite = southwest;
            }
            else if (dangle >= 67.5 && dangle <= 112.5)
            {
                sprite.sprite = west;
            }
            else if (dangle >= 112.5 && dangle <= 157.5)
            {
                sprite.sprite = northwest;
            }
            else if (dangle >= 157.5 && dangle <= 202.5)
            {
                sprite.sprite = north;
            }
            else if (dangle >= 202.5 && dangle <= 247.5)
            {
                sprite.sprite = northeast;
            }
            else if (dangle >= 247.5 && dangle <= 292.5)
            {
                sprite.sprite = east;
            }
            else if (dangle >= 292.5 && dangle <= 337.5)
            {
                sprite.sprite = southeast;
            }
            else if (dangle >= 337.5)
            {
                sprite.sprite = southeast;
            }
            else
            {
                sprite.sprite = south;
            }
        }
        else
        {
            sprite.sprite = south;
        }
        //Shoot bullet
        //
    }
}