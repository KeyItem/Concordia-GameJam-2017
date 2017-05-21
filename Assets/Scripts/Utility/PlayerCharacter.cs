using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {



	[Space(10)]
	[Header("Current Player Information")]
	public PlayerClass currentPlayer;
	[Space(10)]

	[Space(10)]
	[Header("Character Identification")]
	[Space(10)]
	public GameObject characterGameObject;
	public string characterName;
	[Tooltip("This is the characterID that identifies numerically which character is which")]
	public float characterID;
	[Tooltip("This is the number that specifies which variant of the character is in use 0-10")]
	public float characterVariantNumber;

	[Space(10)]
	[Header("Character Combat Info")]
	[Space(10)]
	[Range(0.0f, 10.0f)]
	public float characterIncomingKnockbackModifier;
	[Range(0.0f, 10.0f)]
	public float characterOutgoingKnockbackModifier;
	[Tooltip("This value makes magic under the hood, modify for fun 0-infinity")]
	public float spronginess;

	[Space(10)]
	[Header("Horn Info")]
	[Space(10)]
	public GameObject playerHorn;


	[Space(10)]
	[Header("CharacterPersonality")]
	[Space(10)]
	public Sprite characterPortrait;
	public AudioClip victoryBleat;
	public AudioClip painBleat;
	public AudioClip smackBleat;



	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void DebugPrfloatout(){
		Debug.Log ("Does the characterCharacter have a name? " + TrueIfNotNull(characterName) + " and its name is: " + characterName);
		Debug.Log ("Does the characterCharacter have a GameObject? " + TrueIfNotNull(characterGameObject) + " and its name is: " + characterGameObject.name);
		Debug.Log ("Does the characterCharacter have an ID? " + TrueIfNotNull(characterID) + " and its ID is: " + characterID);
		Debug.Log ("Does the characterCharacter have an characterVariantNumber? " + TrueIfNotNull(characterVariantNumber) + " and its characterVariantNumber is: " + characterVariantNumber);
		Debug.Log ("Does the characterCharacter have an victoryBleat? " + TrueIfNotNull(victoryBleat) + " and its victoryBleat is: " + victoryBleat.name);
		Debug.Log ("Does the characterCharacter have an spronginess? " + TrueIfNotNull(spronginess) + " and its spronginess is: " + spronginess);
		Debug.Log ("Does the characterCharacter have an characterCharacterIncomingKnockbackModifier? " + TrueIfNotNull(characterIncomingKnockbackModifier) + " and its characterIncomingKnockbackModifier is: " + characterIncomingKnockbackModifier);
		Debug.Log ("Does the characterCharacter have an characterCharacterOutgoingKnockbackModifier? " + TrueIfNotNull(characterOutgoingKnockbackModifier) + " and its characterOutgoingKnockbackModifier is: " + characterOutgoingKnockbackModifier);
	}

	public bool TrueIfNotNull<T>(T variableToTest){
		if (variableToTest == null) {
			return false;
		} else {
			return true;
		}
	}

}
