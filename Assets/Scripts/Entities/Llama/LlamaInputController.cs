using System.Collections;
using UnityEngine;
using Rewired;

public class LlamaInputController : MonoBehaviour
{
    private LlamaPlayerController playerController;

    private Player playerInput;

    [Header("Input Values")]
    public PlayerNumber playerNumber;
    [Space(10)]
    public float leftXAxis;
    public float leftYAxis;
    [Space(10)]
    public float rightXAxis;
    public float rightYAxis;

    [Header("Input Vectors")]
    public Vector2 movementVector;
    public Vector2 headVector;

    private void Start()
    {
        playerController = GetComponent<LlamaPlayerController>();

        switch(playerNumber)
        {
            case PlayerNumber.PLAYER1:
                playerInput = ReInput.players.GetPlayer(0);
                break;

            case PlayerNumber.PLAYER2:
                playerInput = ReInput.players.GetPlayer(1);
                break;

            case PlayerNumber.PLAYER3:
                playerInput = ReInput.players.GetPlayer(2);
                break;

            case PlayerNumber.PLAYER4:
                playerInput = ReInput.players.GetPlayer(3);
                break;
        }
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        leftXAxis = playerInput.GetAxis("LeftHorizontalMovement");
        leftYAxis = playerInput.GetAxis("LeftVerticalAxisMovement");

        rightXAxis = playerInput.GetAxis("RightHorizontalHeadMovement");
        rightYAxis = playerInput.GetAxis("RightVerticalHeadMovement");

        movementVector.Set(leftXAxis, leftYAxis);
        headVector.Set(rightXAxis, rightYAxis);
    }
}
