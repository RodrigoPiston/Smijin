using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponBuff",menuName = "Weapons/WeaponBuff",order = 2)]
public class WeaponBuff : ScriptableObject
{

    public float fireRate;
    public float weaponAccuracy;
    public float projectileDamage;
    public float projectileVelocity;

}
