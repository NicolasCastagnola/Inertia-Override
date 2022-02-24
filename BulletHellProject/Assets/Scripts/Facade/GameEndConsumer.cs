using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndConsumer : MonoBehaviour
{
    public GameFacade gameFacade;

    private void Awake()
    {
        EventManager.Subscribe(EventType.Victory, OnEndGameWithVictoryCondition);
        EventManager.Subscribe(EventType.Deafeat, OnEndGameWithDefeatCondition);
    }
    private void OnDisable()
    {
        EventManager.UnSubscribe(EventType.Victory, OnEndGameWithVictoryCondition);
        EventManager.UnSubscribe(EventType.Deafeat, OnEndGameWithDefeatCondition);
    }

    public void OnEndGameWithDefeatCondition(params object[] paramerters)
    {
        gameFacade.OnPlayerDefeated();
    }

    public void OnEndGameWithVictoryCondition(params object[] paramerters)
    {
        gameFacade.OnPlayerVictory();
    }

}
