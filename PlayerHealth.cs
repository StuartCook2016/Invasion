using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider HealthBar;
	private AudioSource panic;

	bool isDead;
	bool takenDamage;

	void Start () 
	{
		currentHealth = startingHealth;
		panic = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (Input.GetKey("escape"))
            Application.Quit();
		// TakeDamage(1);
	}
	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;
		HealthBar.value = currentHealth;

		if(currentHealth <= 20)
		{
			panic.Play();
		}
		if(currentHealth <= 0 && !isDead)
		{
			playerDead();
		}

	}
	void playerDead()
	{
		isDead = true;
		//Add Game Over
		Debug.Log("Player is Dead");
	}
}
