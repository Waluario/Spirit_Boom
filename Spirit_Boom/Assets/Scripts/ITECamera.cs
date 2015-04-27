using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ITECamera : MonoBehaviour 
{
	float ScrollSpeed = 3f;
	float ScrollEdge = 0.01f;

	float PanSpeed = 10f;

	float CurrentZoom = 0f;
	float ZoomZpeed = 1f;
	
	void Start()
	{
		CurrentZoom = Camera.main.orthographicSize;
	}
	
	void Update ()
	{
		if (Application.isPlaying)
		{
			//PAN
			if ( Input.GetKey(KeyCode.Mouse1) )
			{
				transform.Translate(Vector3.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5f)/(Screen.width * 0.5f), Space.World);
				transform.Translate(Vector3.up * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5f)/(Screen.height * 0.5f), Space.World);
				
			}
			else
			{
				if ( Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge) )
				{
					if (!(Input.mousePosition.x > Screen.width))
						transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
				}
				else if ( Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge )
				{
					if (!(Input.mousePosition.x < 0.0f))
						transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
				}
				
				if ( Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge) )
				{
					if (!(Input.mousePosition.y > Screen.height))
						transform.Translate(Vector3.up * Time.deltaTime * ScrollSpeed, Space.World);
				}
				else if ( Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge )
				{
					if (!(Input.mousePosition.y < 0.0f))
						transform.Translate(Vector3.up * Time.deltaTime * -ScrollSpeed, Space.World);
				}
			}
				
			CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomZpeed * 100f;

			Camera.main.orthographicSize = CurrentZoom;
			Camera.main.fieldOfView = CurrentZoom;
		}
	}
}
