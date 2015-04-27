using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ITE;

public class ITEActor : MonoBehaviour 
{
	public Vector3 Forward;
	
	public float Speed = 1f;
	List<ITEPathTile> path = new List<ITEPathTile>();

	void Update()
	{	
		Move();
	}
	
	void Move()
	{
		if (IsMoving())
		{
			ITEScriptableObject obj = transform.GetComponent<ITEScriptableObject>();

			Vector3 p = obj.Position;
			Vector3 t = new Vector3(this.path[0].Position.x, this.path[0].Position.y);
			this.Forward = (p - t).normalized;
			obj.MovePosition(-this.Forward * Time.deltaTime * this.Speed);
			transform.position = obj.Position;

			if (Vector3.Distance(t,  new Vector3(transform.position.x, transform.position.y)) <= 0.01f)
			{
				this.path.RemoveAt(0);
			}


		}
	}
	
	public bool IsMoving()
	{
		return (this.path != null && this.path.Count > 0);
	}

	public IEnumerator RandomDirection()
	{
		while(true)
		{
			if (this.path == null || this.path.Count == 0)
			{
				int count = ITEPathComputer.NavigationTiles.Count;
				if (count != 0)
				{
					ITEScriptableObject obj = transform.GetComponent<ITEScriptableObject>();
					ITEInstance target = ITEPathComputer.NavigationTiles.ToList()[UnityEngine.Random.Range(0, count - 1)];
					this.path = ITEPathComputer.Calculate(new Vector2(obj.Position.x, obj.Position.y), target.Position);
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void FindPath(Vector2 target)
	{
		this.path = ITEPathComputer.Calculate(new Vector2(this.transform.position.x, this.transform.position.y), target);
	}
}
