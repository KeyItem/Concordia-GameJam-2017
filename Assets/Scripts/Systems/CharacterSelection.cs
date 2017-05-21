using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class CharacterSelection : MonoBehaviour {

	public PlayerCharacter[] characterList;
	//player list
	public PlayerClass[] playersInGameList; //update this list to match the number of controllers plugged in
	public GameObject[] playerPanelList;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
	public void StartMatch(){
	
	}

	public void LoadSprite(PlayerCharacter characterSpriteToLoad){
	
	}
	public void LoadName(PlayerCharacter characterSpriteToLoad){
	
	}
	public void AssignPanelToPlayer(PlayerClass playerToAssign){
		//for (int i = 0; i < playerPanæelList.Length; i++) {
		//	playerToAssign 
			//playerPanelList.Length[i]
		
		}
	//}


}
