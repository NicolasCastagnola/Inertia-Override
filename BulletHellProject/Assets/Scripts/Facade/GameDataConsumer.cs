using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataConsumer : MonoBehaviour
{
    public GameFacade gameFacade;
    private void Awake()
    {
        EventManager.Subscribe(EventType.OnCheckpointSave, SaveCurrentCheckpoint);
        EventManager.Subscribe(EventType.OnCheckpointLoaded, LoadCurrentCheckpoint);
        EventManager.Subscribe(EventType.FetchData, OnFetchData);
        EventManager.Subscribe(EventType.LoadData, OnLoadData);
        EventManager.Subscribe(EventType.SaveData, OnSaveData);
    }

    private void OnDisable()
    {
        EventManager.UnSubscribe(EventType.OnCheckpointLoaded, LoadCurrentCheckpoint);
        EventManager.UnSubscribe(EventType.OnCheckpointSave, SaveCurrentCheckpoint);
        EventManager.UnSubscribe(EventType.FetchData, OnFetchData);
        EventManager.UnSubscribe(EventType.LoadData, OnLoadData);
        EventManager.UnSubscribe(EventType.SaveData, OnSaveData);
    }

    public void LoadCurrentCheckpoint(params object[] parameters)
    {
        gameFacade.OnCheckpointLoad();
    }
    public void SaveCurrentCheckpoint(params object[] parameters)
    {
        gameFacade.OnCheckpointSaved();
    }
    public void OnFetchData(params object[] parameters)
    {
        gameFacade.FetchData();
    }
    public void OnLoadData(params object[] parameters)
    {
        gameFacade.LoadData();
    }
    public void OnSaveData(params object[] parameters)
    {
        gameFacade.SaveData();
    }
}