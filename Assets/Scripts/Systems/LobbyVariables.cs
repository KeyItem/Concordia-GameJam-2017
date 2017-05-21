using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyVariables : MonoBehaviour {

	public PlayerCharacter[] playersToStartGameList;
	public Horn[] hornToStartGameList;
	public CharacterSelection characterSelectionInfo;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		characterSelectionInfo = GameObject.Find ("CharacterSelectionMaster").GetComponent<CharacterSelection> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveInformationForGame(){
		playersToStartGameList = characterSelectionInfo.playersToStartGameList;
		hornToStartGameList = characterSelectionInfo.hornToStartGameList;
	}
}
