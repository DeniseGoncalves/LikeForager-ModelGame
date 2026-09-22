using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Item item;
    public Image itemImage;
    public Text amountTxt;
    [SerializeField] private  bool isDelete;

    public Image deleteBar;

    private float deltatime;
    private float perc;
   
   private void Update()
    {
        if(isDelete == true)
        {
            deltatime += Time.deltaTime;

            perc = deltatime / CoreGame._instance.gameManager.timeToDelete;
            deleteBar.fillAmount = perc;

            if(deltatime >= CoreGame._instance.gameManager.timeToDelete)
            {
                CoreGame._instance.inventory.DeleteItem(item);
            }
        }
    }

   public void UpdateSlot(Item i, int amount)
    {
        deleteBar.gameObject.SetActive(false);
        item = i;
        itemImage.sprite = item.itemSprite;
        amountTxt.text = amount.ToString();
    }

    public void OnSlotClick(BaseEventData data) // Função para verificar se o item é consumível ou não
    {
        PointerEventData pointerData = data as PointerEventData;

        if(pointerData.button == PointerEventData.InputButton.Left)
        {
            //Botão esquerdo do mouse
            print("Esquerdo");
        }

        if(pointerData.button == PointerEventData.InputButton.Right)
        {
            //Botão direito do mouse
            print("Direito");
            isDelete = true;
            deltatime = 0f;
            deleteBar.fillAmount = 0.1f;
            deleteBar.gameObject.SetActive(true);
        }
    }

    public void OnSlotUp (BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;

         if(pointerData.button == PointerEventData.InputButton.Right)
        {
            isDelete = false;
            deleteBar.gameObject.SetActive(false);
        }
    }

    public void MouseEnter()
    {
        CoreGame._instance.inventory.ShowItemInfo(item);
    }

    public void MouseExit()
    {
        CoreGame._instance.inventory.DisableItemInfoWindow();
        isDelete = false;
    }
}
