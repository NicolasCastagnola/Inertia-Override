using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartConsumer : MonoBehaviour
{
    public GameFacade gameFacade;

    private void Awake()
    {
        EventManager.Subscribe(EventType.OnGameInitialization, InitializedAllEntities);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe(EventType.OnGameInitialization, InitializedAllEntities);
    }
    public void InitializedAllEntities(params object[] paramerters)
    {
        gameFacade.StartGame();
    }
}
