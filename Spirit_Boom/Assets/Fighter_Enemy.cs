using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fighter_Enemy : Fighter_Base {
	
	public List<int> m_iaAbilities;
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	
	public int Act(){
		if (Can_Fight()){
			int _i = Random.Range(0, m_iaAbilities.Count + 1);
			if (_i >= m_iaAbilities.Count){
				return 0;
			}
			
			return m_iaAbilities[_i];
		}
		
		return -1;
	}
	
	public bool Can_Fight(){
		for (int i = 0; i < m_xFMngr.m_xAbilityMngr.m_xaAbilityList[m_iaAbilities.Count].m_iCost; i++){
			if (m_xFMngr.m_xAbilityMngr.m_xaAbilityList[i].m_iCost <= m_iAp){
				return true;
			}
		}
		
		return false;
	}
}