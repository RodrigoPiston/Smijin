using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     // Start is called before the first frame update
    [SerializeField] float life = 10;
    [SerializeField] float maxLife = 10;
    [SerializeField] float energy = 10;
    [SerializeField] float maxEnergy = 10;

    
    private GameObject lifeBar;
    private GameObject energyBar;

    // Start is called before the first frame update
    void Start()
    {
        lifeBar =  GameObject.FindWithTag("LifeBar");
        energyBar = GameObject.FindWithTag("EnergyBar");
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.GetComponent<ProgressBar>().current = (int)this.life;
        energyBar.GetComponent<ProgressBar>().current = (int)this.energy;
    }

    public void Hurt(int damage){
        this.life -= damage;
        
        if(this.life <= 0){
            this.life = 0;
            PlayerDie();
        }
    }

    public void Heal(int ammount){
        this.life += ammount;
        if(this.life > maxLife){
            this.life = maxLife;
        }
    }

    public void LossEnergy(int ammount){
        this.energy -= ammount;
        if(this.energy <= 0){
            this.energy = 0;
        }
    }

    public void GainEnergy(int ammount){
        this.energy += ammount;
        if(this.energy > maxEnergy){
            this.energy = maxEnergy;
        }
    }
    private void PlayerDie(){
        Debug.Log("Murio");
    }

}
