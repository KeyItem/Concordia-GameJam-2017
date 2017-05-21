using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerLobbyInput : MonoBehaviour {

	//public string groupID;
	private Player playerInput;
	public PlayerNumber playerNumber;
    public PlayerCharacter currentCharacter;
    public int characterIndex =0;

    public Horn currentHorn;
    public int hornIndex = 0;

	public Color basePanel;

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
	public GameObject onHornUI;

    public PlayerCharacter[] characterList;
    public Horn[] hornList;

	float xAxis;
	bool canChangeAxis = true;


    // Use this for initialization
    void Start () {
		Initialize ();
		basePanel = gameObject.GetComponent<Image> ().color;

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

		xAxis = playerInput.GetAxis ("MenuAxis");


		if (playerInput.GetButtonDown ("Accept")) {
			if (isAssigned == false) {
				onNoAcceptUI.SetActive (false);
				onAcceptUI.SetActive (true);
				isAssigned = true;
				ShowCharacter ();
				return;
			}
			if (hasPickedCharacter == false && isAssigned == true) {
				SelectCharacter ();
				onAcceptUI.SetActive (false);
				onHornUI.SetActive (true);
				Debug.Log ("PickHornTime");
				ShowHorn ();
				return;
			}
			if (hasPickedHorn == false && hasPickedCharacter == true) {
				SelectHorn ();
				gameObject.GetComponent<Image> ().color = Colors.LightGreen;
				return;
			}
		}
		if (playerInput.GetButtonDown ("Decline")) {
			if (hasPickedHorn) {
				gameObject.GetComponent<Image> ().color = basePanel;
				hasConfirmed = false;
				hasPickedHorn = false;
				return;
			}
			if (hasPickedCharacter) {
				DeselectCharacter ();
				return;
			}
			if (isAssigned) {
				onNoAcceptUI.SetActive (true);
				onAcceptUI.SetActive (false);
				isAssigned = false;


				return;
			}
		}
		if (playerInput.GetButtonDown ("Start")) {
			if (GameObject.Find ("CharacterSelectionMaster").GetComponent<CharacterSelection> ().readyToPlay) {
				GameObject.Find ("CharacterSelectionMaster").GetComponent<CharacterSelection> ().StartGame ();
			} else {
				return;
			}
		}
		if (canChangeAxis) {
			if (xAxis > 0.5f) {
				canChangeAxis = false;


				if (hasPickedCharacter == false && isAssigned == true) {
					NextCharacter ();

				}
				if (hasPickedHorn == false && hasPickedCharacter == true) {
					NextHorn ();
				}
				StartCoroutine ("ResetAxisInput");
			}

			if (xAxis < -0.5f) {
				canChangeAxis = false;

				if (hasPickedCharacter == false && isAssigned == true) {
					PreviousCharacter ();

				}
				if (hasPickedHorn == false && hasPickedCharacter == true) {
					PreviousHorn ();

				}
				StartCoroutine ("ResetAxisInput");
			}

		}
    }

	private void Initialize(){

        characterList = GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().characterList;

        hornList = GameObject.Find("CharacterSelectionMaster").GetComponent<CharacterSelection>().hornList;
        onAcceptUI = gameObject.transform.GetChild(1).gameObject;
        onNoAcceptUI = gameObject.transform.GetChild(2).gameObject;
		onHornUI = gameObject.transform.GetChild(3).gameObject;

		playerPortrait = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
		playerName = gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<Text>();


		hornPortrait = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<Image>().sprite;
		hornName = gameObject.transform.GetChild(3).gameObject.transform.GetChild(3).GetComponent<Text>();

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

		if ((characterIndex + 1) < characterList.Length)
        {
			characterIndex++;
			Debug.Log (characterIndex);
        } else {
			characterIndex = 0;
        }

        ShowCharacter();
    }

    public void PreviousCharacter()
    {
		Debug.Log ("tryingPreviousCharacter");
		if ((characterIndex - 1) < 0)
        {
			characterIndex = (characterList.Length - 1);
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
         gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).GetComponent<Image>().sprite = hornPortrait;
    }
    public void NextHorn()
    {
		if ((hornIndex + 1) < hornList.Length)
        {
			hornIndex++;
        }
        else
        {
			hornIndex = 0;
        }

        ShowHorn();
    }

    public void PreviousHorn()
    {
		if ((hornIndex - 1) < 0)
        {
			hornIndex = (hornList.Length - 1);
            
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
		hasConfirmed = true;
    }
    public void DeselectHorn()
    {
        hasPickedHorn = false;
    }
	IEnumerator ResetAxisInput(){
		Debug.Log ("Running Wait for Seconds");
		yield return new WaitForSeconds(.5f);
		canChangeAxis = true;
	}

}

