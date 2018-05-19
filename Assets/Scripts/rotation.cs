using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//En un segundo girará 90º.	
		transform.rotation *= Quaternion.Euler(0, 90.0f * Time.deltaTime, 0) ;

	}
}
