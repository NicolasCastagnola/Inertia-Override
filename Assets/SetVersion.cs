using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetVersion : MonoBehaviour
{
    private void Awake() => GetComponent<TMP_Text>().text = $"Ver. {Application.version}";
}
