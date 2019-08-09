using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public float force = 100f;
	public GameObject explosionEffect;
	public float radius = 1f;
	
	// When an object enters the collider
	void OnTriggerEnter(Collider other)
	{
		// If name of the object entering the collider
		// is the enemy explode
		print(other.name);
		if(other.name == "Insectoid(Clone)")
		{
			Explode();
		}
	}


	void Explode()
	{
		// Instantiate explosion
		Instantiate(explosionEffect, transform.position, transform.rotation);

		// Create collision radius
		Collider[] collision = Physics.OverlapSphere(transform.position,radius);

		// For each object in the collision check it has a rigidbody
		foreach (Collider nearbyObject in collision)
		{
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if(rb != null)
			{
				rb.AddExplosionForce(force, transform.position, radius);
			}

			// Damage the enemy
			ShootableBox damage = nearbyObject.GetComponent<ShootableBox>();
			if(damage != null)
			{
				damage.Damage(3);
			}
		}
		// Remove Mine
		Destroy(gameObject);
	}


}
