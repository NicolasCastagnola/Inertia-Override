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
        if (LocalizationManager.Instance) LocalizationManager.Instance.OnUpdate += OnLanguageChanged;
    }
    private void OnDestroy()
    {
        if (LocalizationManager.Instance) LocalizationManager.Instance.OnUpdate -= OnLanguageChanged;
    }
    private void OnEnable()
    {
        if (LocalizationManager.Instance != null) OnLanguageChanged();
    }

    void OnLanguageChanged()
    {
        if (myText != null)
        {
            myText.text = LocalizationManager.Instance.GetTranslate(ID);
        }
    }
}