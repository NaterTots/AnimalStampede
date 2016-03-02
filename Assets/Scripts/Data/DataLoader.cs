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
    public StoryData[] stories;
    public GameSequenceData[] gamesequence;
}

[Serializable]
public class AnimalData
{
    public int id;
    public string name;
    public int speed;
    public int health;
    public string hit_animation;
    public string transform_animation;
    public string run_animation;
    public string happy_animation;
    public string special_animation;
    public string behavior;
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

[Serializable]
public class StoryData
{
    public int id;
    public StoryTimelineData[] timeline;
}

[Serializable]
public class StoryTimelineData
{
    public int step;
    public string actor;
}

[Serializable]
public class GameSequenceData
{
    public int id;
    public string type;
    public int typeid;
}