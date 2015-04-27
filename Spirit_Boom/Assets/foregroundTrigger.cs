using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;
using UnityEngine.Rendering;

public class foregroundTrigger : MonoBehaviour {
	
	public Collider2D playerCollider;
	public Collider2D buildingTrigger;
	public SpriteRenderer buildingSprite;


	void Update () {
	
		if (buildingTrigger.IsTouching (playerCollider)) {

			buildingSprite.sortingLayerName = "Default";
		} 
		else {

			buildingSprite.sortingLayerName = "FG";
		}
	}
}
