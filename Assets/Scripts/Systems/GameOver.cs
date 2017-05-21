using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public PlayerStock[] playerLives;
	public bool gameIsDone = false;
	public int playersThatAreAlive;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckLives(){
		int livingPlayers = playersThatAreAlive;
		for (int i = 0; i < playerLives.Length; i++) {
			
			if (playerLives [i].currentStock == playerLives [i].deathStock) {
				playerLives [i].isStillAlive = false;
			}
		}
		//for (livingPlayers; )
	}
}
