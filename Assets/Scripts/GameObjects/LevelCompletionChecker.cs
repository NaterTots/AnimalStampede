using UnityEngine;
using System.Collections;

public class LevelCompletionChecker : MonoBehaviour
{
    bool timelineComplete = false;

	// Use this for initialization
	void Start ()
    {
        EventHandler eventHandler = Resolver.Instance.GetController<EventHandler>();
        eventHandler.Register(Events.Level.AnimalPassedThreshold, OnAnimalPassedThreshold);
        eventHandler.Register(Events.Level.TimelineComplete, OnTimelineComplete);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //once the timeline is complete, begin checking to see when all the animals are transformed
	    if (timelineComplete)
        {
            if (!AnimalPool.instance.animalObjectPool.HasActiveObjects())
            {
                Debug.Log("Level Won.");
                Resolver.Instance.GetController<EventHandler>().PostExec(Events.Level.WonLevel);
            }
        }
	}

    void OnAnimalPassedThreshold(int id, object param)
    {
        Debug.Log("Level Lost.");
        Resolver.Instance.GetController<EventHandler>().PostExec(Events.Level.LostLevel);
    }

    void OnTimelineComplete(int id, object param)
    {
        timelineComplete = true;
    }

}
