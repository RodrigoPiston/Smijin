 
using UnityEngine;

public enum EquipType { HAND, HEAD, NECK, TORSO, FINGERS }
 
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipType equipType;
 
    public int strengthModifier;
    public int defenseModifier;
    public int magicModifier;
    public int magicdefenseModifier;
 
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.RemoveItem(this);
    }
}