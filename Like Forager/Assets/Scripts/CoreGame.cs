using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    WOOD, COAL, IRON, STONE, FRUIT
}
public class CoreGame : MonoBehaviour
{
    public static CoreGame _instance;
    public PlayerController playerController;
    public GameManager gameManager;
    public Inventory inventory;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }


}
