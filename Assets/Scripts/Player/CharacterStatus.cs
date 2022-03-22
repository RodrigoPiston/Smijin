using UnityEngine;
 
[CreateAssetMenu(fileName = "HealthStatusData", menuName = "StatusObjects/Health", order = 1)]
public class CharacterStatus : ScriptableObject
{
    public string charName = "name";
    public int level      = 1;
    public int basemaxhp  = 0;
    public int basemaxmp  = 0;
    public int basehp     = 0;
    public int basemp     = 0;
    public int basestr    = 0;
    public int basedef    = 0;
    public int basemgc    = 0;
    public int basemgcdef = 0;
    public int maxhp      = 0;
    public int maxmp      = 0;
    public int hp         = 0;
    public int mp         = 0;
    public int str        = 0;
    public int def        = 0;
    public int mgc        = 0;
    public int mgcdef     = 0;
}