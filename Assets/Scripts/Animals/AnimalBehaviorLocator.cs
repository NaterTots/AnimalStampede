using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimalBehaviorLocator
{
    private static object _instanceLock = new object();
    public static AnimalBehaviorLocator _instance;

    public static AnimalBehaviorLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AnimalBehaviorLocator();
                    }
                }
            }
            return _instance;
        }
    }

    //Dictionary<string, AnimalBehaviorBase> _animalBehaviorMap = new Dictionary<string, AnimalBehaviorBase>();

    private AnimalBehaviorLocator()
    {
        //_animalBehaviorMap.Add("bunny", new BunnyBehavior());
    }

    public AnimalBehaviorBase GetBehavior(string name)
    {
        switch(name)
        {
            case "bunny":
                return new BunnyBehavior();
        }

        return null;

        //System.Type t = typeof(BunnyBehavior);
        //TODO: instead of a switch...case, have this use a map
        //return _animalBehaviorMap[name];
    }
}
