using UnityEngine;
using System.Collections;

public class Ability_Effect : MonoBehaviour {
	public int
	m_iStatus,
	m_iStatusTime,
	m_iStatusChance;
}

public enum e_Element{
	Fire,
	Water,
	Earth,
	Neutral
};

public class Ability_Base : MonoBehaviour {
	public string m_xName;
	
	public int
	m_iPow,
	m_iHit,
	m_iCost;
	
	public e_Element m_eE;
	
	public Ability_Effect m_xEffect;
	
	public Ability_Base(){
		
	}
	
	public Ability_Base(string p_xName, int p_iPow, int p_iHit, int p_iCost, e_Element p_eE){
		m_xName = p_xName;
		
		m_iPow = p_iPow;
		m_iHit = p_iHit;
		m_iCost = p_iCost;
		
		m_eE = p_eE;
	}
	
	public void Use(Fighter_Base p_xUser, Fighter_Base p_xTarget){
		int _iA = Random.Range(0, 100) + m_iHit + p_xUser.m_iAcc + p_xUser.m_iHit;
		
		if (_iA < p_xTarget.m_iEvd){
			print ("The attack missed...");
			p_xUser.m_iHit = 0;
			
			return;
		}
		
		p_xUser.m_iHit += 5;
		p_xTarget.TakeDamage((DmgCalculation(p_xUser.m_iAtk, p_xTarget.GetDef(m_eE))));
	}
	
	public int DmgCalculation(int p_iAtk, int p_iDef){
		if (p_iAtk + m_iPow < p_iDef){
			return 0;
		}
		
		return (p_iAtk + m_iPow - p_iDef);
	}
}