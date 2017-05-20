using System.Collections;
using UnityEngine;

public class DebugCommands : MonoBehaviour
{
    [Header("Debug Attributes")]
    public GameObject[] listOfPlayers;

    private void Update()
    {
        GetDebugInputs();
    }

    private void GetDebugInputs()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            DecreaseTimeStep();
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            IncreaseTimeStep();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayers();
        }
    }

    private void ResetPlayers()
    {
        foreach(GameObject player in listOfPlayers)
        {
            player.transform.position = Vector3.zero + Vector3.up;
        }

        Debug.Log("Resetting Players To Origin");
    }

    private void IncreaseTimeStep()
    {
        if (Time.timeScale < 4.5f)
        {
            Time.timeScale += 0.5f;

            Debug.Log("Increasing Game Timescale to :: " + Time.timeScale);
        }
    }

    private void DecreaseTimeStep()
    {
        if (Time.timeScale > 0.5f)
        {
            Time.timeScale -= 0.5f;

            Debug.Log("Decreasing Game Timescale to :: " + Time.timeScale);
        }
    }
}
