using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private CharacterStatus playerStatus;
    public static PlayerStatusManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void UpdateCharacterStatus(Equipment newItem, Equipment oldItem)
    {
        if (oldItem != null)
        {
            playerStatus.str -= oldItem.strengthModifier;
            playerStatus.def -= oldItem.defenseModifier;
            playerStatus.mgc -= oldItem.magicModifier;
            playerStatus.mgcdef -= oldItem.magicdefenseModifier;
        }
        playerStatus.str = playerStatus.basestr + newItem.strengthModifier;
        playerStatus.def = playerStatus.basedef + newItem.defenseModifier;
        playerStatus.mgc = playerStatus.basemgc + newItem.magicModifier;
        playerStatus.mgcdef = playerStatus.basemgcdef + newItem.magicdefenseModifier;
    }
}