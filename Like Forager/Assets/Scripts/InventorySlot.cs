using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Item item;
    public Image itemImage;
    public Text amountTxt;
   
   public void UpdateSlot(Item i, int amount)
    {
        item = i;
        itemImage.sprite = item.itemSprite;
        amountTxt.text = amount.ToString();
    }

    public void OnSlotClick() // Função para verificar se o item é consumível ou não
    {
        
    }

    public void MouseEnter()
    {
        CoreGame._instance.inventory.ShowItemInfo(item);
    }

    public void MouseExit()
    {
        CoreGame._instance.inventory.DisableItemInfoWindow();
    }
}
