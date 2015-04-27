using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ability_Mngr : MonoBehaviour {
	
	public List<Ability_Base> m_xaAbilityList;
	
	public List<Ability_Player> m_xaPlayerAbilites;
	
	public Ability_Base Get_Ability(int p_i){
		return m_xaAbilityList[p_i];
	}
}