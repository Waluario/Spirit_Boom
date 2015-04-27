using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;
using UnityEngine.Rendering;

public class houseFade : MonoBehaviour {
	
	public Collider2D playerCollider;
	public Collider2D buildingTrigger;
	public SpriteRenderer buildingSprite;
	public Sprite normalSprite;
	public Sprite fadeSprite;
	
	
	void Update () {
		
		if (buildingTrigger.IsTouching (playerCollider)) {

			buildingSprite.sortingLayerName = "FG";
			buildingSprite.sprite = fadeSprite;
		} 
		else {

			buildingSprite.sortingLayerName = "Default";
			buildingSprite.sprite = normalSprite;
		}
	}
}