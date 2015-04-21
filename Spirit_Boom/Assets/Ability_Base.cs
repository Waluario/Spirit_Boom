using UnityEngine;
using System.Collections;

public class Ability_Effect : MonoBehaviour {
	public int
	m_iStatus,
	m_iStatusTime,
	m_iStatusChance;
}

public class Ability_Base : MonoBehaviour {
	
	public string m_xName;
	
	public int
	m_iPow,
	m_iHit,
	m_iCost;
	
	public Ability_Effect m_xEffect;
	
	public Ability_Base(){
		
	}
	
	public Ability_Base(string p_xName, int p_iPow, int p_iHit, int p_iCost){
		m_xName = p_xName;
		
		m_iPow = p_iPow;
		m_iHit = p_iHit;
		m_iCost = p_iCost;
	}
	
	public void Use(Fighter_Base p_xUser, Fighter_Base p_xTarget){
		int _iA = Random.Range(p_xUser.m_iAcc, p_xUser.m_iAcc * 2) + m_iHit + p_xUser.m_iHit;
		
		//print (_iA + " Vs. " + p_xTarget.m_iEvd);
		
		if (_iA < p_xTarget.m_iEvd){
			print ("The attack missed...");
			
			return;
		}
		
		p_xTarget.TakeDamage((DmgCalculation(p_xUser, p_xTarget)));
	}
	
	public int DmgCalculation(Fighter_Base p_xUser, Fighter_Base p_xTarget){
		if (p_xUser.m_iAtk + m_iPow < p_xTarget.m_iDef){		
			return 0;
		}
		
		return (p_xUser.m_iAtk + m_iPow - p_xTarget.m_iDef);
	}
}