using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

	public GameObject pm;
	public bool activated = false;

	public void resumeGame(){

		activated = false;
	}

	void Start () {
	
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			if (activated == false){
				activated = true;
			}
			else {
				activated = false;
			}
		}
		if (activated == true) {
			pm.SetActive (true);
		}
		else {
			pm.SetActive (false);
		}
	}
}
