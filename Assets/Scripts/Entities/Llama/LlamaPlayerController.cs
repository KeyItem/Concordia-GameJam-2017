using System.Collections;
using UnityEngine;

public class LlamaPlayerController : MonoBehaviour
{
    [Header("Player Attributes")]
    public PlayerColor teamColor;

    [Header("Llama Body Parts")]
    public Rigidbody mainBody;
    [Space(10)]
    public Rigidbody baseOfNeck;

    [Header("Llama Movement Values")]
    public float baseMovementSpeed;
    public float maxMovementSpeed;
    [Space(10)]
    public float moveSmoothTime;

    private float currentSpeed;
    private float targetSpeed;
    private float moveSmoothVelocity;

    private Vector3 movingVector;
    private Vector2 directionVector;

    [Header("Llama Turning Movement Values")]
    public float turningSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private float targetRotation = 0f;

    private Vector3 turningVector;

    [Header("Llama Neck Movement Values")]
    public GameObject hornCollider;
    [Space(10)]
    public float baseNeckControlSpeed;

    private Vector3 headVector;

    public bool isMovingHead = false;

    [Header("Llama Jumping Values")]
    public float jumpForce;

    [Header("Ground Check Values")]
    public float groundRayDistance;

    public LayerMask groundMask;

    public bool isGrounded = true;

    [Header("Debug")]
    public Vector2 inputMovementVector;
    public Vector2 inputHeadVector;
    [Space(10)]
    public float currentVelocity;

    private void Update()
    {
        GroundCheck();
    }

    private void FixedUpdate()
    {
        ReadInput();

        ManageBodyMovement();

        ManageBodyRotation();

        ManageHeadMovement();
    }

    private void ReadInput()
    {       
        directionVector = inputMovementVector.normalized;

        headVector.Set(inputHeadVector.x, 0, inputHeadVector.y);
    }

    private void ManageBodyMovement()
    {
        if (inputMovementVector != Vector2.zero)
        {
            if (isGrounded)
            {
                targetSpeed = baseMovementSpeed * inputMovementVector.magnitude;

                currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref moveSmoothVelocity, moveSmoothTime);

                movingVector = transform.forward * currentSpeed;

                if (currentVelocity < maxMovementSpeed)
                {
                    mainBody.AddForce(movingVector * Time.fixedDeltaTime, ForceMode.Impulse);
                }           
            }          
        }

        currentVelocity = Mathf.Round(mainBody.velocity.magnitude);
    }

    private void ManageBodyRotation()
    {
        if (directionVector != Vector2.zero)
        {
            targetRotation = Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg;

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turningSmoothTime);
        }
    }

    private void ManageHeadMovement()
    {
        if (headVector != Vector3.zero)
        {
            baseOfNeck.AddForce(headVector * baseNeckControlSpeed * Time.fixedDeltaTime, ForceMode.Impulse);

            isMovingHead = true;
        }
        else
        {
            isMovingHead = false;
        }
    }

    private void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, groundRayDistance, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
