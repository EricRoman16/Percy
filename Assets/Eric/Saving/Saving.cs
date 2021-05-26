using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class Saving : MonoBehaviour
{
    public TMP_Text text;

    public bool smoke;
    public bool speed;
    public int health;
    public int scrap;
    public bool shield;

    //requirements
    public int h1req;
    public int h2req;
    public int h3req;
    public int smokereq;
    public int speedreq;
    public int shieldreq;
    public int rocketreq;


    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ":" + scrap;
        if(Input.GetKeyDown(KeyCode.K) == true)
        {
            scrap += 60;
        } //cheat code
    }
    /*
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        UpgradeSave data = new UpgradeSave();
        data.smoke = smoke;
        data.speed = speed;
        data.shield = shield;
        data.health = health;
        data.scrap = scrap;
        bf.Serialize(file, data);
        Debug.Log("Save Success");
        //switch to scavenging specific scene
        SceneManager.LoadScene(2);
    }
    */

    public void Save()
    {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("scrap", scrap);
        PlayerPrefs.SetInt("speed", Convert.ToInt32(speed));
        PlayerPrefs.SetInt("smoke", Convert.ToInt32(smoke));
        PlayerPrefs.SetInt("shield", Convert.ToInt32(shield));

        SceneManager.LoadScene(2);
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
            health = PlayerPrefs.GetInt("health", 0);
            switch (PlayerPrefs.GetInt("smoke", 0))
            {
                case 0:
                    smoke = false;
                    break;
                case 1:
                    smoke = true;
                    break;
            }
            switch (PlayerPrefs.GetInt("shield", 0))
            {
                case 0:
                    shield = false;
                    break;
                case 1:
                    shield = true;
                    break;
            }
            switch (PlayerPrefs.GetInt("speed", 0))
            {
                case 0:
                    speed = false;
                    break;
                case 1:
                    speed = true;
                    break;
            }
            scrap = PlayerPrefs.GetInt("scrap");

            Debug.Log("Load Success");
        }
        catch (Exception error)
        {
            Debug.LogError(error);
        }
    }
    /*
    public void Load()
    {
        try{
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            UpgradeSave data = bf.Deserialize(file) as UpgradeSave;
            file.Close();
            smoke = data.smoke;
            speed = data.speed;
            health = data.health;
            scrap = data.scrap;
            shield = data.shield;
            Debug.Log("Load Success");
        }
        catch (Exception error)
        {
            Debug.LogError(error);
        }
    }
    */
    public void Upgrade(int type)
    {
        switch (type)
        {
            case 0: //health
                if(scrap >= h1req && health == 0)
                {
                    ++health;
                    scrap -= h1req;
                }
                break;
            case 1:
                if (scrap >= h2req && health == 1)
                {
                    ++health;
                    scrap -= h2req;
                }
                break;
            case 2:
                if (scrap >= h3req && health == 2)
                {
                    ++health;
                    scrap -= h3req;
                }
                break;
            case 3: //speed
                if (scrap >= speedreq && !speed)
                {
                    speed = true;
                    scrap -= speedreq;
                }
                break;
            case 4: //shield
                if (scrap >= shieldreq && !shield)
                {
                    shield = true;
                    scrap -= shieldreq;
                }
                break;
            case 5: //smoke
                if (scrap >= smokereq && !smoke)
                {
                    smoke = true;
                    scrap -= smokereq;
                }
                break;
            case 6: //rocket --- END CONDITION
                if (scrap >= rocketreq)
                {
                    SceneManager.LoadScene(3); //Victory Screen
                }
                break;
            default:
                Debug.LogError("Upgrade Out Of Range!");
                break;
        }
    }
    public void ClearSave()
    {
        //File.Delete(Application.persistentDataPath + "/save.dat");
        PlayerPrefs.DeleteAll();
        Debug.Log("Save Cleared!");
    }
}
