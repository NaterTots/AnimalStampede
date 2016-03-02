using UnityEngine;
using System.Collections;

public class AnimalBehaviorBase
{
    protected AnimalData animalData;
    protected Animal animal;

    internal void Initialize(AnimalData data, Animal animalObject)
    {
        animalData = data;
        animal = animalObject;

        animal.GetComponent<Rigidbody2D>().AddForce(new Vector2(animalData.speed * -1 * 20, 0f));
    }

    public virtual void Update()
    {

    }

    public virtual int OnHitByProjectile(DamagePacket damage)
    {
        return damage.DamageValue;
    }
}
