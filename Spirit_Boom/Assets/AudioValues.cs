using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioValues : MonoBehaviour {

	public AudioMixer mainMixer;

	public void setMusicVol(float musicLvl){
			mainMixer.SetFloat ("musicVol", musicLvl);

	}
	public void setSoundVol(float soundLvl){
		mainMixer.SetFloat ("soundVol", soundLvl);
	}
	





}
