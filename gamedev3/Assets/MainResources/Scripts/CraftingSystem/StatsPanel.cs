using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] Transform statPanelParent;
    [SerializeField] string[] statNames;
    [SerializeField] StatDisplay[] statDisplays;
    private CharacterStat[] characterStats;
    private CraftingRecipe[] craftedRecipes;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        //UpdateCharacterStatNames();
    }

    
    //public void SetCharacterStats(params CharacterStat[] charStats)
    //{
    //    characterStats = charStats;
    //
     //   if (characterStats.Length > statDisplays.Length)
    //    {
    //        Debug.LogError("Not Enough Stat Displays");
    //        return;
    //    }
    //
    //    for (int i = 0; i < statDisplays.Length; i++)
    //    {
    //        statDisplays[i].gameObject.SetActive(i < characterStats.Length);
    //    } 
    //}

    

    public void SetCharacterRecipes(List<CraftingRecipe> recipes)
    {
        craftedRecipes = recipes.ToArray();

        if (craftedRecipes.Length > statDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            if (i < craftedRecipes.Length)
            {
                statDisplays[i].gameObject.SetActive(true);
                statDisplays[i].StatNameText.text = GenerateStatName(craftedRecipes[i]);
                statDisplays[i].StatValueText.text = "Crafted";
            }
            else
            {
                statDisplays[i].gameObject.SetActive(false);
            }
        }
    }

    private String GenerateStatName(CraftingRecipe recipe)
    {
        string res = "Item: ";
        foreach (ItemAmount itemAmount in recipe.Materials)
        {
            res += itemAmount.Item.ItemName + ", ";
        }
        return res;
    }

    public void UpdateCharacterStatValues()
    {
        for (int i = 0; i < characterStats.Length; i++)
        {
            statDisplays[i].StatValueText.text = characterStats[i].Value.ToString();
        }
    }

    public void UpdateCharacterStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statDisplays[i].StatNameText.text = statNames[i];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCharacterRecipes(new List<CraftingRecipe>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
