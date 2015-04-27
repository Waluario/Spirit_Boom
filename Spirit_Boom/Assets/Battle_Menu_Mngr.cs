using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle_Menu_Mngr : MonoBehaviour {

	public List<Battle_Menu_Item> m_xaAbilities;
	
	public Battle_Menu_Item[] m_xaAb;
	
	public Battle_Menu_Item m_xEndTurn;

	// Use this for initialization
	void Start () {
		m_xaAb = this.GetComponentsInChildren<Battle_Menu_Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}