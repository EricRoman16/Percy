using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class ScavengingLoad : MonoBehaviour
{
    public PlayerScript player;

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
            player.speedUpgrade = data.speed;
            player.shieldUpgrade = data.shield;
            player.healthUpgrade = data.health;
            player.scrap = data.scrap;
            
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
        data.smoke = player.smokeUpgrade;
        data.speed = player.speedUpgrade;
        data.shield = player.shieldUpgrade;
        data.health = player.healthUpgrade;
        data.scrap = player.scrap;
        bf.Serialize(file, data);
        Debug.Log("Save Success");

        //switch to base scene
        SceneManager.LoadScene(1);
    }

    
}
