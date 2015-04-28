using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fighter_Base : MonoBehaviour {

	public string 
	m_xName;

	public int
	m_iAp,
	m_iApr,
	m_iMap,
	m_iHp,
	m_iMhp,
	m_iAtk,
	m_iDef,
	m_iFdf,
	m_iWdf,
	m_iEdf,
	m_iAcc,
	m_iEvd,
	m_iHit,
	m_iStatus,
	m_iStatusTime;
	
	public e_Element m_eEl;
	
	public bool m_bGuard;
	
	public Fighter_Base m_xTarget;
	
	public Fighter_Mngr m_xFMngr;
	
	void Update(){
		if (m_iHp <= 0){
			m_iHp = 0;
			m_iStatus = 1;
		}
	}
	
	public void UseAbility(Ability_Base p_xAbility){
		if (m_iAp < p_xAbility.m_iCost){
			print ("Not enough AP!");
			return;
		}
		
		print(m_xName + " used " + p_xAbility.m_xName);
		p_xAbility.Use(this, m_xTarget);
		m_iAp -= p_xAbility.m_iCost;
	}
	
	public void TakeDamage(int p_iDmg){
		print (m_xName + " took " + p_iDmg + " damage!");
		
		if (p_iDmg > m_iHp){
			m_iHp = 0;
			m_iStatus = 1;
		}
		else {
			m_iHp -= p_iDmg;
		}
	}
	
	public int GetPow(e_Element p_e, int p_iPow){
		if (m_eEl == p_e){
			return (m_iAtk + p_iPow) * 2;
		}
		
		return (m_iAtk + p_iPow);
	}
	
	public int GetDef(e_Element p_eE){
		int _iDef = m_iDef;
		
		switch(p_eE){
		case e_Element.Fire:
			_iDef += m_iFdf;
			break;
		case e_Element.Water:
			_iDef += m_iWdf;
			break;
		case e_Element.Earth:
			_iDef += m_iEdf;
			break;
		}
		
		return (_iDef + (m_bGuard ? m_iHit : 0));
	}
	
	public void StatusEffect(){
		if (m_iStatusTime <= 0){
			m_iStatus = 0;
		}
	}
	
	/*public void AddAbility(Ability_Base p_xAbility){
		m_xaAbilities.Add(p_xAbility);
	}*/
	
	public void ApUp(){
		if (m_iAp + m_iApr > m_iMap){
			m_iAp = m_iMap;
			
			return;
		}
		
		m_iAp += m_iApr;
	}
	
	
	
	public void On_Turn_Start(){
		//m_iHit *= m_bGuard ? 0 : 1;
		m_iHit = 0;
	}
	
	public void Set_Guard(bool p_b){
		if (p_b && m_iAp > 0){
			m_bGuard = true;
			print (m_xName + " is now guarding...");
		}
	}
}