#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

using ITE;

[ExecuteInEditMode]
public class ITETiledPrefab : ITEPrefab
{
	public override void CalculateTiles()
	{
		base.CalculateTiles();
		
		this.OccupiedTiles = new List<ITETile>();
		
		if ((ITELayer)this.Layer != ITELayer.Actor)
		{
			foreach(ITETile tile in this.Tiles)
			{
				if (tile.State != ITETileState.Empty)
					this.OccupiedTiles.Add(tile);
			}
		}
	}
}
