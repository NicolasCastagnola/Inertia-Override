using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public Player player;

    [SerializeField] private BulletPoolManager bulletPoolManager;
    [SerializeField] private CheckpointManager checkpointManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private HostileEntitiesManager entitiesManager;

    public void OnPlayerVictory()
    {
        gameManager.EvaluteNewHighscore();
        uIManager.ShowVictoryScreen();
        ClearScene();
    }
    public void OnPlayerDefeated()
    {
        uIManager.ShowDeathScreen();
        ClearScene();
    }
    public void OnCheckpointSaved()
    {
        checkpointManager.Memento();
        uIManager.hasCheckpointFlag = true;
    }
    public void OnCheckpointLoad()
    {
        checkpointManager.Rewind();
        ClearScene();
    }
    public void ClearScene()
    {
        entitiesManager.ClearAllEntitesInSceneAndStopFactory();
        Debug.Log("Clear all Entities");
        Debug.Log("Ending Current Instance of the game");
        Debug.Log("Game Ended...");

        EventManager.TriggerEvent(EventType.SaveData);
    }

    public void StartGame()
    {
        EventManager.TriggerEvent(EventType.FetchData);
        EventManager.TriggerEvent(EventType.LoadData);

        Debug.Log("Initialize Player");
        Debug.Log("Initialize all Entites");
        Debug.Log("Pool all Poolable Objects");
    }

    public void LoadData()
    {
        Debug.Log("Loading Data...");
        uIManager.highscorePoints.text = PlayerPrefs.GetInt("highscore").ToString("000000000000"); 
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
