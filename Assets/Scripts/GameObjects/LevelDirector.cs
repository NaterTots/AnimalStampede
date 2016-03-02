using UnityEngine;
using System.Collections;

public class LevelDirector : MonoBehaviour
{
    //All levels have timesteps 1->100
    //At a normal speed factor, a level will take 100 * baseTime seconds
    public float baseTimeBetweenTimeSteps = 1.0f;

    float timeBetweenTimeSteps;

    int currentTimeStep = 0;
    float timeSinceLastTimeStep = 0.0f;
    int timelineDataCursor = 0;
    bool timelineComplete = false;

    LevelData currentLevel;
    AnimalData[] animals;
	// Use this for initialization
	void Start ()
    {
        GameSequenceData currentSequence = Resolver.Instance.GetController<GameSceneManager>().currentSequence;
        ConfigurationData configData = Resolver.Instance.GetController<ConfigurationManager>().GetSettingValue<ConfigurationData>(ConfigurationData.ConfigurationToken);
        animals = configData.animals;

        foreach (LevelData level in configData.levels)
        {
            if (level.id == currentSequence.typeid)
            {
                currentLevel = level;
                break;
            }
        }
        
        if (currentLevel == null)
        {
            Debug.Log("Unable to find level " + currentSequence.typeid);
        }

        timeBetweenTimeSteps = currentLevel.speedfactor * baseTimeBetweenTimeSteps;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!timelineComplete)
        {
            timeSinceLastTimeStep += Time.deltaTime;

            if (timeSinceLastTimeStep >= timeBetweenTimeSteps)
            {
                currentTimeStep++;
                timeSinceLastTimeStep = 0.0f;
                CheckTimeline();
            }
        }
	}

    void CheckTimeline()
    {
        if (currentLevel.timeline[timelineDataCursor].step <= currentTimeStep)
        {
            ActivateNewTimelineData(currentLevel.timeline[timelineDataCursor]);

            timelineDataCursor++;
            if (timelineDataCursor >= currentLevel.timeline.Length)
            {
                timelineComplete = true;
                Resolver.Instance.GetController<EventHandler>().Post(Events.Level.TimelineComplete);
            }
            else
            {
                //we could have multiple timeline elements activated on the same step, so we need to keep checking
                CheckTimeline();
            }
        }
    }

    void ActivateNewTimelineData(LevelTimelineData timelineData)
    {
        foreach (AnimalData animal in animals)
        {
            if (animal.id == timelineData.animal)
            {
                for (int i = 0; i < timelineData.quantity; i++)
                {
                    GameObject newAnimal = AnimalPool.instance.NewAnimal();
                    //TODO: better way to determine spawn region for animals
                    newAnimal.transform.position = new Vector2(9, Random.Range(-4f, 1f));
                    newAnimal.GetComponent<Animal>().Initialize(animal);
                    
                }
            }
        }
    }
}
