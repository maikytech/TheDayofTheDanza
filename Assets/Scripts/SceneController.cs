using System.Collections;
using System.Collections.Generic;					//Libreria para el manejo de listas en C#.
using UnityEngine;
using UnityEngine.UI;								//Libreria para el manejo de elementos de UI.

public class SceneController : MonoBehaviour
{
	//public GameObject girlPrefabReference;		//Referencia publica al prefab de la chica.
	public GameObject[] vidas;						//Array contiene las referencias a las vidas del jugador.
	public GameObject wrong;						//Referencia al simbolo de error.
	public GameObject letsDanza;					//Referencia al aviso de Lets Danza.
	public GameObject flecha;
	public GameObject inGame;						//Referencia a los elementos de UX del ingame del juego.
	public GameObject gameOver;						//Referencia al elemento GameOver UX.
	public Text puntuacion;

	//private GameObject girlOnSceneReference;		//Referencia privada a la chica en escena.
	private int numeroVidas;								
	private int misPuntos;

	public enum TipoPaso		//Enumeración con los tipos de paso, los cuales son los pasos de baile que interpretara el Player.
	{
		None, Right, Left, Up, Down
	};

	//Array de Quaternios estatica, el cual contendra las rotaciones de la fecha al ejecutar los pasos de baile.
	static Quaternion[] PasoBase = new Quaternion[]
	{
		//Quaternion.Euler retorna la rotacion en grados de cada uno de los ejes.
		//Las rotaciones deben coincidir con los valores de la enumeración tipo paso.
		Quaternion.Euler(0, 0, 0f),
		Quaternion.Euler(0, 0, 90f),
		Quaternion.Euler(0, 0, 180f),
		Quaternion.Euler(0, 0, 270f),
		Quaternion.Euler(0, 0, 0f)
	};

    //La clase List<T> representa una lista de objetos fuertemente tipados los cuales se pueden acceder a traves de index.
	List<TipoPaso> pasos = new List<TipoPaso>();		


    //List<T>.Enumerator es una estructura que nos ayuda a movernos a traves de una lista.
    //Se crea un objeto de tipo List<T>.Enumerator
	List<TipoPaso>.Enumerator  pasoActual;				


	void Start ()
	{
		//girlOnSceneReference = Instantiate (girlPrefabReference);

		ReiniciarJuego ();

		//Se adicionan tres pasos al inicio del juego.
		AddNewStep ();
		AddNewStep ();
		AddNewStep ();

	}

	void ReiniciarJuego()			//Coloca las condiciones iniciales al inicio del juego.
	{
		numeroVidas = 3;
		misPuntos = 0;
		ActualizarVidas ();
		SumaPuntuacion (0);
        pasos.Clear ();	            //El metodo publico Clear() de la clase List<T> remueve todos los elementos de la lista.			
		ReiniciarPaso();
	}

	void ReiniciarPaso()				//Funcion que configura cuando el jugador se equivoca en un paso, se reinician los pasos.
	{
		wrong.SetActive (false);			//Se desactiva el simbolo de error.
		flecha.SetActive (false);			//Se desactiva la flecha.
	}


	/* Cuando la funcion "ActualizarVidas" es llamada, en el primer ciclo for se activan las vidas del juego de acuerdo a la variable "numeroVidas", en el segundo ciclo for, se desactivan
	 * las vidas de acuerdo a la misma variable, los dos ciclos for se evaluan en cada llamado de la funcion, activando o desactivando el numero de vidas de acuerdo a la 
	 * variable de control "numeroVidas". */ 
	void ActualizarVidas()
	{
		int i = 0;

		for (i = 0; i < numeroVidas; i++)		
		{
			vidas [i].SetActive (true);				//Se activan cada una de las vidas.
		}

		for (; i < 3; i++)
		{
			vidas [i].SetActive (false);
		}
	}

	void IniciaPasos()
	{
		//GetEnumerator retorna un objeto tipo List<T>.Enumerator, para moverse a traves de la lista.
		pasoActual = pasos.GetEnumerator ();		

	}

	public void SumaPuntuacion(int puntos)
	{
		misPuntos += puntos;							//Los puntos que recibe la función se suman a mis puntos.
		puntuacion.text = misPuntos.ToString("D6");		//Convierte el valor de mis puntos en una cadena con seis digitos.
	}

	public void AddNewStep()
	{
        //A la lista se incluye un nuevo elemento TipoPaso(casting), aleatorio entre 1 y 4, al inicio del juego la lista tendrá tres pasos.
		pasos.Add ((TipoPaso)Random.Range (1, 5));		
	}

	public bool MuestreElSiguientePaso(Animator animator)	//Muestra el siguiente paso, si ya se acabaron los pasos, se retorna false.
	{
		//MoveNext desplaza el enumerador al siguiente elemento de la colleccion, retorna true en caso de que sea posible realizar la accion.
		if (pasoActual.MoveNext())
		{
			flecha.SetActive (true);					//Se activa la flecha.
			int paso = (int)pasoActual.Current;			//Se captura el paso actual, casteandolo a entero.
														//Current retorna un objeto, en este caso, el paso actual del enumerador.

			//Esta linea de codigo hace que se realice la animación especificada por la variable "Dirección".
			/* SetInteger es un metodo publico de la clase Animator, el cual asigna un valor a una variable que determina una transicion, en este caso, le estamos diciendo que numero 
			 * de paso queremos que ejecute. */
			animator.SetInteger("Direccion", paso);

			flecha.transform.rotation = PasoBase[paso];	//Se asigna a la flecha la rotación correspondiente al tipo de paso.

            //Falta incluir configuracion de sonido.

			return true;
		}

		return false;
	}
}
