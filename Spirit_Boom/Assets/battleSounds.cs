using UnityEngine;
using System.Collections;

public class battleSounds : MonoBehaviour {
	
	public AudioSource soundFx;
	public AudioSource musicFx;
	public AudioClip music1;
	public AudioClip sound1;
	
	public void playMusic(){
		musicFx.clip = music1;
		musicFx.Play ();
	}
	public void playClip1(){
		soundFx.clip = sound1;
		soundFx.Play ();
	}
}
