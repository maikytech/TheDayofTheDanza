using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
	public float intervaloON_OFF;		//Intervalo de tiempo entre encendido y apagado.
	
	private float contador;				
	private Light LightReference;		//Referencia al componente "Ligth".


	void Start ()
	{
		LightReference = gameObject.GetComponent<Light> ();
		contador = 0;
	}
	

	void Update ()
	{
		contador += Time.deltaTime;								//deltaTime es el tiempo transcurrido entre un frame y otro.
																//Contador va contando el tiempo de juego hasta que se cumple la condición.

		if (contador >= intervaloON_OFF)
		{
			LightReference.enabled = !LightReference.enabled;	//La luz direccional se activara y desactivara.
			contador = 0;							
		}
	}
}
