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
public class ITEActorPrefab : ITEPrefab
{
	public override void CalculateTiles()
	{

	}
}
