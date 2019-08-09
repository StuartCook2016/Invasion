using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastShoot : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRate = 0.25f;
	public float weaponRange = 50f;
	public float hitForce = 100f;
	public Transform gunEnd;

	public GameObject bloodEffect;
	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
	private AudioSource gunAudio;
	private LineRenderer laserLine;
	private float nextFire;

	public int maxAmmo = 15;
	public int currentAmmo;
	private float reloadTime = 2f;
	private bool isReloading = false;
	public Text Ammo;
	private bool isAxisInUse = false;


	// Use this for initialization
	void Start () 
	{

		laserLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		fpsCam = GetComponentInParent<Camera> ();
		currentAmmo = maxAmmo;
		SetAmmoText();

	}
	
	// Update is called once per frame
	void Update () 
	{	
			if(isReloading)
			{
				return;
			}
			if(currentAmmo <= 0)
			{
				StartCoroutine(Reload());
				return;
			}
			if(Input.GetKeyDown("r") && currentAmmo < maxAmmo)
			{
				StartCoroutine(Reload());
				return;
			}
		   	if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		   	{
				nextFire = Time.time + fireRate;
				Fire();
		   	}


	}
	public void SetAmmoText ()
    {
        
		if(isReloading)
		{
			Ammo.text = "Reloading";
		}
		else
		{
			Ammo.text = "Ammo: " + currentAmmo.ToString();
		}

    }
	IEnumerator Reload()
	{
		isReloading = true;
		SetAmmoText();
		yield return new WaitForSeconds(reloadTime);
		currentAmmo = maxAmmo;
		isReloading = false;
		SetAmmoText();
		
	}
	void Fire()
	{
				currentAmmo--;
				SetAmmoText();
				gunAudio.Play();
				Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0f));
				RaycastHit hit;

				laserLine.SetPosition(0,gunEnd.position);
				if(Physics.Raycast(rayOrigin,fpsCam.transform.forward,out hit,weaponRange))
				{
					laserLine.SetPosition(1,hit.point);

					ShootableBox health = hit.collider.GetComponent<ShootableBox>();
					

					if (health != null)
					{
						Debug.Log("DAMAGE!!");
						Instantiate(bloodEffect, hit.point, transform.rotation);
						health.Damage(gunDamage);
					}
					if(hit.rigidbody != null)
					{
						hit.rigidbody.AddForce(-hit.normal*hitForce);
					}

					BossShootableBox bossHealth = hit.collider.GetComponent<BossShootableBox>();
					
					if (bossHealth != null)
					{
						Debug.Log("DAMAGE!!");
						Instantiate(bloodEffect, hit.point, transform.rotation);
						bossHealth.Damage(gunDamage);
					}
					if(hit.rigidbody != null)
					{
						hit.rigidbody.AddForce(-hit.normal*hitForce);
					}
				}
				else
				{
					laserLine.SetPosition(1,rayOrigin + (fpsCam.transform.forward * weaponRange));
				}
	}

}

