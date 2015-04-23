using UnityEngine;
using System.Collections;

public class Scene_Mngr : MonoBehaviour {

	public enum e_Scenes {
		Main_Menu,
		Battle,
		World,
		Game_Over
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
		case e_Scenes.Game_Over:
			Application.LoadLevel("Game_Over");
			break;
		default:
			break;
		}
	}
	
	void Update(){
		//GotoScene(e_Scenes.Battle);
	}
}