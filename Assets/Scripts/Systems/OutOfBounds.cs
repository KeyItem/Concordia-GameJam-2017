using System.Collections;
using UnityEngine;

public class OutOfBounds : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Vector3.zero + Vector3.up;
        }
    }
}
