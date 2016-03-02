using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Animal"))
        {
            coll.gameObject.SendMessage("OnHitByProjectile",
                new DamagePacket()
                {
                    DamageValue = 2
                });
            gameObject.SetActive(false);
        }
        else if (coll.gameObject.CompareTag("ProjectileThreshold"))
        {
            gameObject.SetActive(false);
        }
    }
}
