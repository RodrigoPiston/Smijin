using UnityEngine;
 
public enum ItemType { heal, offensive, defensive, equipment }
 
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public ItemType type;
 
    public virtual void Use(){}
 
    public virtual void Drop()
    {
        Inventory.instance.RemoveItem(this);
    }
}