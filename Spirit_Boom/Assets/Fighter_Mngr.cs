using UnityEngine;
using System.Collections;

public class Fighter_Mngr : MonoBehaviour {

	public Fighter_Base
	m_xFighter0,
	m_xFighter1;
	
	bool
	m_bTurn;

	// Use this for initialization
	void Start () {
		m_xFighter0.AddAbility(new Ability_Base("Strike", 20, 75, 0));
		m_xFighter1.AddAbility(new Ability_Base("Tackle", 20, 75, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (m_bTurn){
			m_xFighter0.UseAbility(0, m_xFighter1);
			m_bTurn = false;
		}
		else if (!m_bTurn){
			m_xFighter1.UseAbility(0, m_xFighter0);
			m_bTurn = true;
		}
	}
}