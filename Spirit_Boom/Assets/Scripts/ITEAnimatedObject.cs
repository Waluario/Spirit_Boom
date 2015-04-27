using UnityEngine;
using System.Collections;

using ITE;

public class ITEAnimatedObject : MonoBehaviour
{
	public Sprite[] Frames;
	public float animationSpeed = 1f;
	int activeFrame = 0;

	ITEScriptableObject scriptableObject;

	// Use this for initialization
	void Start () 
	{
		scriptableObject = GetComponent<ITEScriptableObject>();
		StartCoroutine(Animate());
	}
	
	IEnumerator Animate()
	{
		while(true)
		{
			scriptableObject.SetSprite(Frames[activeFrame]);

			activeFrame++;
			if(activeFrame > Frames.Length - 1)
				activeFrame = 0;

			yield return new WaitForSeconds(1.0f / animationSpeed);
		}
	}
}
