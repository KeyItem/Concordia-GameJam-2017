using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {


	public string playerName;
	public GameObject playerGameObject;
	public int playerID;
	public int playerVariantNumber;
	public int playerCharacterIncomingKnockbackModifier;
	public int playerCharacterOutgoingKnockbackModifier;
	public int victoryCount;
	public int knockoutCount;
	public Sprite playerPortrait;
	public AudioClip victoryBleat;
	public int defaultSpronginess;


	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AddToVictoryCount(){
		victoryCount++;
	}

	public void AddToKnockoutCount(){
		knockoutCount++;
	}
	public void DebugPrintout(){
		Debug.Log ("Does the playerCharacter have a name? " + TrueIfNotNull(playerName) + " and its name is: " + playerName);
		Debug.Log ("Does the playerCharacter have a GameObject? " + TrueIfNotNull(playerGameObject) + " and its name is: " + playerGameObject.name);
		Debug.Log ("Does the playerCharacter have an ID? " + TrueIfNotNull(playerID) + " and its ID is: " + playerID);
		Debug.Log ("Does the playerCharacter have an playerVariantNumber? " + TrueIfNotNull(playerVariantNumber) + " and its PlayerVariantNumber is: " + playerVariantNumber);
		Debug.Log ("Does the playerCharacter have an victoryCount? " + TrueIfNotNull(victoryCount) + " and its victoryCount is: " + victoryCount);
		Debug.Log ("Does the playerCharacter have an victoryBleat? " + TrueIfNotNull(victoryBleat) + " and its victoryBleat is: " + victoryBleat.name);
		Debug.Log ("Does the playerCharacter have an defaultSpronginess? " + TrueIfNotNull(defaultSpronginess) + " and its defaultSpronginess is: " + defaultSpronginess);
		Debug.Log ("Does the playerCharacter have an playerCharacterIncomingKnockbackModifier? " + TrueIfNotNull(playerCharacterIncomingKnockbackModifier) + " and its playerCharacterIncomingKnockbackModifier is: " + playerCharacterIncomingKnockbackModifier);
		Debug.Log ("Does the playerCharacter have an playerCharacterOutgoingKnockbackModifier? " + TrueIfNotNull(playerCharacterOutgoingKnockbackModifier) + " and its defaultSpronginess is: " + playerCharacterOutgoingKnockbackModifier);
	}

	public bool TrueIfNotNull<T>(T variableToTest){
		if (variableToTest == null) {
			return false;
		} else {
			return true;
		}
	}

}
