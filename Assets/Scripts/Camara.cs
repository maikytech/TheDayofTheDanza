using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
	public Transform objetivoCamara;		//Referencia al Transform del objeto "ObjetivoCamara".

	void Update ()
	{
		//Con LookAt hacemos que la camara siempre mire al objeto cuyo transform colocamos en el parametro de la función.
		transform.LookAt (objetivoCamara);
	}
}
	