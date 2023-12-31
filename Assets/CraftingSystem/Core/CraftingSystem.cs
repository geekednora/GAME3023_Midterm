﻿using System;
using System.Collections.Generic;
using CraftingSystem.Demo.Scripts;
using CraftingSystem.Demo.Scripts.InventorySystem;
using UnityEngine;

namespace CraftingSystem.Core
{
    public class CraftingSystem : MonoBehaviour
    {
        [SerializeField] private ItemSlot[] _CraftingSlots;
        [SerializeField] private ItemSlot _ResultSlot;
        
        private RecipeLoader _recipeLoader;
        
        private void Start()
        {
            DraggingHandler draggingHandler = FindObjectOfType<DraggingHandler>();
            draggingHandler.OnItemDropped += OnItemDropped;
            
            _recipeLoader = FindObjectOfType<RecipeLoader>();
        }

        private void OnItemDropped(ItemSlot obj)
        {
            if (obj == _ResultSlot)
            {
                CraftItem();
                CheckCraftingSlots();
            }
            else
            {
                CheckCraftingSlots();
            }
            
        }

        private void CheckCraftingSlots()
        {
            List<Item> items = new List<Item>();

            foreach (var craftingSlot in _CraftingSlots)
                items.Add(craftingSlot.Item);


            Item item = _recipeLoader.CheckGridState(items.ToArray(), new Vector2Int(3, 3), out var resultCount);
            if (item != null)
            {
                _ResultSlot.Count = resultCount;
                _ResultSlot.Item = item;
                Debug.Log("Crafted item: " + item.name);
                Debug.Log("Crafted item count: " + resultCount);
            }
            else
            {
                
                _ResultSlot.Count = 0;
                _ResultSlot.Item = null;
            
            }
        }

        private void CraftItem()
        {
            foreach (var craftingSlot in _CraftingSlots)
            {
                craftingSlot.Count -= 1;
            }
        }
    }
}