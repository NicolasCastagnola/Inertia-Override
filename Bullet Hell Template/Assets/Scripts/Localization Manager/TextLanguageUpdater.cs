using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextLanguageUpdater : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public string ID;

    private void Start()
    {
        LocalizationManager.Instance.OnUpdate += OnLanguageChanged;
    }
    
    private void OnEnable()
    {
        if (LocalizationManager.Instance != null) OnLanguageChanged();
    }

    void OnLanguageChanged()
    {
        myText.GetComponent<TextMeshProUGUI>();
        myText.text = LocalizationManager.Instance.GetTranslate(ID);
    }
}
