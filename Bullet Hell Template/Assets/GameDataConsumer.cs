using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataConsumer : MonoBehaviour, IObserver<PlayerStates>
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
                gameFacade.FetchData();
                gameFacade.LoadData();
                break;
            case PlayerStates.Die:
                gameFacade.SaveData();
                break;

        }
    }



}
