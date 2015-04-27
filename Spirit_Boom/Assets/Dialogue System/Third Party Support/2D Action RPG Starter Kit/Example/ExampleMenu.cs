using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.UnityGUI;

namespace PixelCrushers.DialogueSystem.ActionRPG2D {
	
	/// <summary>
	/// This script provides a rudimentary example main menu for the 2D Action RPG demo.
	/// </summary>
	public class ExampleMenu : MonoBehaviour {

		public string startingLevel = "playerhouse";
		public GUISkin guiSkin = null;
		public QuestLogWindow questLogWindow = null;

		public GameObject player = null;

		public bool showQuestLogButton = true;
		public bool showSaveGameButton = true;
		public bool showLoadGameButton = true;
		public bool showNewGameButton = true;
		public bool showCloseMenuButton = true;
		
		private bool isMenuOpen = false;
		private Rect windowRect = new Rect(0, 0, 500, 500);
		private ScaledRect scaledRect = ScaledRect.FromOrigin(ScaledRectAlignment.MiddleCenter, ScaledValue.FromPixelValue(300), ScaledValue.FromPixelValue(320));

		private Vector3 initialPlayerPosition = Vector3.zero;
		private const int initialPlayerHealth = 6;

		void Start() {
			if (player == null) player = GameObject.Find("permanentobjects/Player");
			if (player != null) initialPlayerPosition = player.transform.position;
			SetMenuStatus(true);
		}
		
		void Update() {
			if (showCloseMenuButton && Input.GetKeyDown(KeyCode.Escape) && !DialogueManager.IsConversationActive && !IsQuestLogOpen()) {
				SetMenuStatus(!isMenuOpen);
			}
		}
		
		void OnGUI() {
			if (isMenuOpen) {
				if (guiSkin != null) {
					GUI.skin = guiSkin;
				}
				windowRect = GUI.Window(0, windowRect, WindowFunction, "Menu");
			}
		}

		private bool IsStartMenuScreen() {
			return string.Equals(Application.loadedLevelName, "menu") || string.Equals(Application.loadedLevelName, "loader");
		}
		
		private void WindowFunction(int windowID) {
			bool isMenuScreen = IsStartMenuScreen();
			if (!isMenuScreen && GUI.Button(new Rect(10, 60, windowRect.width - 20, 48), "Quest Log")) {
				SetMenuStatus(false);
				OpenQuestLog();
			}
			if (!isMenuScreen && GUI.Button(new Rect(10, 110, windowRect.width - 20, 48), "Save Game")) {
				SetMenuStatus(false);
				SaveGame();
			}
			if (GUI.Button(new Rect(10, 160, windowRect.width - 20, 48), "Load Game")) {
				SetMenuStatus(false);
				StartCoroutine(LoadGame());
			}
			if (GUI.Button(new Rect(10, 210, windowRect.width - 20, 48), "New Game")) {
				SetMenuStatus(false);
				StartCoroutine(NewGame());
			}
			if (!isMenuScreen && GUI.Button(new Rect(10, 260, windowRect.width - 20, 48), "Close Menu")) {
				SetMenuStatus(false);
			}
		}
		
		private void SetMenuStatus(bool open) {
			isMenuOpen = open;
			bool isMenuScreen = IsStartMenuScreen();
			if (open) windowRect = scaledRect.GetPixelRect();
			Time.timeScale = (open && !isMenuScreen) ? 0 : 1;
		}
		
		private bool IsQuestLogOpen() {
			return (questLogWindow != null) && questLogWindow.IsOpen;
		}
		
		private void OpenQuestLog() {
			if ((questLogWindow != null) && !IsQuestLogOpen()) {
				questLogWindow.Open();
			}
		}
		
		private void SaveGame() {
			ActionRPG2DBridge bridge = GameObject.Find("Player").GetComponent<ActionRPG2DBridge>();
			bridge.SyncToLua();
			string saveData = PersistentDataManager.GetSaveData();
			PlayerPrefs.SetString("SavedGame", saveData);
			Debug.Log("Save Game Data: " + saveData);
			DialogueManager.ShowAlert("Game Saved");
		}
	
		private IEnumerator LoadGame() {
			DialogueManager.PlaySequence("Fade(out,0.5); Fade(in,0.5)@0.5");
			yield return new WaitForSeconds(0.5f);
			if (PlayerPrefs.HasKey("SavedGame")) {
				string saveData = PlayerPrefs.GetString("SavedGame");
				Debug.Log("Load Game Data: " + saveData);
				LevelManager levelManager = GetComponentInChildren<LevelManager>();
				if (levelManager != null) {
					levelManager.LoadGame(saveData);
				} else {
					PersistentDataManager.ApplySaveData(saveData);
				}
				GameObject player = GameObject.Find("Player");
				ActionRPG2DBridge bridge = (player != null) ? player.GetComponent<ActionRPG2DBridge>() : null;
				if (bridge != null) bridge.SyncFromLua();
				if (player != null) {
					player.SendMessage("inventoryFix", SendMessageOptions.DontRequireReceiver);
					player.SendMessage("OnApplyPersistentData", SendMessageOptions.DontRequireReceiver);
				}
				DialogueManager.ShowAlert("Game Loaded");
			} else {
				DialogueManager.ShowAlert("Save a Game First");
			}
		}
		

		private IEnumerator NewGame() {
			DialogueManager.PlaySequence("Fade(out,0.5); Fade(in,0.5)@0.5");
			yield return new WaitForSeconds(0.5f);
			string saveData = PlayerPrefs.GetString("SavedGame");
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetString("SavedGame", saveData);
			PlayerPrefs.SetFloat("playerHealth", initialPlayerHealth);
			PlayerPrefs.SetFloat("slotSet", 1);
			PlayerPrefs.SetFloat("sword", 1);
			DialogueLua.InitializeChatMapperVariables();
			DialogueManager.ResetDatabase(DatabaseResetOptions.RevertToDefault);
			GameObject player = GameObject.Find("Player");
			if (player != null) {
				player.SendMessage("RefreshFromPlayerPrefs", SendMessageOptions.DontRequireReceiver);
				player.transform.position = initialPlayerPosition;
			}
			Application.LoadLevel(startingLevel);
			DialogueManager.ShowAlert("New Game Started");
		}

	}

}
