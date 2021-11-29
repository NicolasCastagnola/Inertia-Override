using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartConsumer : MonoBehaviour, IObserver<PlayerStates>
{
    public GameFacade gameFacade;

    private void Awake()
    {
        gameFacade.player.Subscribe(this);
    }

    public void Notification(PlayerStates action)
    {
        switch (action)
        {
            case PlayerStates.Alive:
                InitializedAllEntities();
                break;
        }
    }

    public void InitializedAllEntities()
    {
        gameFacade.StartGame();
    }
}
