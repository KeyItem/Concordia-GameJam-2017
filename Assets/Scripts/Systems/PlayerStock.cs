using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStock : MonoBehaviour {

	public int currentStock = 3;
	public int deathStock = 0;
	GameObject thisPlayer;
	public bool isStillAlive;

	// Use this for initialization
	void Start () {
		thisPlayer = this.gameObject;
		isStillAlive = (currentStock > deathStock);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStock(){
		currentStock++;
		Debug.Log (thisPlayer.name + " has" + currentStock + " lives left");
	}
	public void RemoveStock(){
		currentStock--;
		Debug.Log (thisPlayer.name + " has" + currentStock + " lives left");
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

}
