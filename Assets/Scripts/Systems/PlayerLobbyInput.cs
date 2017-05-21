using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerLobbyInput : MonoBehaviour {

	private Player playerInput;
	private bool isAssigned = false;
	public PlayerNumber playerNumber;

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AssignInput(int playerToAssign){
		playerInput = ReInput.players.GetPlayer (playerToAssign);
		isAssigned = true;
	}
	private void ReadInput(){
		if (playerInput.GetButtonDown ("Accept")) {
			//call accept
		}
	//	if
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

