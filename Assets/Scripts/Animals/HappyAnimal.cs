using UnityEngine;
using System.Collections;

public class HappyAnimal : MonoBehaviour
{
    public static float delayBeforeMovement = 2.0f;

    AnimalData animalData;

    public void Initialize(AnimalData data)
    {
        animalData = data;

        ResourceController resourceController = Resolver.Instance.GetController<ResourceController>();

        Animator anim = GetComponent<Animator>();
        RuntimeAnimatorController animController = anim.runtimeAnimatorController;
        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = animController;
        overrideController["Transform_Placeholder"] = resourceController.GetAnimation(animalData.transform_animation);
        overrideController["Happy_Placeholder"] = resourceController.GetAnimation(animalData.happy_animation);
        overrideController["Run_Placeholder"] = resourceController.GetAnimation(animalData.run_animation);
        anim.runtimeAnimatorController = overrideController;

        anim.SetTrigger("transform");

        Invoke("StartMovement", delayBeforeMovement);
    }

    void StartMovement()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(animalData.speed * -1 * 20, 0f));
    }
}
