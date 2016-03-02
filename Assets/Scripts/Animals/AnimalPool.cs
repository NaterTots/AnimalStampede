using UnityEngine;
using System.Collections;

public class AnimalPool : MonoBehaviour
{
    public static AnimalPool instance;

    public ObjectPool animalObjectPool;
    public ObjectPool happyAnimalObjectPool;

    void Awake()
    {
        instance = this;
    }


	// Use this for initialization
	void Start ()
    {
        animalObjectPool.Initialize();
        happyAnimalObjectPool.Initialize();
	}
	
    public GameObject NewAnimal()
    {
        return animalObjectPool.InitNewObject();
    }

    public GameObject NewHappyAnimal()
    {
        return happyAnimalObjectPool.InitNewObject();
    }
}
