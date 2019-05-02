using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum SentenceNumberType
{
    Actual,
    All
}

public class NumberScript : MonoBehaviour
{
    public DialogueManager dialogueManager;
    [SerializeField] SentenceNumberType type;

    private TextMeshProUGUI textPro;

    // Start is called before the first frame update
    void Start()
    {
        textPro = this.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textPro.text = dialogueManager.GetSentencesCount(type).ToString();
    }
}
