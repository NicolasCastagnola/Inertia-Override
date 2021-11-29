using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public Player player;

    [SerializeField] private PoolManager poolManager;
    [SerializeField] private UIManager uIManager;
    

    public void EndGame()
    {
        Debug.Log("Clear all Entities");
        Debug.Log("Ending Current Instance of the game");
        Debug.Log("Game Ended...");
    }

    public void StartGame()
    {
        Debug.Log("Initialize Player");
        Debug.Log("Initialize all Entites");
        Debug.Log("Pool -> allPoolableObjects");
    }


    public void LoadData()
    {
        Debug.Log("Loading Data...");
    }

    public void SaveData()
    {
        Debug.Log("Saving Data...");
    }

    public void FetchData()
    {
        Debug.Log("Fetching Data...");
    }
}
