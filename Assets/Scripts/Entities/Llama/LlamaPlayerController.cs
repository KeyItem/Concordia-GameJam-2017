using System.Collections;
using UnityEngine;

public class LlamaPlayerController : MonoBehaviour
{
    private PlayerStock playerStock;

    [Header("Player Attributes")]
    public PlayerColor teamColor;

    public float playerRespawnTime = 2f;

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

    private LlamaHornController hornController;
    [Space(10)]
    public Rigidbody[] listOfJoints;
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

    [Header("Horn List")]
    public GameObject[] hornList;

    [Header("Debug")]
    public Vector2 inputMovementVector;
    public Vector2 inputHeadVector;
    [Space(10)]
    public float currentVelocity;

    private bool isInitialized = false;
    
    private void Start()
    {
        InitializePlayer();
    }

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

    public void InitializePlayer()
    {
        LayerMask playerMask;

        switch(teamColor)
        {
            case PlayerColor.RED:
                playerMask = LayerMask.NameToLayer("PlayerRed");

                gameObject.layer = playerMask;

                hornCollider.layer = playerMask;

                foreach(Rigidbody joint in listOfJoints)
                {
                    joint.gameObject.layer = playerMask;
                }
                break;

            case PlayerColor.BLUE:
                playerMask = LayerMask.NameToLayer("PlayerBlue");

                gameObject.layer = playerMask;

                hornCollider.layer = playerMask;

                foreach(Rigidbody joint in listOfJoints)
                {
                    joint.gameObject.layer = playerMask;
                }
                break;

            case PlayerColor.GREEN:
                playerMask = LayerMask.NameToLayer("PlayerGreen");

                gameObject.layer = playerMask;

                hornCollider.layer = playerMask;

                foreach (Rigidbody joint in listOfJoints)
                {
                    joint.gameObject.layer = playerMask;
                }
                break;

            case PlayerColor.YELLOW:
                playerMask = LayerMask.NameToLayer("PlayerYellow");

                gameObject.layer = playerMask;

                hornCollider.layer = playerMask;

                foreach (Rigidbody joint in listOfJoints)
                {
                    joint.gameObject.layer = playerMask;
                }
                break;
        }

        mainBody = GetComponent<Rigidbody>();

        hornController = hornCollider.GetComponent<LlamaHornController>();

        playerStock = GetComponent<PlayerStock>();

        isInitialized = true;
    }

    private void ReadInput()
    {       
        if (isInitialized)
        {
            directionVector = inputMovementVector.normalized;

            headVector.Set(inputHeadVector.x, 0, inputHeadVector.y);
        }
    }

    private void ManageBodyMovement()
    {
        if (inputMovementVector != Vector2.zero)
        {
            if (isGrounded)
            {
                currentVelocity = mainBody.velocity.magnitude;

                targetSpeed = baseMovementSpeed * inputMovementVector.magnitude;

                movingVector = transform.forward * targetSpeed;

                if (currentVelocity < maxMovementSpeed)
                {
                    mainBody.AddForce(movingVector * Time.fixedDeltaTime, ForceMode.Impulse);
                }
                else
                {
                    mainBody.velocity = (transform.forward * maxMovementSpeed);
                }
            }          
        }

        /*
        if (inputMovementVector != Vector2.zero)
        {
            if (isGrounded)
            {
                currentVelocity = mainBody.velocity.magnitude;

                targetSpeed = baseMovementSpeed * inputMovementVector.magnitude;

                currentSpeed = currentVelocity;

                currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref moveSmoothVelocity, moveSmoothTime);

                movingVector = transform.forward * currentSpeed;

                if (currentVelocity < maxMovementSpeed)
                {
                    mainBody.AddForce(movingVector * Time.fixedDeltaTime, ForceMode.Impulse);
                }     
            }          
        }
        */
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
            hornController.isHornActive = true;
            
            isMovingHead = true;

            baseOfNeck.AddForce(headVector * baseNeckControlSpeed * Time.fixedDeltaTime, ForceMode.Impulse);

            hornController.EnableTrail(); 
        }
        else
        {
            hornController.isHornActive = false;

            isMovingHead = false;

            hornController.DisableTrail();
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

    public void Die()
    {
        StartCoroutine(RespawnAfterTime(playerRespawnTime));
    }

    private IEnumerator RespawnAfterTime(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        transform.position = Vector3.zero + Vector3.up;

        playerStock.RemoveStock();

        if (!playerStock.IsPlayerAlive())
        {
            Debug.Log("Game Over for " + gameObject.name);
        }
    }

    public void SpawnHorn(Horn hornToSpawn)
    {
        GameObject newHorn = Instantiate(hornToSpawn.hornGameObject, hornCollider.transform.position, hornCollider.transform.rotation, hornCollider.transform) as GameObject;
    }
}
