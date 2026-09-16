using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    public GameObject inventoryPanel;
    public RectTransform slotGrid;
    public GameObject slotPrefab;

    private List<GameObject> inventorySlots = new List<GameObject>();

    //public Dictionary<Item, GameObject> inventorySlots = new Dictionary<Item, GameObject>();

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

    public void ShowInventory()
    {
        bool isActive = !inventoryPanel.activeSelf; // Verifica se o painel de inventário está ativo
        inventoryPanel.SetActive(isActive);

        if(isActive == true)
        {
            UpdateInventory(); 
        }
    }

    void UpdateInventory()
    {
        foreach(GameObject s in inventorySlots)
        {
            Destroy(s);
        }
        
        inventorySlots.Clear();

        foreach(KeyValuePair<Item, int> item in inventory)
        {
            GameObject i = Instantiate(slotPrefab, slotGrid);
            inventorySlots.Add(i);
            i.GetComponent<InventorySlot>().UpdateSlot(item.Key, item.Value);
        }
    }
}
