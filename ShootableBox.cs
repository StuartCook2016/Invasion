using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ShootableBox : MonoBehaviour {

	Animator animated;
	public AudioClip death;
	public int currentHealth = 5;
	private int remainingBugs;
	public Text Bugs;
	GameObject textUI;
	
	Collider shootableCol;

	void Start()
	{
		animated = GetComponent<Animator>();
		shootableCol = GetComponent<Collider>();
        
	}
	public void Damage(int damageAmount)
	{
		currentHealth -= damageAmount;

		if(currentHealth <= 0)
		{
			gameObject.GetComponent<NavMeshAgent>().isStopped = true;
			shootableCol.enabled = false;
			StartCoroutine(Dead());
		}
	}
	IEnumerator Dead()
	{
		

		AudioSource audio = GetComponent<AudioSource>();
		audio.volume = 0.2f;
		audio.PlayOneShot(death);
		animated.SetTrigger("dead");
		remainingBugs--;
		//Bugs.text = "Remaining Bugs " + remainingBugs.ToString();
		yield return new WaitForSeconds(2f);		
		Destroy(gameObject);

	}
	public void increaseHealth(int newhealth){
		currentHealth = newhealth;
	}
	
}