using System.Collections;
using UnityEngine;

public class LlamaHornController : MonoBehaviour
{
    [Header("Collision Interactions Values")]
    private GameObject hitObject;

    private float impulseApplied;

    public float baseForce = 5;

    [Header("Trail Renderer Attributes")]
    private TrailRenderer trailRenderer;

    private bool isTrailEnabled = false;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();

        trailRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitObject = collision.collider.gameObject;

        impulseApplied = collision.relativeVelocity.magnitude;

        if (hitObject.CompareTag("Player") || hitObject.CompareTag("Object"))
        {
            if (hitObject.GetComponent<Rigidbody>())
            {
                Vector3 interceptVec = (hitObject.transform.position - transform.position).normalized;

                interceptVec.y = 0;

                hitObject.GetComponent<Rigidbody>().AddForce(interceptVec * baseForce, ForceMode.Impulse);

                Debug.Log(gameObject.name + " Hit " + collision.collider.gameObject.name + " with " + baseForce + " of Force");
            }
        }     
    }

    public void EnableTrail()
    {
        if (!isTrailEnabled)
        {
            trailRenderer.enabled = true;

            isTrailEnabled = true;
        }
    }

    public void DisableTrail()
    {
        if (isTrailEnabled)
        {
            trailRenderer.enabled = false;

            isTrailEnabled = false;
        }
    }
}
