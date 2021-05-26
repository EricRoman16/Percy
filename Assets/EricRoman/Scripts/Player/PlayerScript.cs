using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    #region Variables
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

    
    public Image battery;
    public Sprite b1;
    public Sprite b2;
    public Sprite b3;
    public Sprite b4;
    public Sprite b5;
    public Sprite b6;
    #endregion

    [Serializable]
    class UpgradeSave
    {
        public bool smoke;
        public bool speed;
        public bool shield;
        public int health;
        public int scrap;
    }

    public void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            UpgradeSave data = bf.Deserialize(file) as UpgradeSave;
            file.Close();
            smokeUpgrade = data.smoke;
            speedUpgrade = data.speed;
            shieldUpgrade = data.shield;
            healthUpgrade = data.health;
            scrap = data.scrap;

            Debug.Log("Load Success");
        }
        catch (Exception error)
        {
            Debug.Log(error);
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        UpgradeSave data = new UpgradeSave();
        data.smoke = smokeUpgrade;
        data.speed = speedUpgrade;
        data.shield = shieldUpgrade;
        data.health = healthUpgrade;
        data.scrap = scrap;
        bf.Serialize(file, data);
        Debug.Log("Save Success");

        //switch to base scene
        SceneManager.LoadScene(1);
    }


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

        UIHealth = (5 *(health / (healthUpgrade + 2)));

        if (healthUpgrade == 0)
        {
            if (health == 2) { UIHealth = 6; }
            if (health == 1) { UIHealth = 3; }
            if (health == 0) { UIHealth = 1; }
        }
        if (healthUpgrade == 1)
        {
            if (health == 3) { UIHealth = 6; }
            if (health == 2) { UIHealth = 4; }
            if (health == 1) { UIHealth = 2; }
            if (health == 0) { UIHealth = 1; }
        }
        if (healthUpgrade == 2)
        {
            if (health == 4){UIHealth = 6;}
            if (health == 3){UIHealth = 5;}
            if (health == 2){UIHealth = 3;}
            if (health == 1){UIHealth = 2;}
            if (health == 0){UIHealth = 1;}
        }
        if (healthUpgrade == 3)
        {
            if (health == 5){UIHealth = 6;}
            if (health == 4){UIHealth = 5;}
            if (health == 3){UIHealth = 4;}
            if (health == 2){UIHealth = 3;}
            if (health == 1){UIHealth = 2;}
            if (health == 0){UIHealth = 1;}
        }

        switch (UIHealth)
        {
            case 1:
                battery.sprite = b1;
                break;
            case 2:
                battery.sprite = b2;
                break;
            case 3:
                battery.sprite = b3;
                break;
            case 4:
                battery.sprite = b4;
                break;
            case 5:
                battery.sprite = b5;
                break;
            case 6:
                battery.sprite = b6;
                break;
            default:
                break;
        }

        if (health < 1)
        {
            scrap = 0;
            GameObject.Find("EventSystem").GetComponent<ScavengingLoad>().Save();
        }

    }

    
}
