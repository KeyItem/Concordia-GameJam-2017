﻿using System.Collections;
using UnityEngine;

public class LlamaHeadCollisionController : MonoBehaviour
{
    [Header("Collision Interactions Values")]
    private GameObject hitObject;

    private float impulseApplied;

    public float baseForce = 5;

    private void OnCollisionEnter(Collision collision)
    {
        hitObject = collision.collider.gameObject;

        impulseApplied = collision.relativeVelocity.magnitude;

        if (hitObject.GetComponent<Rigidbody>())
        {
            Vector3 interceptVec = (hitObject.transform.position - transform.position).normalized;

            hitObject.GetComponent<Rigidbody>().AddForce(interceptVec * baseForce, ForceMode.Impulse);

            Debug.Log("Hit " + collision.collider.gameObject.name + " with " + impulseApplied + " of Force");
        }
    }
}