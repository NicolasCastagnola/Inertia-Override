using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get { return _instance; } }
    private static LocalizationManager _instance;

    public Language selectedLanguage;

    private string externalURL = "https://drive.google.com/uc?export=download&id=1Pq0D4MSdNIjpiQ-dXMPntkA32q6jazTk";

    public Dictionary<Language, Dictionary<string, string>> languageContainer = new Dictionary<Language, Dictionary<string, string>>();

    public event Action OnUpdate;


    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;

        DontDestroyOnLoad(this);

        StartCoroutine(DownloadCSV(externalURL));
    }

    public void ChangeLanguage(Language language)
    {
        selectedLanguage = language;
        OnUpdate?.Invoke();
    }

    public string GetTranslate(string id)
    {
        if (!languageContainer[selectedLanguage].ContainsKey(id))
            return $"The Language Container does not contains language with id {id}";
        else
            return languageContainer[selectedLanguage][id];
    }

    public IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        languageContainer = LanguageU.LoadCodex(www.downloadHandler.text);

        OnUpdate?.Invoke();
    }
}

