using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLaunchAllDialogues : MonoBehaviour
{
    private DialogueTrigger[] dialogueTriggers;
    private int i = 0;

    private void Start()
    {
         dialogueTriggers = GameObject.Find("DialogueTriggers").GetComponentsInChildren<DialogueTrigger>();
    }

    public void StartAll()
    {
        if (dialogueTriggers[i] != null)
        {
            dialogueTriggers[i].TriggerDialogue();
            i++;
        }
       
    }
}
