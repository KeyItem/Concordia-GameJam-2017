using System.Collections;
using UnityEngine;

public class LlamaHeadCollisionController : MonoBehaviour
{
    [Header("Collision Interactions Values")]
    public LayerMask collisionLayers;

    private float impulseApplied;

    private GameObject hitObject;

    private void OnCollisionEnter(Collision collision)
    {
        hitObject = collision.collider.gameObject;

        impulseApplied = collision.relativeVelocity.magnitude;

        if (hitObject.GetComponent<Rigidbody>())
        {


            Debug.Log("Hit " + collision.collider.gameObject.name + " with " + impulseApplied + " of Force");
        }       
    }
}
