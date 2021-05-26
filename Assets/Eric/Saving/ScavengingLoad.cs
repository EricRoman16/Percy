using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class ScavengingLoad : MonoBehaviour
{
    //public PlayerScript player;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            player.GetComponent<PlayerScript>().smokeUpgrade = data.smoke;
            player.GetComponent<PlayerScript>().speedUpgrade = data.speed;
            player.GetComponent<PlayerScript>().shieldUpgrade = data.shield;
            player.GetComponent<PlayerScript>().healthUpgrade = data.health;
            player.GetComponent<PlayerScript>().scrap = data.scrap;
            
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
        data.smoke = player.GetComponent<PlayerScript>().smokeUpgrade;
        data.speed = player.GetComponent<PlayerScript>().speedUpgrade;
        data.shield = player.GetComponent<PlayerScript>().shieldUpgrade;
        data.health = player.GetComponent<PlayerScript>().healthUpgrade;
        data.scrap = player.GetComponent<PlayerScript>().scrap;
        bf.Serialize(file, data);
        Debug.Log("Save Success");

        //switch to base scene
        SceneManager.LoadScene(1);
    }

    
}
