using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;		//Libreria para el manejo de escenas.

public class MainMenu : MonoBehaviour
{
	void Update ()
	{
		if (Input.anyKey)
		{
			//SceneManager.LoadScene ("Main");		//Se carga la escena principal.
		}
	}

	public void GoToNextScene()
	{
		SceneManager.LoadScene ("Main");		//Se carga la escena principal.
	}
}
