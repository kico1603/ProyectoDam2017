//GameCharacterSounds.cs - Samuel López Hernández
//Clase que controla la ejecucion de los sonidos
//de cada personaje del juego.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class GameCharacterSounds : MonoBehaviour {

	private AudioSource audio;
	public AudioClip [] stepClips;
	public AudioClip [] shieldHittedClips;
	public AudioClip [] hitClips;


	void Start () {
		audio = GetComponent <AudioSource> ();
	}
	
	public void stepSound()
	{
		if (audio) {
			audio.volume = 0.2f;
			audio.clip = chooseSound (stepClips);
			audio.Play ();
		}
	}

	public void shieldHittedSound()
	{
		if (audio) {
			audio.volume = 1f;
			audio.clip = chooseSound(shieldHittedClips);
			audio.Play();
		}
	}

	public void hitSound ()
	{
		if (audio) {
			audio.volume = 0.5f;
			audio.clip = chooseSound (hitClips);
			audio.Play ();
		}
	}

	//Devuelve un sonido aleatorio dentro 
	//de un Array de Audioclips.
	private AudioClip chooseSound (AudioClip [] clips) 
	{
		if (clips.Length == 0)
			return null;
		else if (clips.Length == 1)
			return clips [0];
		else
			return clips [Random.Range (0, clips.Length)];
	}
}
