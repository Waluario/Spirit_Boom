using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class panelOpacity : MonoBehaviour {

public Image canvas;

	void Start () {
		canvas = GetComponent<Image> ();
		canvas.color = Color.white;
	}

}
