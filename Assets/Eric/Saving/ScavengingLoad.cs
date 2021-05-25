using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class ScavengingLoad : MonoBehaviour
{
    public PlayerAbilities player;

    private bool smoke;
    public bool speed;
    public int health;
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
            player.hasSmokeUpgrade = data.smoke;
            player.hasSpeedUpgrade = data.speed;
            switch (data.health)
            {
                case 0:
                    player.hasHealthUpgrade1 = false;
                    player.hasHealthUpgrade2 = false;
                    player.hasHealthUpgrade3 = false;
                    break;
                case 1:
                    player.hasHealthUpgrade1 = true;
                    player.hasHealthUpgrade2 = false;
                    player.hasHealthUpgrade3 = false;
                    break;
                case 2:
                    player.hasHealthUpgrade1 = true;
                    player.hasHealthUpgrade2 = true;
                    player.hasHealthUpgrade3 = false;
                    break;
                case 3:
                    player.hasHealthUpgrade1 = true;
                    player.hasHealthUpgrade2 = true;
                    player.hasHealthUpgrade3 = true;
                    break;
            }
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
        data.smoke = player.hasSmokeUpgrade;
        data.speed = player.hasSpeedUpgrade;
        if (player.hasHealthUpgrade3)
        {
            data.health = 3;
        }
        else if (player.hasHealthUpgrade2)
        {
            data.health = 2;
        }
        else if (player.hasHealthUpgrade1)
        {
            data.health = 1;
        }
        else
        {
            data.health = 0;
        }
        bf.Serialize(file, data);
        Debug.Log("Save Success");

        //switch to base scene
        SceneManager.LoadScene(1);
    }

    
}
