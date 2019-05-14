using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public NarrativeManager narrativeManager;
    public Character character;

    public ResultAction[] initialActions;
    private Queue<ResultAction> resultActionsQueue;
    private bool actionsStarted = false;
    private ResultAction actualAction;
    public Item[] keyItems;

    private bool cupPickedNarrative = false;
    private bool inventoryFirstTimeOpened = false;
    private bool firstItemCrafted = false;
    private bool lastItemCrafted = false;

    // Start is called before the first frame update
    void Start()
    {
        resultActionsQueue = new Queue<ResultAction>();

        PushAction(initialActions[0]);
        DoActions();
    }


    public void PushAction(ResultAction action)
    {
        
            resultActionsQueue.Enqueue(action);
        
    }

    
    public void DoActions()
    {
        
        while (resultActionsQueue.Count > 0)
        {
            this.actualAction = resultActionsQueue.Dequeue();
            this.actualAction.ExecuteAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (character.GetInventoryItems().Contains(keyItems[0]) && !cupPickedNarrative)
        {
            PushAction(initialActions[1]);
            DoActions();
            cupPickedNarrative = true;
        }

        if (character.isActiveAndEnabled && !inventoryFirstTimeOpened)
        {
            PushAction(initialActions[2]);
            DoActions();
            inventoryFirstTimeOpened = true;
        }

        if (character.GetStatsRecipes().Count > 0 
            && !firstItemCrafted)
        {
            for (int i = 0; i < character.GetStatsRecipes().Count; i++)
            {
                if (character.GetStatsRecipes()[i].resultProduct == keyItems[1])
                {
                    PushAction(initialActions[3]);
                    DoActions();
                    firstItemCrafted = true;
                }
            }
        }

        if (character.GetStatsRecipes().Count > 0 && !lastItemCrafted)
        {
            for (int i = 0; i < character.GetStatsRecipes().Count; i++)
            {
                if (character.GetStatsRecipes()[i].resultProduct == keyItems[2])
                {
                    PushAction(initialActions[4]);
                    DoActions();
                    lastItemCrafted = true;
                }
            }
        }

    }
}
