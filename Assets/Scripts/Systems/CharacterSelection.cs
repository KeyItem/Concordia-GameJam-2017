using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class CharacterSelection : MonoBehaviour {

	public PlayerCharacter[] characterList;
	//player list
	public PlayerLobbyInput[] playersInGameList; //update this list to match the number of controllers plugged in
	public GameObject[] playerPanelList;
	public Text pressStartText;
	public bool readyToPlay = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnableStartMatch ();
	}
		
	public void NextCharacter(GameObject panelToMove){
		// 
	}
	public void PreviousCharacter(){
	}
	public void SelectCharacter(){
		
	}
	public void DeselectCharacter(){
	}
	public void SaveCharacterSelection(){
	
	}

	public void EnableStartMatch(){
			
			for (int i = 0; i < playersInGameList.Length; i++) {
				Debug.Log ("I ran the damn loop");

				//If they selected a panel "isAssigned is true"
				if (playersInGameList [i].isAssigned) {

					//If they did all of the steps (are confirmed) this is true
					if (playersInGameList [i].hasConfirmed == true) {
						readyToPlay = true;
						Debug.Log (" I got it right ");


					} else 
					//They are assigned but aren't ready
						{
						readyToPlay = false;
						pressStartText.enabled = false;
						Debug.Log (" Someone wasn't ready ");

						return;
					} 
				} 

			}
			if (readyToPlay) {
				pressStartText.enabled = true;
			} else {
		}
	}

	public Sprite LoadSprite(PlayerCharacter characterSpriteToLoad){
		return characterSpriteToLoad.characterPortrait;
	}
	public string LoadName(PlayerCharacter playerNameToLoad){
		return playerNameToLoad.characterName;
	}
}
