using UnityEngine;
using System.Collections;

public class mainMenuSounds : MonoBehaviour {

	public AudioSource soundFx;
	public AudioSource musicFx;
	public AudioClip selectClip;

	public void playSelect(){
		soundFx.clip = selectClip;
		soundFx.Play ();
	}
}
