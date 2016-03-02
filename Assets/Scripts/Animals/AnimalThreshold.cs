using UnityEngine;
using System.Collections;

public class AnimalThreshold : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Animal"))
        {
            coll.gameObject.SetActive(false);
            Resolver.Instance.GetController<EventHandler>().Post(Events.Level.AnimalPassedThreshold);
        }
    }
}
