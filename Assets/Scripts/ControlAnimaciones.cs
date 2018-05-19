using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimaciones : MonoBehaviour
{
	public AudioSource audioSourceReference;		//Referencia al componente AudioSource.
	public AudioClip audioClipReference;			//Referencia al clip que sonará en el componente AudioSource.	

	private Animator animatorReference;			//Referencia al componente Animator.
	private Vector2 positionTouch;				//Vector posición donde se produce un toque a la pantalla.


	void Start ()
	{
		animatorReference = GetComponent<Animator> ();		//Se referencia el componente Animator.
	}

	void ToquesTeclado()
	{

		Debug.Log ("Llamado de la función ToquesTeclado");

		//Si se presiona la tecla 1, 2, 3, 4, 5 de la barra superior del teclado en cualquier frame ....
		//GetKeyDown returna true solo durante el frame que el usuario presiona la tecla especificada en el parametro, esta función se debe llamar durante el Update().
		//KeyCode es la enumeración que contiene los codigos del teclado o los KeyCode de los eventos en Unity( o sea, lo que hacen las teclas al ser presionadas).
		//KeyCode.Alpha1 es la tecla '1' en la barra superior del teclado.
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			//SetInteger setea un valor entero a una variable determinada dentro del componente Animator.
			animatorReference.SetInteger ("Direccion", 1);

			//PlayOneShot play un audioclip, tiene como parametros el clip a reproducir y el volumen del componente Audiosource.
			audioSourceReference.PlayOneShot (audioClipReference);
		}	

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			animatorReference.SetInteger ("Direccion", 2);
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			animatorReference.SetInteger ("Direccion", 3);
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			animatorReference.SetInteger ("Direccion", 4);
		}
	}

	void ToquesSmartphones()
	{
		/*** Touch ***/

		//Si se toca la pantalla...	
		//La funcion estatica touchCount retorna la cantidad de toques a la pantalla.
		if (Input.touchCount > 0)
		{

			//La función estatica touches retorna una array con objetos que representan los status de los toques de pantalla del ultimo frame (read only).
			//phase describe la fase del toque de pantalla.
			/* TouchPhase es una enumeración que contiene las diferentes fases de un toque de pantalla, las cuales son:
			 * 
			 * Began: Cuando el dedo toca la pantalla.
			 * Moved: Cuando el dedo se mueve sobre la pantalla.
			 * Stationary: Cuando el dedo toca la pantalla pero se queda estatico, no se mueve.
			 * Ended: Cuando se levanta el dedo de la pantalla.
			 * Canceled: El sistema cancelo el toque.
			 * 
			 */

			//Si en el primer toque el dedo toca la pantalla...
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				positionTouch = Input.touches [0].position;		//Posición donde se produjo el toque.

			} else{

					//Si se levanta el dedo de la pantalla.
					if (Input.touches [0].phase == TouchPhase.Ended)
					{
						//Vector diferencia para determinar el movimiento del dedo en el toque.
						Vector2 vectorDiferencia = Input.touches [0].position - positionTouch;

						//Si el movimiento en la coordenada x es mayor que el movimiento en la coordenada y. ¿?¿?
						if (Mathf.Abs (vectorDiferencia.x) > Mathf.Abs (vectorDiferencia.y))
						{
							//Si la componente x del vector diferencia es menor que cero, el movimiento fue hacia la izquierda.
							if (vectorDiferencia.x < 0)		
							{
								//Configuración del comportamiento si el movimiento fue hacia la izquierda.

							} else {

								//Configuracion del comportamiento si el movimiento fue hacia la derecha.
							}

							//Si la componente y del vector diferencia es menor que cero, el movimiento fue hacia abajo.
							if (vectorDiferencia.y < 0)		
							{
								//Configuración del comportamiento si el movimiento fue hacia abajo.

							} else {

								//Configuracion del comportamiento si el movimiento fue hacia arriba.
							}
						}
					}
				}
			}
	}

	void Update ()
	{
		Debug.Log("Entro en el Update");

		ToquesTeclado ();
	}
}
