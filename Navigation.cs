using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour 
{

	public void PlayTest1()
	{
		SceneManager.LoadScene(1);
	}
	public void PlayTest2()
	{
		SceneManager.LoadScene(2);
	}
	public void Quit()
	{
		Application.Quit();
	}

}
