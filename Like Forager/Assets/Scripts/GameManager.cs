using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject actionCursor;
    public GameObject interacionObject;

    public void ActiveCursor(GameObject obj)
    {
        actionCursor.transform.position = obj.transform.position;
        actionCursor.SetActive(true);
        interacionObject = obj;
    }

    public void DisableCursor()
    {
        actionCursor.SetActive(false);
        interacionObject = null;
    }

    public void ObjectHit()
    {
        
    }

}
