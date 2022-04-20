using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private CharacterStatus characterStatus;
    public static PlayerStatusManager instance;
    private GameObject lifeBar;
    private GameObject energyBar;
    private DeathController deathController;
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
        characterStatus.hp = characterStatus.baseHp;
        deathController = new DeathController();
    }

    public void UpdateCharacterStatusItem(Equipment newItem, Equipment oldItem)
    {
        if (oldItem != null)
        {
            characterStatus.strength -= oldItem.strengthModifier;
            characterStatus.defense -= oldItem.defenseModifier;
            characterStatus.magic    -= oldItem.magicModifier;
            characterStatus.magicDefense -= oldItem.magicdefenseModifier;
        }
        characterStatus.strength = characterStatus.baseStrength + newItem.strengthModifier;
        characterStatus.defense = characterStatus.baseDefense + newItem.defenseModifier;
        characterStatus.magic = characterStatus.baseMagic + newItem.magicModifier;
        characterStatus.magicDefense = characterStatus.baseMagicDefense + newItem.magicdefenseModifier;
    }

    public void UpdateCharacterStatusLife(int ammount)
    {
        characterStatus.hp += ammount;
        if(characterStatus.hp <= 0)
        {
            // deathController.LoadDeathScreen(true);
            Debug.Log("Estas muerto");
        }
    }

    public void UpdateCharacterStatusMana(int ammount)
    {
        characterStatus.mp += ammount;
    }

    void Start()
    {
        lifeBar =  GameObject.FindWithTag("LifeBar");
        energyBar = GameObject.FindWithTag("EnergyBar");
    }

    void Update()
    {
        lifeBar.GetComponent<ProgressBar>().current = (int)this.characterStatus.hp;
        energyBar.GetComponent<ProgressBar>().current = (int)this.characterStatus.mp;
    }

}