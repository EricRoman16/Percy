﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvageScript : MonoBehaviour
{
    // Start is called before the first frame update4

    private GameObject player;

    public Vector2 distance;

    public float collectDist;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = new Vector2(Mathf.Abs(transform.position.x - player.transform.position.x), Mathf.Abs(transform.position.y - player.transform.position.y));
        if(distance.x <= collectDist && distance.y <= collectDist)
        {
            player.GetComponent<PlayerScript>().scrap += 1;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerScript>().scrap += 1;
            Destroy(this.gameObject);
        }
    }
}
