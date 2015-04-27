using UnityEngine;
using System.Collections;

public class flipSprite : MonoBehaviour {


//	private Vector2 avatarVector;
	public ScaleMode flip;

	void Update () {

		if (Input.GetKey ("a")) {

//			avatarVector.Scale = -1;
		}
		if (Input.GetKey ("d")) {

//			avatarVector.Scale = 1;
		}

//		flip.localScale = avatarVector;
	}
}
