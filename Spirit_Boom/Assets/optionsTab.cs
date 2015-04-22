using UnityEngine;
using System.Collections;

public class optionsTab : MonoBehaviour {

	public GameObject optionsCanvas;
	public GameObject mainCanvas;
	
	public bool optionsOn = false;
	
	public void turnOnOptions(){
		
		if (optionsOn == false) {
			
			optionsOn = true;
			optionsCanvas.SetActive(true);	
			mainCanvas.SetActive(false);
		} 
		else {
			
			optionsOn = false;
			optionsCanvas.SetActive(false);
			mainCanvas.SetActive(true);
		}
	}

}
