using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float interacionDistance;
    
    public GameObject actionCursor;
    [SerializeField]
    public GameObject interacionObject;

    public float timeToDelete = 3f;

    public void ActiveCursor(GameObject obj)
    {
        interacionObject = obj;

        if(Vector2.Distance(CoreGame._instance.playerController.transform.position, interacionObject.transform.position) <= interacionDistance) //
        { 
            actionCursor.transform.position = obj.transform.position;
            actionCursor.SetActive(true);
        }
    }

    public void DisableCursor()
    {
        actionCursor.SetActive(false);
        interacionObject = null;
    }

    public void ObjectHit()
    {
        if(interacionObject == null)
        {
            return; //Se não houver objeto de interação, não faz nada
        }

        if(actionCursor.activeSelf == true)
        {
            interacionObject.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void FixedUpdate()
    {
        if(interacionObject != null)
        {
            if(Vector2.Distance(CoreGame._instance.playerController.transform.position, interacionObject.transform.position) <= interacionDistance)
            {
                actionCursor.SetActive(true);
            }
            else
            {
                actionCursor.SetActive(false);
            }
        }
    }

    public void Loot(Item item, Vector3 position)
    {
        DisableCursor();

        int dir = -1;

        for(int i = 0; i < item.lootAmount; i ++)
        {
            GameObject loot = Instantiate(item.lootPrefab, position, transform.localRotation);

            loot.SendMessage("Active", dir, SendMessageOptions.DontRequireReceiver);

            dir *= -1; // Alterna a direção para espalhar os itens de loot
        }
    }

}
