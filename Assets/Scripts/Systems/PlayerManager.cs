using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] listofPlayers;

    private MapManager mapManager;

    private LobbyVariables lobbyVariables;

    private void Start()
    {
        lobbyVariables = GameObject.FindGameObjectWithTag("LobbyVariables").GetComponent<LobbyVariables>();

        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();

        SetupPlayers();
    }

    private void SetupPlayers()
    {
        for (int i = 0; i < lobbyVariables.playersToStartGameList.Length; i++)
        {
            CreateHorn(i);       
        }
    }
    
    private void CreateHorn(int i)
    {
        listofPlayers[i].GetComponent<LlamaPlayerController>().SpawnHorn(lobbyVariables.hornToStartGameList[i]);
    }
}
