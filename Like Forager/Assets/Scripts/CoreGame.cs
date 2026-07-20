using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGame : MonoBehaviour
{
    public static CoreGame _instance;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }


}
