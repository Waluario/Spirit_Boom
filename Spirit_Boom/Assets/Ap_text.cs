using UnityEngine;
using System.Collections;

public class Ap_text : MonoBehaviour {
	
	public Fighter_Base m_xUser;
	
	UnityEngine.UI.Text m_xText;
	
	void Start () {
		m_xText = GetComponent<UnityEngine.UI.Text>();
	}
	
	void Update () {		
		m_xText.text = ("AP: " + m_xUser.m_iAp + (m_xUser.m_iAp == m_xUser.m_iMap ? " (MAX)" : ""));
	}
}