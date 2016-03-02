using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    private InputController inputController;

	// Use this for initialization
	void Start ()
    {
        inputController = Resolver.Instance.GetController<InputController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //TODO: this shouldn't go here
        Vector3 projectileDestination;
	    if (inputController.GetRegionClicked(out projectileDestination) == InputController.ClickRegion.Right)
        {
            Debug.Log("Clicked at: " + projectileDestination.ToString());

            //FIRE PROJECTILE
            GameObject newProjectile = ProjectilePool.instance.NewProjectile();
            //spawns at the position of the character
            newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            Vector3 targetDir = projectileDestination - transform.position;
            float rotationAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            newProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));

            newProjectile.GetComponent<Rigidbody2D>().AddForce(newProjectile.transform.right * 125.0f);
        }
	}
}
