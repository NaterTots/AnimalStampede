using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour
{
    //"Health" is a value of 1-5.  this determines the total health
    public static int HealthMultiplier = 3;

    Animator anim;

    AnimalData animalData;
    AnimalBehaviorBase animalBehavior;

    public AnimationClip clip;

    int currentHealth;

    public void Initialize(AnimalData animal)
    {
        animalData = animal;

        ResourceController resourceController = Resolver.Instance.GetController<ResourceController>();

        //TODO: what happens to this logic when an animal is recycled?
        anim = GetComponent<Animator>();
        RuntimeAnimatorController animController = anim.runtimeAnimatorController;
        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = animController;
        overrideController["Run_Placeholder"] = resourceController.GetAnimation(animalData.run_animation);
        overrideController["Hit_Placeholder"] = resourceController.GetAnimation(animalData.hit_animation);
        overrideController["Special_Placeholder"] = resourceController.GetAnimation(animalData.special_animation);
        clip = resourceController.GetAnimation(animalData.run_animation);
        anim.runtimeAnimatorController = overrideController;

        currentHealth = animalData.health * HealthMultiplier;

        animalBehavior = AnimalBehaviorLocator.Instance.GetBehavior(animalData.behavior);
        animalBehavior.Initialize(animalData, this);
    }

	// Update is called once per frame
	void Update ()
    {
        animalBehavior.Update();
	}

    public void OnHitByProjectile(DamagePacket damage)
    {
        Debug.Log("Animal.OnHitByProjectile");

        int damageValue = animalBehavior.OnHitByProjectile(damage);

        if (damageValue > 0)
        {
            currentHealth -= damage.DamageValue;
            anim.SetTrigger("hit");
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            //spawn happy animal
            GameObject newHappyAnimal = AnimalPool.instance.NewHappyAnimal();
            newHappyAnimal.transform.position = transform.position;
            newHappyAnimal.SendMessage("Initialize", animalData);
        }
    }
}
