using UnityEngine;
using System.Collections;

public class showDesc : MonoBehaviour {

	public GameObject button;
	public bool mouseOver = false;

	void start(){

		button.SetActive (false);
	}

	public void showDescription(){
		
		mouseOver = true;
		button.SetActive (true);
	}
	
	public void hideDescription(){
		
		mouseOver = false;
		button.SetActive (false);
	}
}