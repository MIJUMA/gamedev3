using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] int actualSentenceNumber = 0;
    [SerializeField] int allSentenceNumber = 0;

    public Animator animator;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI  dialogueText;

    private Queue<string> sentences;
    private int allSentencesSize;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        ResetManager();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            allSentencesSize++;
        }

        DisplayNextSencente();
    }

    private void ResetManager()
    {
        sentences.Clear();
        allSentencesSize = 0;
    }

    public void DisplayNextSencente()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        ResetManager();
    }

    public int GetSentencesCount(SentenceNumberType type)
    {
        if (type == SentenceNumberType.Actual)
        {
            return allSentencesSize - sentences.Count; 
        }

        if (type == SentenceNumberType.All)
        {
            return allSentencesSize;
        }
        return 0;
    }
}
