using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon",menuName = "Weapons/Weapon",order = 1)]
public class WeaponDefinition : ScriptableObject
{
    public enum WeaponFireMode {AUTO, SEMIAUTO, BURST}

    [Header ("Basic Weapon Traits")]
    public GameObject projectilePrefab;
    public float projectileVelocity = 10f;
    public float weaponKickIntesity = 0.1f;
    public float weaponScreenShake  = 1.0f;
    public float fireSpreadAngle = 30f;
    public float numProjectilesToFire = 1f;

    [Tooltip ("Only has an effect if the current weapon is set to the auto fire mode")]
    public float fireRate = 0.2f;

}
