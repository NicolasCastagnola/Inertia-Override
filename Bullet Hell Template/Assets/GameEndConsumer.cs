using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndConsumer : MonoBehaviour, IObserver<PlayerStates>
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
            case PlayerStates.Die:
                EndGame();
                break;
        }
    }

    public void EndGame()
    {
        gameFacade.EndGame();
    }

}
