using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public Inventory inventory;
    
    public List<CraftingRecipe> craftingRecipes;
    public ItemSlot outputSlot;
    
    public void CraftItem(string itemName)
    {
        CraftingRecipe recipe = GetRecipeByName(itemName);

        if (recipe != null)
        {
            // Consume ingredients
            foreach (var ingredient in recipe.ingredients)
            {
                //ItemSlot.RemoveItem(ingredient.itemName, ingredient.amount);
            }

            // Add crafted item to the inventory
            inventory.AddItem(itemName, 1);

            Debug.Log("Crafted: " + itemName);
        }
        else
        {
            Debug.Log("Cannot craft: " + itemName);
        }
    }

    private CraftingRecipe GetRecipeByName(string itemName)
    {
        return craftingRecipes.Find(recipe => recipe.resultItemName == itemName);
    }
}
