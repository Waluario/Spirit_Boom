using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fighter_Base : MonoBehaviour {

	public string 
	m_xName;

	public int
	m_iAp,
	m_iHp,
	m_iMHp,
	m_iAtk,
	m_iDef,
	m_iAcc,
	m_iEvd,
	m_iHit,
	m_iStatus,
	m_iStatusTime;
	
	public List<Ability_Base> m_xaAbilities/* = new List<Ability_Base>()*/;
	
	void Update(){
		if (m_iHp <= 0){
			m_iHp = 0;
			m_iStatus = 1;
		}
	}
	
	public void UseAbility(int p_iN, Fighter_Base p_xTarget){
		if (p_iN < m_xaAbilities.Count && p_iN >= 0 && m_xaAbilities.Count > 0){
			print(m_xName + " used " + m_xaAbilities[p_iN].m_xName);
			m_xaAbilities[p_iN].Use(this, p_xTarget);
		}
	}
	
	public void TakeDamage(int p_iDmg){
		print (m_xName + " took " + p_iDmg + " damage!");
	
		if (p_iDmg > m_iHp){
			m_iHp = 0;
			m_iStatus = 1;
		}
	}
	
	public void StatusEffect(){
		if (m_iStatusTime <= 0){
			m_iStatus = 0;
		}
	}
	
	public void AddAbility(Ability_Base p_xAbility){
		m_xaAbilities.Add(p_xAbility);
	}
}