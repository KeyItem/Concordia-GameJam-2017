using System.Collections;
using UnityEngine;

public class Pitfall : MonoBehaviour 
{
    [Header("Player Respawn Attributes")]
    public Transform playerRespawnPoint;

    public float respawnTime = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<LlamaPlayerController>().Die();
        }
    }

    
}
