using UnityEngine;
using System.Collections;

public class hidden : MonoBehaviour {

	public GameObject canvas;

	public bool optionsOn = false;

	public void turnOnOptions(){
		
		if (optionsOn == false) {

			optionsOn = true;
			canvas.SetActive(false);		} 
		else {

			optionsOn = false;
			canvas.SetActive(true);
		}
	}

}