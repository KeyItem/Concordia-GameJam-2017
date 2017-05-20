using System.Collections;
using UnityEngine;

public class LlamaPlayerController : MonoBehaviour
{
    [Header("Llama Body Parts")]
    public Rigidbody mainBody;
    [Space(10)]
    public Rigidbody neckBody;

    [Header("Llama Player Movement Values")]
    public float baseMovementSpeed;

    public Vector2 inputMovementVector;
    public Vector2 inputHeadVector;

    private Vector3 movementVector;

    [Header("Llama Neck Movement Values")]
    public float baseNeckControlSpeed;

    private Vector3 headVector;

    private void FixedUpdate()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (inputMovementVector != Vector2.zero)
        {
            Move();
        }

        if (inputHeadVector != Vector2.zero)
        {
            MoveHead();
        }
    }

    private void Move()
    {
        movementVector.Set(inputMovementVector.x, 0, inputMovementVector.y);

        mainBody.AddForce(movementVector * baseMovementSpeed * Time.fixedDeltaTime);
    }

    private void MoveHead()
    {
        headVector.Set(inputHeadVector.x, 0, inputHeadVector.y);

        neckBody.AddForce(headVector * baseNeckControlSpeed * Time.fixedDeltaTime);
    }
}
