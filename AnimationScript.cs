using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

    public bool isAnimated = false;

    public bool isRotating = false;
    public bool isFloating = false;
    public bool isScaling = false;

    public Vector3 rotationAngle;
    public float rotationSpeed;

    public float floatSpeed;
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;
   
    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;

    int count = 0;

    // void Start() {
    //     print(transform.name);
    // }

	// Update is called once per frame
	void Update () {

        if(isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if(isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}

    // When an object enters the collider
	void OnTriggerEnter(Collider other)
	{
		// If name of the object entering the collider
		// is the enemy explode
        print(other.name);

        if(other.name == "FPSController") 
        {
        count++;
        }
		if(count == 1)
		{
            print("START");
            transform.position = new Vector3(0,99f,0);
			GivePower();
		}
	}

	void GivePower() 
    {
        print(transform.name);
		gameObject.GetComponent<Renderer>().enabled = false;
        count = 0;
		if(transform.name == "Hexgon(Clone)")
			StartCoroutine(DoubleDamage());	

		else if(transform.name == "Heart(Clone)")
			StartCoroutine(IncreaseHealth());

		else if(transform.name == "Diamondo(Clone)")
			StartCoroutine(RapidFire());

		else if(transform.name == "SphereGemLarge(Clone)")
			StartCoroutine(IncreaseGrenades());
	}


	IEnumerator DoubleDamage() 
    {
		GameObject gun = GameObject.Find("FPSController/FirstPersonCharacter/PM-40_Variant1/");
		RayCastShoot raycast = gun.GetComponent<RayCastShoot>();

		raycast.gunDamage = 2;

        GameObject textUI = GameObject.Find("HUD/PowerType/");
		Text powerType = textUI.GetComponent<Text>();
        powerType.text = "Double Damage!";

		//print("PowerupGiven");

        yield return new WaitForSeconds(30f);

		raycast.gunDamage = 1;
        //print("Powerup Removed");
        powerType.text = "Powerup Removed";

        yield return new WaitForSeconds(5f);
        powerType.text = "";


        GameObject anotherPowerup = GameObject.Find("PowerupLocations/");
		DeployPowerup deploy = anotherPowerup.GetComponent<DeployPowerup>();
        
        yield return new WaitForSeconds(5f);
        deploy.ChooseSpawners(3);
        print("ANOTHER POWERUP SPAWNED");

		// Remove Powerup
		Destroy(gameObject);
		//print("GameObject removed");
    }

	IEnumerator RapidFire() 
    {
        print("TEST");
		GameObject gun = GameObject.Find("FPSController/FirstPersonCharacter/PM-40_Variant1/");
		RayCastShoot raycast = gun.GetComponent<RayCastShoot>();

		
		raycast.fireRate = 0.14f;
		raycast.currentAmmo = 30;
		raycast.maxAmmo = 30;
		raycast.SetAmmoText();

        GameObject textUI = GameObject.Find("HUD/PowerType/");
		Text powerType = textUI.GetComponent<Text>();
        powerType.text = "Rapid Fire!";

		//print("PowerupGiven");

        yield return new WaitForSeconds(30f);

		raycast.fireRate = 0.25f;
        if(raycast.currentAmmo > 15)
            raycast.currentAmmo = 15;

		raycast.maxAmmo = 15;
		raycast.SetAmmoText();
        powerType.text = "Powerup Removed";
        print("Powerup Removed");

        yield return new WaitForSeconds(5f);
        powerType.text = "";

        GameObject anotherPowerup = GameObject.Find("PowerupLocations/");
		DeployPowerup deploy = anotherPowerup.GetComponent<DeployPowerup>();
        
        yield return new WaitForSeconds(5f);
        deploy.ChooseSpawners(2);
        print("ANOTHER POWERUP SPAWNED");

		// Remove Powerup
		Destroy(gameObject);
		//print("GameObject removed");
    }

	IEnumerator IncreaseHealth() 
    {
        //print("TEST");
		GameObject player = GameObject.Find("FPSController/Player/");
		PlayerHealth increaseHp = player.GetComponent<PlayerHealth>();

		if(increaseHp.currentHealth <= 75)
			increaseHp.currentHealth = increaseHp.currentHealth+25;
        else
            increaseHp.currentHealth = 100;

		increaseHp.HealthBar.value = increaseHp.currentHealth;

        print("Health Increased");

        GameObject textUI = GameObject.Find("HUD/PowerType/");
		Text powerType = textUI.GetComponent<Text>();
        print(textUI);
        print(powerType);
        powerType.text = "Health Increased by 25!";

        yield return new WaitForSeconds(5f);
        powerType.text = "";

        GameObject anotherPowerup = GameObject.Find("PowerupLocations/");
		DeployPowerup deploy = anotherPowerup.GetComponent<DeployPowerup>();
        
        yield return new WaitForSeconds(5f);
        deploy.ChooseSpawners(1);
        print("ANOTHER POWERUP SPAWNED");

		// Remove Powerup
		Destroy(gameObject);
    }

    IEnumerator IncreaseGrenades() 
    {

        GameObject nade = GameObject.Find("FPSController/FirstPersonCharacter/BulletEmitter/");
		Bullets grenade = nade.GetComponent<Bullets>();

        GameObject miner = GameObject.Find("FPSController/FirstPersonCharacter/BulletEmitter/");
		DeployMine mine = miner.GetComponent<DeployMine>();

        grenade.currentGrenades = 3;
        mine.mineCount = 3;

        GameObject textUI = GameObject.Find("HUD/PowerType/");
		Text powerType = textUI.GetComponent<Text>();
        powerType.text = "Max Special Ammo";

        yield return new WaitForSeconds(5f);
        powerType.text = "";

        GameObject anotherPowerup = GameObject.Find("PowerupLocations/");
		DeployPowerup deploy = anotherPowerup.GetComponent<DeployPowerup>();
        
        yield return new WaitForSeconds(5f);
        deploy.ChooseSpawners(1);
        print("ANOTHER POWERUP SPAWNED");

		// Remove Powerup
		Destroy(gameObject);
    }
}