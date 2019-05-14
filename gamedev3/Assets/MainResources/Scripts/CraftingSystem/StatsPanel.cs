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
    private List<CraftingRecipe> craftedRecipes = new List<CraftingRecipe>();

    public List<CraftingRecipe> GetCraftedRecipes()
    {
        return craftedRecipes;
    }

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        //UpdateCharacterStatNames();
    }

    public void SetCharacterRecipes(List<CraftingRecipe> recipes)
    {
        craftedRecipes = recipes;

        if (craftedRecipes.Count > statDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            if (i < craftedRecipes.Count)
            {
                statDisplays[i].gameObject.SetActive(true);
                statDisplays[i].StatNameText.text = GenerateStatName(craftedRecipes[i]);
                statDisplays[i].StatValueText.text = craftedRecipes[i].progressActionName;
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
