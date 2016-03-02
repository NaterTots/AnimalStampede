using UnityEngine;
using System.Collections;

public class HappyAnimalThreshold : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("HappyAnimal"))
        {
            coll.gameObject.SetActive(false);
        }
    }
}
