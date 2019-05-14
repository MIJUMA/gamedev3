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

    public AudioSource audioSource;
    public Animator animator;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI  dialogueText;

    private Queue<string> sentences;
    private AudioClip[] sentencesClips;
    private int allSentencesSize;
    private int actualSentence = 0;
    private bool dialogueEnded = true;
    private bool closeAfterDone;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void SetAutomaticImagePanelClose(bool cond)
    {
        this.closeAfterDone = cond;
    }

    public bool IsDialogueDone()
    {
        return dialogueEnded;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        dialogueEnded = false;
        ResetManager();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            allSentencesSize++;
        }
        sentencesClips = dialogue.sentencesClips;

        DisplayNextSencente();
    }

    private void PlayNarrative(AudioClip narrativeAudio)
    {
        audioSource.clip = narrativeAudio;
        if (narrativeAudio != null)
        {
            audioSource.Play();
        }
    }

    private void ResetManager()
    {
        sentences.Clear();
        audioSource.clip = null;
        allSentencesSize = 0;
        actualSentence = 0;
    }

    public void DisplayNextSencente()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        AudioClip sentenceClip = null;
        if (actualSentence < sentencesClips.Length)
        {
            sentenceClip = sentencesClips[actualSentence];
        }
        actualSentence++;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, sentenceClip));
    }

    IEnumerator TypeSentence (string sentence, AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
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
        dialogueEnded = true;
        audioSource.Stop();
        if (closeAfterDone)
        {
            FindObjectOfType<NarrativeManager>().StopPanel();
        }
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
