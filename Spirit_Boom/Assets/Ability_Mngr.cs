using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability_Mngr : MonoBehaviour {
	
	public List<Ability_Base> m_xaAbilityList;
	
	public List<UnityEngine.UI.Text> 
	m_xaAbilityNames,
	m_xaAbilityDescs;
	
	public Ability_Base Get_Ability(int p_i){
		return m_xaAbilityList[p_i];
	}
}