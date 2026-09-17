using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptable/Item", order = 1)]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public ItemUse itemUse;
    public int hitAmount;
    public string itemName;
    public Sprite itemSprite;
    [TextArea(1,4)]
    public string itemDescription;
    public string itemUseTxt;
    public GameObject lootPrefab;
    public int lootAmount;
}
