//TorchFlickering.cs -- Samuel López Hernández
//Hace que una luz parpadee variando la intensidad
//-aleatoriamente entre un valor minimo y uno maximo
//a cada frame del juego.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlickering : MonoBehaviour {

	private Light light;
	[Range (0,8)]
	public float minIntensity;
	[Range (0,8)]
	public float maxIntensity;

	void Awake () {
		light = GetComponent <Light> ();
	}
	
	void Update () {
		light.intensity = Random.Range (minIntensity, maxIntensity);
	}
}
