using UnityEngine;
using System.Collections;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool instance;

    public ObjectPool projectileObjectPool;

    void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start()
    {
        projectileObjectPool.Initialize();
    }

    public GameObject NewProjectile()
    {
        return projectileObjectPool.InitNewObject();
    }
}
