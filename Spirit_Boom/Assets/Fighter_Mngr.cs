using UnityEngine;
using System.Collections;

public class Fighter_Mngr : MonoBehaviour {

	public Fighter_Base
	m_xFighter0,
	m_xFighter1;
	
	public Turn_Mngr
	m_xTurnMngr;
	
	public int 
	m_iMenuChoice;
	
	bool
	m_bTurn;

	// Use this for initialization
	void Start () {
		m_xFighter0.AddAbility(new Ability_Base("Strike", 25, 75, 0, e_Element.Earth));
		m_xFighter0.AddAbility(new Ability_Base("Pound", 50, 50, 0, e_Element.Earth));
		m_xFighter0.AddAbility(new Ability_Base("Smash", 75, 25, 0, e_Element.Earth));
		m_xFighter1.AddAbility(new Ability_Base("Tackle", 20, 75, 0, e_Element.Earth));
		m_xFighter1.AddAbility(new Ability_Base("Slap", 0, 100, 0, e_Element.Earth));
	}
	
	// Update is called once per frame
	void Update () {
		if (m_bTurn){
			//m_xFighter0.UseAbility(m_iMenuChoice, m_xFighter1);
			//m_bTurn = !Menu_Action(m_xFighter0, m_xFighter1);
		}
		else if (!m_bTurn){
			//m_xFighter1.UseAbility(Random.Range(0, m_xFighter1.m_xaAbilities.Count - 1), m_xFighter0);
			m_bTurn = true;
		}
	}
	
	public bool Menu_Action (Fighter_Base p_xUser, Fighter_Base p_xTarget){
		bool _b = false;
		
		if (Input.GetKeyDown("w")){
			m_iMenuChoice++;
			_b = true;
		}
		else if (Input.GetKeyDown("s")){
			m_iMenuChoice--;
			_b = true;
		}
		
		if (m_iMenuChoice >= p_xUser.m_xaAbilities.Count){
			m_iMenuChoice = 0;
		}
		
		if (m_iMenuChoice < 0){
			m_iMenuChoice = p_xUser.m_xaAbilities.Count - 1;
		}
		
		if (_b){
			print (m_iMenuChoice + " : " + p_xUser.m_xaAbilities[m_iMenuChoice].m_xName);
		}
		
		if (Input.GetKeyDown("d")){
			//p_xUser.UseAbility(m_iMenuChoice, p_xTarget);
			
			return true;
		}
		
		return false;
	}
}