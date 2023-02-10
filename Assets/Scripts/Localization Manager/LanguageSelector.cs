using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LanguageSelector : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private void OnEnable()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        PopulateList();
    }

    public void OnDropdownValueSelected()
    {
        Language selectedLanguage = (Language)dropdown.value;
        LocalizationManager.Instance.ChangeLanguage(selectedLanguage);
    }
    private void PopulateList()
    {
        string[] types = Enum.GetNames(typeof(Language));
        List<string> languages = new List<string>(types);
        dropdown.AddOptions(languages);
    }
}
