﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player && player.GetComponent<PlayerScript>().shieldActive == false)
        {
            //reduce player health
            --player.GetComponent<PlayerScript>().health;
        }
        Object.Destroy(gameObject);  //destroys itself
    }
}
