using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.ActionRPG2D {

	/// <summary>
	/// This component synchronizes 2D Action RPG data with Dialogue System data. 
	/// Add it to your Dialogue Manager object.
	/// </summary>
	[AddComponentMenu("Dialogue System/Third Party/2D Action RPG Starter Kit/2D Action RPG Bridge")]
	public class ActionRPG2DBridge : MonoBehaviour {

		/// <summary>
		/// A reference to the inventory object.
		/// </summary>
		public GameObject inventory;

		/// <summary>
		/// The variables that are synchronized. These should also include all itemIds.
		/// </summary>
		public string[] variables = new string[] { "playerHealth", "money", "slotSet", "sword", "bow", "wand", "potion" };

		/// <summary>
		/// If ticked, player movement control is disabled during conversations.
		/// </summary>
		public bool freezePlayerDuringConversations = false;

		/// <summary>
		/// If ticked, save data will include dialogue entry status (offered and/or spoken).
		/// </summary>
		public bool includeSimStatus = false;

		private GameObject player = null;

		void Start() {
			PersistentDataManager.includeSimStatus = includeSimStatus;
			player = GameObject.Find("permanentobjects/Player");
			if (player == null && DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: ActionRPG2DBridge couldn't find the player object!", DialogueDebug.Prefix));
			if (inventory == null && DialogueDebug.LogWarnings) Debug.LogWarning(string.Format("{0}: You must assign the inventory to ActionRPG2DBridge!", DialogueDebug.Prefix));
		}

		/// <summary>
		/// Prepares to run a conversation by freezing the player (if ticked), syncing data to Lua,
		/// and setting the NPC to "talking" mode.
		/// </summary>
		/// <param name="actor">The other actor.</param>
		public void OnConversationStart(Transform actor) {
			SyncToLua();
			if (freezePlayerDuringConversations) FreezePlayer();
			if (actor != null) actor.SendMessage("talking", 1, SendMessageOptions.DontRequireReceiver);
		}

		/// <summary>
		/// At the end of a conversation, unfreezes the player, syncs data back from Lua, and
		/// turns off the NPC's "talking" mode.
		/// </summary>
		/// <param name="actor">Actor.</param>
		public void OnConversationEnd(Transform actor) {
			if (freezePlayerDuringConversations) UnfreezePlayer();
			SyncFromLua();
			if (actor != null) actor.SendMessage("talking", 0, SendMessageOptions.DontRequireReceiver);
		}

		/// <summary>
		/// Freezes the player.
		/// </summary>
		public void FreezePlayer() {
			SetPlayerControl(false);
		}

		/// <summary>
		/// Unfreezes the player.
		/// </summary>
		public void UnfreezePlayer() {
			SetPlayerControl(true);
		}

		public void SetPlayerControl(bool value) {
			SetMonoBehaviour("playercontrols", value);
			SetMonoBehaviour("playerweapons", value);
			Rigidbody rigidbody = (player != null) ? player.GetComponent<Rigidbody>() : null;
			if (rigidbody != null) rigidbody.velocity = Vector3.zero;
		}
		
		private void SetMonoBehaviour(string monoBehaviourName, bool value) {
			if (player == null) return;
			MonoBehaviour monoBehaviour = player.GetComponent(monoBehaviourName) as MonoBehaviour;
			if (monoBehaviour != null) monoBehaviour.enabled = value;
		}

		/// <summary>
		/// Syncs data to Lua.
		/// </summary>
		public void SyncToLua() {
			foreach (var variable in variables) {
				SyncVariableToLua(variable);
			}
		}

		/// <summary>
		/// Syncs back from Lua.
		/// </summary>
		public void SyncFromLua() {
			foreach (var variable in variables) {
				SyncLuaToVariable(variable);
			}
			if (player != null) player.SendMessage("RefreshFromPlayerPrefs", SendMessageOptions.DontRequireReceiver);
			if (inventory != null) inventory.SendMessage("makeSelection", PlayerPrefs.GetFloat("slotSet"), SendMessageOptions.DontRequireReceiver);
		}

		private void SyncVariableToLua(string variable) {
			float value = PlayerPrefs.HasKey(variable) ? PlayerPrefs.GetFloat(variable) : 0;
			Lua.Run(string.Format("Variable[\"{0}\"] = {1}", variable, value), DialogueDebug.LogInfo);
		}
		
		private void SyncLuaToVariable(string variable) {
			PlayerPrefs.SetFloat(variable, Lua.Run(string.Format("return Variable[\"{0}\"]", variable), DialogueDebug.LogInfo).AsFloat);
		}

	}

}
