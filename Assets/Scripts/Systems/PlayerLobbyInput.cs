using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerLobbyInput : MonoBehaviour {

	private Player playerInput;
	public PlayerNumber playerNumber;
	public bool isAssigned = false;
	public bool hasPickedCharacter = false;
	public bool hasPickedHorn = false;
	public bool hasConfirmed = false;


	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AssignInput(int playerToAssign){
		playerInput = ReInput.players.GetPlayer (playerToAssign);
	//	isAssigned = true;
	}
	private void ReadInput(){
		if (playerInput.GetButtonDown ("Accept")) {
			//call accept
		}
		if (playerInput.GetButtonDown ("Decline")) {
		}
		//if (playerInput.GetAxis ("MenuAxis")) {
			
		//}
	}

	private void Initialize(){
		switch (playerNumber) {
		case PlayerNumber.PLAYER1:
			AssignInput (0);
			break;
		case PlayerNumber.PLAYER2:
			AssignInput (1);
			break;
		case PlayerNumber.PLAYER3:
			AssignInput (2);
			break;
		case PlayerNumber.PLAYER4:
			AssignInput (3);
			break;
		default:
			break;

		}
	}



}

