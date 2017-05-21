using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerLobbyInput : MonoBehaviour {

	private Player playerInput;
	public PlayerNumber playerNumber;
    public PlayerCharacter currentCharacter;
    public int characterIndex =0;

    public Horn currentHorn;
    public int hornIndex = 0;

    public bool isAssigned = false;
	public bool hasPickedCharacter = false;
	public bool hasPickedHorn = false;
	public bool hasConfirmed = false;

    [Space(10)]
    [Header("UI Stuff")]
    [Space(10)]
    public Sprite playerPortrait;
    public Text playerName;
    public Sprite hornPortrait;
    public Text hornName;

    public GameObject onAcceptUI;
    public GameObject onNoAcceptUI;

    public PlayerCharacter[] characterList;
    public Horn[] hornList;


    // Use this for initialization
    void Start () {
		Initialize ();

    }
	
	// Update is called once per frame
	void Update () {
        ReadInput();

    }
	public void AssignInput(int playerToAssign){
		playerInput = ReInput.players.GetPlayer (playerToAssign);
	//	isAssigned = true;
	}
	private void ReadInput(){
        if (playerInput.GetButtonDown("Accept"))
        {
            if (isAssigned == false)
            {
                onNoAcceptUI.SetActive(false);
                onAcceptUI.SetActive(true);
                isAssigned = true;
                ShowCharacter();
                return;
            }
            if (hasPickedCharacter == false && isAssigned == true)
            {
                SelectCharacter();
                Debug.Log("PickHornTime");
                ShowHorn();
            }
            if (hasPickedHorn == false && hasPickedCharacter == true)
            {
                hasPickedHorn = true;
            }
        }
		if (playerInput.GetButtonDown ("Decline")) {
            if (hasConfirmed)
            {
                hasConfirmed = false;
                return;
            }
            if (hasPickedHorn)
            {
                hasPickedHorn = false;
                return;
            }
            if (hasPickedCharacter)
            {
                DeselectCharacter();
                return;
            }
            if (isAssigned)
            {
                onNoAcceptUI.SetActive(true);
                onAcceptUI.SetActive(false);
                isAssigned = false;
                return;
            }
        }
        if (playerInput.GetButtonDown("Start"))
        {
            if (GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().readyToPlay)
            {
                GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().StartGame();
            }
            else {
                return;
            }
        }
        //if (playerInput.GetAxis ("MenuAxis")) {

        //}
    }

	private void Initialize(){

        characterList = GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().characterList;
        hornList = GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().hornList;
        onAcceptUI = gameObject.transform.GetChild(1).gameObject;
        onNoAcceptUI = gameObject.transform.GetChild(2).gameObject;
        playerPortrait = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
        playerName = gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<Text>();

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

    public void NextCharacter()
    {
        if (++characterIndex < characterList.Length)
        {
            characterIndex = 0;
        } else {
            characterIndex++;
        }

        ShowCharacter();
    }

    public void PreviousCharacter()
    {
        if (--characterIndex < 0)
        {
            characterIndex = characterList.Length;
        }
        else
        { 
            characterIndex--;
        }
        ShowCharacter();
    }
    public void SelectCharacter()
    {
        hasPickedCharacter = true;
    }
    public void DeselectCharacter()
    {
        hasPickedCharacter = false;
    }
    public void ShowCharacter() {
        currentCharacter = characterList[characterIndex];
        playerName.text = currentCharacter.characterName;
        playerPortrait = currentCharacter.characterPortrait;
        gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = playerPortrait;

    }
    public void ShowHorn()
    {
         currentHorn = hornList[hornIndex];
         hornName.text = currentHorn.hornName;
         hornPortrait = currentHorn.hornPortrait;
         gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = hornPortrait;
    }
    public void NextHorn()
    {
        if (++hornIndex < hornList.Length)
        {
            hornIndex = 0;
        }
        else
        {
            characterIndex++;
        }

        ShowHorn();
    }

    public void PreviousHorn()
    {
        if (--hornIndex < 0)
        {
            hornIndex = hornList.Length;
        }
        else
        {
            hornIndex--;
        }
        ShowHorn();
    }
    public void SelectHorn()
    {
        hasPickedHorn = true;
    }
    public void DeselectHorn()
    {
        hasPickedHorn = false;
    }

}

