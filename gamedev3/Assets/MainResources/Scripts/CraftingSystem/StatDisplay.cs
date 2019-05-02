using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    public TextMeshProUGUI StatNameText;
    public TextMeshProUGUI StatValueText;

    private void OnValidate()
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        StatNameText = texts[0];
        StatValueText = texts[1];
    }
}
