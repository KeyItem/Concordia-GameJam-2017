using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {


	//PlayerHealth
	//PlayerAudio

	string playerName;
	GameObject playerGameObject;
	int playerID;
	int playerVariantNumber;
	//PlayerHealth playerCharacterHealth
	//PlayerAduio playerCharacterAudio
	int victoryCount;
	int knockoutCount;
	Sprite playerPortrait;
	AudioClip victoryBleat;
	int deafaultSpronginess;




	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void AddToVictoryCount(){
		victoryCount++;
	}

	void AddToKnockoutCount(){
		knockoutCount++;
	}

	void DebugPrintout(){
		Debug.Log (playerName);
		Debug.Log (playerGameObject);
		Debug.Log (playerID);
		Debug.Log (playerName);
	}

	bool TrueIfNotNull<T>(T variableToTest){
		if (T == null) {
			return false;
		} else {
			return true;
		}
	}
}
