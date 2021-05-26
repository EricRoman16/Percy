using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

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
    public int UIHealth;

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


    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        health = healthUpgrade + 2;
    }

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
        catch
        {
            Debug.LogError("error");
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

    // Update is called once per frame
    void Update()
    {
        switch (speedUpgrade)
        {
            case true:
                ForceTarget = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                rb2.AddForce(ForceTarget);
                break;
            default:
                ForceTarget = new Vector2(Input.GetAxis("Horizontal") / 2, Input.GetAxis("Vertical") / 2);
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
            GameObject.Find("EventSystem").GetComponent<ScavengingLoad>().Save();
        }

        UIHealth = Mathf.RoundToInt(6 *(health / (healthUpgrade + 2)));
    }

    
}
