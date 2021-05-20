using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class Saving : MonoBehaviour
{
    public bool smoke;
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

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        UpgradeSave data = new UpgradeSave();
        data.smoke = smoke;
        data.speed = speed;
        data.health = health;
        bf.Serialize(file, data);
        Debug.Log("Save Success");
    }
    [Serializable]
    class UpgradeSave
    {
        public bool smoke;
        public bool speed;
        public int health;
        public int scrap;
    }

    public void Load()
    {
        try{
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            UpgradeSave data = (UpgradeSave)bf.Deserialize(file);
            file.Close();
            smoke = data.smoke;
            speed = data.speed;
            health = data.health;
            Debug.Log("Load Success");
        }
        catch (Exception error)
        {
            Debug.Log(error);
        }
    }
    
    public void SetHealth(int h)
    {
        health = h;
    }
}
