using UnityEngine;
using System.Collections;

public class Scene_Mngr : MonoBehaviour {

	public enum e_Scenes {
		Main_Menu,
		Battle,
		World
	};
	
	public void GotoScene(e_Scenes p_eScene){
		switch (p_eScene){
		
		case e_Scenes.Battle:
			Application.LoadLevel("Battle");
			break;
			
		case e_Scenes.Main_Menu:
			Application.LoadLevel("Main_Menu");
			break;
			
		case e_Scenes.World:
			Application.LoadLevel("World");
			break;
			
		default:
			break;
		}
	}
	
	void Update(){
		GotoScene(e_Scenes.Battle);
	}
}