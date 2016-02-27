using UnityEngine;
using System;
using System.Collections;

public class DataLoader : MonoBehaviour
{
    private const string DataFileName = "data";

    public void Start()
    {
        TextAsset dataFile = Resources.Load(DataFileName) as TextAsset;

        ConfigurationData configData = JsonUtility.FromJson<ConfigurationData>(dataFile.text);

        Resolver.Instance.GetController<ConfigurationManager>().AddSetting<ConfigurationData>(ConfigurationData.ConfigurationToken, configData);
    }
}

[Serializable]
public class ConfigurationData
{
    [NonSerialized]
    public static string ConfigurationToken = "ConfigurationData";

    public AnimalData[] animals;
    public LevelData[] levels;
}

[Serializable]
public class AnimalData
{
    public int id;
    public string name;
    public int speed;
    public int health;
}

[Serializable]
public class LevelData
{
    public int id;
    public string terrain;
    public float speedfactor;
    public LevelTimelineData[] timeline;
}

[Serializable]
public class LevelTimelineData
{
    public int step;
    public int animal;
    public int quantity;
}