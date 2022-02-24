using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IRewindable
{
    [SerializeField] UIManager uiManager;
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    MementoState memento;

    public int currentPoints;

    void Awake()
    {
        memento = new MementoState();
        
        _instance = this;
    }

    public void EvaluteNewHighscore()
    {
        if (currentPoints > PlayerPrefs.GetInt("highscore")) SetNewHighscore();

        else uiManager.SetHighscoreFlagStatus(false);
    }

    public void SetNewHighscore()
    {
        PlayerPrefs.SetInt("highscore", currentPoints);
        uiManager.SetHighscoreFlagStatus(true);
    }

    public void AddScore(int amount)
    {
        currentPoints += amount;
        uiManager.RefreshCurrentPoints(currentPoints);
    }

    public void Action()
    {
        if (memento.MemoriesQuantity() <= 0)
            return;

        OnRewind(memento.Remember());
    }

    public void SaveMementoParamerters()
    {
        memento.Rec(currentPoints);
    }

    public void OnRewind(ParamsMemento wrappers)
    {
        currentPoints = (int)wrappers.parameters[0];
        uiManager.RefreshCurrentPoints(currentPoints);
    }
}
