﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretScript : MonoBehaviour
{
    public float defaultRadius;
    public float DetectRadius;
    public GameObject player;
    private PlayerScript pScript;
    public Vector2 distance;
    public float angle;
    public float dangle;
    public bool detected;
    public Object Bullet;
    public float magnitude;
    public float bulletSpeed;
    public float rate;
    public float count;

    //Frames
    public Sprite south;
    public Sprite southwest;
    public Sprite west;
    public Sprite northwest;
    public Sprite north;
    public Sprite northeast;
    public Sprite east;
    public Sprite southeast;

    public Sprite Last;

    //components
    private SpriteRenderer sprite;

    private GameObject NewBullet;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        count = rate;
        DetectRadius = defaultRadius;
        
        pScript = player.GetComponent<PlayerScript>();
        Last = south;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;

        switch (pScript.smokeActive)
        {
            case true:
                DetectRadius = defaultRadius / 2;
                break;
            default:
                DetectRadius = defaultRadius;
                break;
        }

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
                Last = southwest;
            }
            else if (dangle >= 67.5 && dangle <= 112.5)
            {
                sprite.sprite = west;
                Last = west;
            }
            else if (dangle >= 112.5 && dangle <= 157.5)
            {
                sprite.sprite = northwest;
                Last = northwest;
            }
            else if (dangle >= 157.5 && dangle <= 202.5)
            {
                sprite.sprite = north;
                Last = north;
            }
            else if (dangle >= 202.5 && dangle <= 247.5)
            {
                sprite.sprite = northeast;
                Last = northeast;
            }
            else if (dangle >= 247.5 && dangle <= 292.5)
            {
                sprite.sprite = east;
                Last = east;
            }
            else if (dangle >= 292.5 && dangle <= 337.5)
            {
                sprite.sprite = southeast;
                Last = southeast;
            }
            else if (dangle >= 337.5 )
            {
                sprite.sprite = south;
                Last = south;
            }
            else
            {
                sprite.sprite = south;
                Last = south;
            }
        }
        else
        {
            sprite.sprite = Last;
        }
        //Shoot bullet
        if (detected == true && count <= 0)
        {
            NewBullet = (GameObject) Instantiate(Bullet, transform.position, Quaternion.LookRotation(new Vector3(0, 0, 1), new Vector3(0, 0, 1)));
            NewBullet.GetComponent<Rigidbody2D>().SetRotation(dangle - 180);
            magnitude = Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2));
            NewBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * (distance.x/magnitude), bulletSpeed * (distance.y/magnitude));
            count = rate;
        }
        
        //
    }
}
