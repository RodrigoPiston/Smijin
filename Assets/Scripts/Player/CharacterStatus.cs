using UnityEngine;
 
[CreateAssetMenu(fileName = "HealthStatusData", menuName = "StatusObjects/Health", order = 1)]
public class CharacterStatus : ScriptableObject
{
    public string charName = "name";
    public int level      = 1;
    public int baseMaxHp  = 0;
    public int baseMaxMp  = 0;
    public int baseHp     = 0;
    public int baseMp     = 0;
    public int baseStrength    = 0;
    public int baseDefense    = 0;
    public int baseMagic       = 0;
    public int baseMagicDefense = 0;
    public int maxHp      = 0;
    public int maxMp      = 0;
    public int hp         = 0;
    public int mp         = 0;
    public int strength   = 0;
    public int defense   = 0;
    public int magic      = 0;
    public int magicDefense     = 0;
}