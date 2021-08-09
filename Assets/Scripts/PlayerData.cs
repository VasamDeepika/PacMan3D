using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerData : MonoBehaviour
{
    public string playerName;
    public int age;
    private void Start()
    {
        SetData();
        GetData();
    }
    public void SetData()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter writer = new BinaryWriter(stream);
        formatter.Serialize(stream, playerName);
        formatter.Serialize(stream, age);
        stream.Close();
    }
    public void GetData()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.file";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Open);
        formatter.Deserialize(stream);
        stream.Close();
    }
}
