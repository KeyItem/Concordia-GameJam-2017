using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public PlayerNumber playerID;
	public float victoryCount;
	public float knockoutCount;

	// Use this for initialization
	void Start () {
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

	public void AssignPlayers(){
		// Assign the players here
	}
}
