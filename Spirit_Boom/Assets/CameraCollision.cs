using UnityEngine;
using System.Collections;
#pragma strict



public class CameraCollision : MonoBehaviour {

	public Transform Player;

	public Vector2 margin, smoothing;

	public Camera mainCamera;
	public Collider2D cameraCollider;

	private Vector3 min, max;


	void Start () {

		min = cameraCollider.bounds.min;
		max = cameraCollider.bounds.max;
	}


	void Update(){

		var x = transform.position.x;
		var y = transform.position.y;

		if (Mathf.Abs (x - Player.position.x) > margin.x) {
			x = Mathf.Lerp(x, Player.position.x, smoothing.x * Time.deltaTime);
		}
		if (Mathf.Abs (y - Player.position.y) > margin.y) {
			y = Mathf.Lerp(y, Player.position.y, smoothing.y * Time.deltaTime);
		}

		var cameraHalfWidth = mainCamera.orthographicSize * ((float)Screen.width / Screen.height);

		x = Mathf.Clamp (x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, min.y + mainCamera.orthographicSize, max.y - mainCamera.orthographicSize);

		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
