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
	m_iFDf,
	m_iWDf,
	m_iEDf,
	m_iAcc,
	m_iEvd,
	m_iHit,
	m_iStatus,
	m_iStatusTime;
	
	public bool m_bGuard;
	
	public Fighter_Base m_xTarget;
	
	public List<Ability_Base> m_xaAbilities;
	
	public Fighter_Mngr m_xFMngr;
	
	void Update(){
		if (m_iHp <= 0){
			m_iHp = 0;
			m_iStatus = 1;
		}
	}
	
	public void UseAbility(int p_iN){
		if (p_iN < m_xaAbilities.Count && p_iN >= 0 && m_xaAbilities.Count > 0){
			if (m_iAp < m_xaAbilities[p_iN].m_iCost){
				print ("Not enough AP!");
				return;
			}
			
			print(m_xName + " used " + m_xaAbilities[p_iN].m_xName);
			
			m_xaAbilities[p_iN].Use(this, m_xTarget);
			m_iAp -= m_xaAbilities[p_iN].m_iCost;
		}
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
	
	public int GetDef(e_Element p_eE){
		int _iDef = m_iDef;
		
		switch(p_eE){
		case e_Element.Fire:
			_iDef += m_iFDf;
			break;
		case e_Element.Water:
			_iDef += m_iWDf;
			break;
		case e_Element.Earth:
			_iDef += m_iEDf;
			break;
		}
		
		return (_iDef + (m_bGuard ? m_iHit : 0));
	}
	
	public void StatusEffect(){
		if (m_iStatusTime <= 0){
			m_iStatus = 0;
		}
	}
	
	public void AddAbility(Ability_Base p_xAbility){
		m_xaAbilities.Add(p_xAbility);
	}
	
	public void ApUp(){
		if (m_iAp + m_iApr > m_iMap){
			m_iAp = m_iMap;
			
			return;
		}
		
		m_iAp += m_iApr;
	}
	
	public bool Can_Fight(){
		for (int i = 0; i < m_xaAbilities.Count; i++){
			if (m_xaAbilities[i].m_iCost <= m_iAp){
				return true;
			}
		}
		
		return false;
	}
	
	public void On_Turn_Start(){
		m_iHit *= m_bGuard ? 0 : 1;
	}
	
	public void Set_Guard(bool p_b){
		if (p_b && m_iAp > 0){
			m_bGuard = true;
			print (m_xName + " is now guarding...");
		}
	}
}