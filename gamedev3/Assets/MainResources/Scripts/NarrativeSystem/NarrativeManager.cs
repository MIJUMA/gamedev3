using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public NarrativePanel narrativePanel;
    public AudioSource narrativeAudio;


    public void StopPanel()
    {
        narrativePanel.ResetPanel();
    }
    public void StartNarrative(Narrative narrative)
    {
        ResetManager();
        
        if (narrative.GetImage() != null)
        {
            PlayImage(narrative.GetImage());
        }
        if (narrative.GetDialogue() != null)
        {
            PlayDialogue(narrative.GetDialogue(), narrative.GetImage() != null);
        }
       
    }

    private void PlayDialogue(Dialogue dialogue, bool hasImage)
    {
        dialogueManager.SetAutomaticImagePanelClose(hasImage);
        dialogueManager.StartDialogue(dialogue);
    }

    private void PlayImage(Sprite image)
    {
        narrativePanel.StartPanel(image);
    }

    private void ResetManager()
    {
        narrativeAudio.Stop();
        narrativeAudio.clip = null;

        narrativePanel.ResetPanel();
    }

    private void PlayAudio(AudioClip audioClip)
    {
        narrativeAudio.clip = audioClip;
        narrativeAudio.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        //dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
