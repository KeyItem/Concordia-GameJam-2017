using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class CharacterSelection : MonoBehaviour {

	[Space(10)]
	[Header("Public Lists")]
	[Space(10)]

    public PlayerCharacter[] characterList;
    public Horn[] hornList;
	public GameObject[] playerPanelList;
	public PlayerLobbyInput[] playersInGameList; //update this list to match the number of controllers plugged in

	[Space(10)]
	[Header("To be passed to next scene with information")]
	[Space(10)]
	public PlayerCharacter[] playersToStartGameList;
	public Horn[] hornToStartGameList;


	[Space(10)]
	[Header("UI stuff")]
	[Space(10)]
	public Text pressStartText;

	[Space(10)]
	[Header("Variables to Track")]
	[Space(10)]
	public bool readyToPlay = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		EnableStartMatch ();
	}

	public void SaveCharacterSelection(){
		playersToStartGameList = new PlayerCharacter[playersInGameList.Length];
		hornToStartGameList = new Horn[playersInGameList.Length];

		for (int i = 0; i < playersInGameList.Length; i++)
		{
			if (playersInGameList [i].isAssigned)
			{
				playersToStartGameList [i] = playersInGameList [i].currentCharacter;
				hornToStartGameList [i] = playersInGameList [i].currentHorn;
			}

			else 
			{
				playersToStartGameList [i] = null;
				hornToStartGameList [i] = null;
			}
		}
		GameObject.Find ("VariableManager").GetComponent<LobbyVariables> ().SaveInformationForGame();
	}

    public void StartGame() {
        SaveCharacterSelection();

        //Load Scene Script
        Debug.Log("Make it load the scene");
    }
	public void EnableStartMatch(){
			
		for (int i = 0; i < playersInGameList.Length; i++) {
			//Debug.Log ("I ran the damn loop");

			//If they selected a panel "isAssigned is true"
			if (playersInGameList [i].isAssigned) {

				//If they did all of the steps (are confirmed) this is true
				if (playersInGameList [i].hasConfirmed == true) {
					readyToPlay = true;
					//Debug.Log (" I got it right ");


				} else 
 {					//They are assigned but aren't ready
					readyToPlay = false;
					pressStartText.enabled = false;
					//Debug.Log (" Someone wasn't ready ");

					return;
				} 
			}

			if (readyToPlay) {
				pressStartText.enabled = true;
			} else {
			}
		}
	}

}
