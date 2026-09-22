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

    [Header("Item Info")]
    public GameObject itemInfoWindow;
    public Image itemImage;
    public Text itemName;
    public Text itemType;
    public Text itemUse;
    public Text itemDescription;

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
        DisableItemInfoWindow();

        bool isActive = !inventoryPanel.activeSelf; // Verifica se o painel de inventário está ativo
        inventoryPanel.SetActive(isActive);

        if(isActive == true)
        {
            UpdateInventory(); 
        }
    }

    public void DeleteItem(Item item)
    {
        inventory.Remove(item);
        UpdateInventory();
        DisableItemInfoWindow();
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

    public void ShowItemInfo(Item item)
    {
        itemImage.sprite = item.itemSprite;
        itemName.text = item.itemName;
        itemType.text = item.itemUse.ToString();
        itemUse.text = item.itemUseTxt;
        itemDescription.text = item.itemDescription;

        itemInfoWindow.SetActive(true);
    }

    public void DisableItemInfoWindow()
    {
        itemInfoWindow.SetActive(false);
    }

}
