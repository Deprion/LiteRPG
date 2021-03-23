using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataScript : MonoBehaviour
{
    private string DataPath;
    private CharacterManager chrManager;
    void Awake()
    {
        DataPath = Application.persistentDataPath + "/Data.json";
        chrManager = GetComponent<CharacterManager>();
    }
    [Serializable]
    private class Data
    {
        public string[] CharacterPersonality;
        public int[] BaseStats;
    }
    public void SaveData()
    {
        string[] characterPersonality = new string[4];
        characterPersonality[0] = chrManager.Class;
        characterPersonality[1] = chrManager.Race;
        characterPersonality[2] = chrManager.Faith;
        characterPersonality[3] = chrManager.Zodiac;

        Data data = new Data()
        {
            CharacterPersonality = characterPersonality,
            BaseStats = chrManager.BaseStats,
        };
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(DataPath, FileMode.OpenOrCreate);
        bf.Serialize(file, data);
        file.Close();
    }
    public bool LoadData()
    {
        if (File.Exists(DataPath))
        {
            Data data = new Data();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(DataPath, FileMode.Open);
            data = (Data)bf.Deserialize(file);
            file.Close();
            chrManager.Class = data.CharacterPersonality[0];
            chrManager.Race = data.CharacterPersonality[1];
            chrManager.Faith = data.CharacterPersonality[2];
            chrManager.Zodiac = data.CharacterPersonality[3];
            chrManager.BaseStats = data.BaseStats;
            return true;
        }
        else return false;
    }
}
