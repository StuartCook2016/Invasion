using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour {
	
	//public Slider HealthBar;

	// When an object enters the collider
	void OnTriggerEnter(Collider other)
	{
		// If name of the object entering the collider
		// is the enemy explode
		if(other.name == "Player")
		{
			GivePower();
		}
	}

	void GivePower() {

		gameObject.GetComponent<Renderer>().enabled = false;

		//int rdmPowerup = UnityEngine.Random.Range(1, 3);
		int rdmPowerup = 3;
		print(rdmPowerup);

		if(rdmPowerup == 1)
			StartCoroutine(DoubleDamage());	

		else if(rdmPowerup == 2)
			IncreaseHealth();

		else if(rdmPowerup == 3)
			StartCoroutine(RapidFire());

		//else if(rdmPowerup == 4)
	}


	IEnumerator DoubleDamage() 
    {
		GameObject gun = GameObject.Find("FPSController/FirstPersonCharacter/PM-40_Variant1/");
		RayCastShoot raycast = gun.GetComponent<RayCastShoot>();

		raycast.gunDamage = 2;
		//print("PowerupGiven");

        yield return new WaitForSeconds(10f);

		raycast.gunDamage = 1;
        print("Powerup Removed");

		// Remove Powerup
		Destroy(gameObject);
		//print("GameObject removed");
    }

	IEnumerator RapidFire() 
    {
		GameObject gun = GameObject.Find("FPSController/FirstPersonCharacter/PM-40_Variant1/");
		RayCastShoot raycast = gun.GetComponent<RayCastShoot>();

		print("TEST");
		raycast.fireRate = 0.1f;
		raycast.currentAmmo = 30;
		raycast.maxAmmo = 30;
		raycast.SetAmmoText();
		//print("PowerupGiven");

        yield return new WaitForSeconds(10f);

		raycast.fireRate = 0.25f;
		raycast.currentAmmo = 15;
		raycast.maxAmmo = 15;
		raycast.SetAmmoText();
        print("Powerup Removed");

		// Remove Powerup
		Destroy(gameObject);
		//print("GameObject removed");
    }

	void IncreaseHealth() 
    {
		GameObject player = GameObject.Find("FPSController/Player/");
		PlayerHealth increaseHp = player.GetComponent<PlayerHealth>();

		if(increaseHp.currentHealth <= 75)
			increaseHp.currentHealth = increaseHp.currentHealth+25;

		increaseHp.HealthBar.value = increaseHp.currentHealth;

        print("Health Increased");

		// Remove Powerup
		Destroy(gameObject);
    }

}