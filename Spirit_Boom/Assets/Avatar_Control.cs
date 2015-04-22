using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avatar_Control : MonoBehaviour {

	public float 
	m_fSpeed;
	
	public Rigidbody2D m_xBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.anyKey){
			
			m_xBody.velocity = new Vector2(((Input.GetKey("d") ? 1 : 0) - (Input.GetKey("a") ? 1 : 0)), ((Input.GetKey("w") ? 1 : 0) - (Input.GetKey("s") ? 1 : 0)));
			/*(new Vector2(
				this.transform.position.x + ((Input.GetKey("d") ? 1 : 0) - (Input.GetKey("a") ? 1 : 0)) * m_fSpeed * Time.deltaTime, 
				this.transform.position.y + ((Input.GetKey("w") ? 1 : 0) - (Input.GetKey("s") ? 1 : 0)) * m_fSpeed * Time.deltaTime));*/
			
			/*this.transform.position = new Vector3(
				this.transform.position.x + ((Input.GetKey("d") ? 1 : 0) - (Input.GetKey("a") ? 1 : 0)) * m_fSpeed * Time.deltaTime, 
				this.transform.position.y + ((Input.GetKey("w") ? 1 : 0) - (Input.GetKey("s") ? 1 : 0)) * m_fSpeed * Time.deltaTime);*/
		//}
	}
}