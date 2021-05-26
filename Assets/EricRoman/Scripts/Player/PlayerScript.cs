using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2;

    public Vector2 ForceTarget;

    public bool speedUpgrade;
    public bool smokeUpgrade;
    public bool shieldUpgrade;
    public int healthUpgrade;
    public int scrap = 0;

    public int health;
    public float UIHealth;

    public bool shieldActive;

    //timing
    public float shieldTime;
    public float shieldLeft;
    public int shields;


    public bool smokeActive;

    //timing
    public float smokeTime;
    public float smokeLeft;
    public int smokes;

    public float defaultSpeed = 20;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        health = healthUpgrade + 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch (speedUpgrade)
        {
            case true:
                ForceTarget = new Vector2((Input.GetAxis("Horizontal") * defaultSpeed) * Time.deltaTime, Input.GetAxis("Vertical") * defaultSpeed * Time.deltaTime);
                rb2.AddForce(ForceTarget);
                break;
            default:
                ForceTarget = new Vector2((Input.GetAxis("Horizontal") * defaultSpeed / 2) * Time.deltaTime, ((Input.GetAxis("Vertical") * defaultSpeed) / 2) * Time.deltaTime);
                rb2.AddForce(ForceTarget);
                break;
        }

        if(Input.GetAxis("Smoke") > 0.95 && smokeUpgrade == true && smokeLeft <= 0 && smokes > 0)
        {
            smokeLeft = smokeTime;
            --smokes;
            smokeActive = true;
        }
        if(Input.GetAxis("Shield") > 0.95 && shieldUpgrade == true && shieldLeft <= 0 && shields > 0)
        {
            shieldLeft = shieldTime;
            --shields;
            shieldActive = true;
        }

        smokeLeft -= Time.deltaTime;
        shieldLeft -= Time.deltaTime;

        if(smokeLeft <= 0)
        {
            smokeActive = false;
        }
        if(shieldLeft <= 0)
        {
            shieldActive = false;
        }


        //no upgrade 6-3
        //1 upgrade 6-4-2
        //2 6532
        //3 65432

        


        if (health < 1)
        {
            scrap = 0;
            //GameObject.Find("EventSystem").GetComponent<ScavengingLoad>().Save();
        }

        UIHealth = Mathf.RoundToInt(6 *(health / (healthUpgrade + 2)));


    }

    
}
