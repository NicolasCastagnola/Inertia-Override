using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }

    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;


        EventManager.Subscribe(EventType.FetchData, FetchData);
        EventManager.Subscribe(EventType.LoadData, LoadData);
        EventManager.Subscribe(EventType.SaveData, SaveData);
    }

    public void LoadData(params object[] parameters)
    {
        Debug.Log("Loading Data...");
        //Pull & modify current csv
    }

    public void SaveData(params object[] parameters)
    {
        Debug.Log("Saving Data...");
        //modidy current csv and/or push to DB
    }

    public void FetchData(params object[] parameters)
    {
        Debug.Log("Fetching Data...");
        //Fetch csv from api/www -> LoadData();
    }
}
