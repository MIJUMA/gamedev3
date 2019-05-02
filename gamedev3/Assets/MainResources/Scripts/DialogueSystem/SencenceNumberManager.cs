using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SencenceNumberManager : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        if (dialogueManager.GetSentencesCount(SentenceNumberType.All) == 0)
        {
            TextMeshProUGUI[] allChildRenderers = GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI T in allChildRenderers)
                T.enabled = false;
        }
        else
        {
            TextMeshProUGUI[] allChildRenderers = GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI T in allChildRenderers)
                T.enabled = true;
        }
    }

    private void Update()
    {
        Refresh();
    }
}
