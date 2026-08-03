using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float interacionDistance;
    
    public GameObject actionCursor;
    [SerializeField]
    public GameObject interacionObject;

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

        GameObject l = null;
        int dir = -1;

        //for(int i ==)
    }

}
