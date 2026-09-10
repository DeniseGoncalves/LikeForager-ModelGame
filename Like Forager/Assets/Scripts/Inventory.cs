using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public void GetItem(Item item, int amount)
    {
        if(inventory.ContainsKey(item)) // Se já existir o item no inventário, atualiza a quantidade
        {
            inventory[item] += amount; 
        }
        else // Se não existir, adiciona o item ao inventário
        {
            inventory.Add(item, amount);
        }

    }
}
