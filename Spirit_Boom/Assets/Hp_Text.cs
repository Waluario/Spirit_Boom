using UnityEngine;
using System.Collections;

public class Hp_Text : MonoBehaviour {
	
	int m_iValue,
	m_iSpeed;
	
	public int m_iMaxSpeed;
	
	public Fighter_Base m_xUser;
	
	UnityEngine.UI.Text m_xText;

	void Start () {
		m_xText = GetComponent<UnityEngine.UI.Text>();
		
		m_iValue = m_xUser.m_iHp;
	}
	
	void FixedUpdate () {
		m_iSpeed -= 1;
		if (m_iSpeed <= 0){
			if (m_iValue > m_xUser.m_iHp){
				m_iValue -= 1;
			}
			else if (m_iValue < m_xUser.m_iHp){
				m_iValue += 1;
			}
			
			m_iSpeed = m_iMaxSpeed;
		}
		
		m_xText.text = ("HP: " + m_iValue + " / " + m_xUser.m_iMhp);
	}
}