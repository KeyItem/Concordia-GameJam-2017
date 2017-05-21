using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStock : MonoBehaviour {

	public PlayerNumber thisPlayerNumber;
	public int currentStock = 3;
	public int deathStock = 0;
	GameObject thisPlayer;
	public bool isStillAlive;
	public Text stockText;
	public Sprite playerSprite;
	public LobbyVariables lobbyVariablesForStock;


	// Use this for initialization
	void Start () {
		stockText = gameObject.transform.GetChild (1).gameObject.GetComponent<Text> ();
		playerSprite = gameObject.transform.GetChild (2).gameObject.GetComponent<Image> ().sprite;
		lobbyVariablesForStock = GameObject.Find ("VariableManager").GetComponent<LobbyVariables> ();
		thisPlayer = this.gameObject;
		isStillAlive = (currentStock > deathStock);
		ShowPortrait ();
	}
	
	// Update is called once per frame
	void Update () {
		ShowStock ();
	}

	public void AddStock(){
		currentStock++;
	}
	public void RemoveStock(){
		currentStock--;
	}
		
	public bool IsPlayerAlive(){
		if (currentStock > deathStock) {
			isStillAlive = true;
			return true;
		} else {
			isStillAlive = false;
			return false;
		}
	}
	public void ShowStock(){
		stockText.text = currentStock.ToString();

	}
	public void ShowPortrait(){
		Debug.Log ((int)thisPlayerNumber);
		playerSprite = lobbyVariablesForStock.playersToStartGameList [(int)thisPlayerNumber].characterPortrait;
	}

}
