using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life = 10;
    [SerializeField] private float maxLife = 10;
    [SerializeField] private float energy = 10;
    [SerializeField] private float maxEnergy = 10;

    // -- Se setea el sprite 2d  del cursor en el inspector
	[SerializeField] private Texture2D crosshair; 

    private GameObject lifeBar;
    private GameObject energyBar;

    void Start()
    {
        lifeBar =  GameObject.FindWithTag("LifeBar");
        energyBar = GameObject.FindWithTag("EnergyBar");
        SetCursor();
    }

    void Update()
    {
        lifeBar.GetComponent<ProgressBar>().current = this.life;
        energyBar.GetComponent<ProgressBar>().current = this.energy;
    }

    public void Hurt(float damage){
        this.life -= damage;
        
        if(this.life <= 0){
            this.life = 0;
            PlayerDie();
        }
    }

    public void Heal(float ammount){
        this.life += ammount;
        if(this.life > maxLife){
            this.life = maxLife;
        }
    }

    public void LossEnergy(float ammount){
        this.energy -= ammount;
        if(this.energy <= 0){
            this.energy = 0;
        }
    }

    public void GainEnergy(float ammount){
        this.energy += ammount;
        if(this.energy > maxEnergy){
            this.energy = maxEnergy;
        }
    }

    private void PlayerDie(){
        Debug.Log("Murio");
    }

    private void SetCursor()
    {
        // -- Se calcula el centro del sprite 
		Vector2 cursorOffset = new Vector2(crosshair.width/2, crosshair.height/2);
     
		// -- Setea el sprite en el cursor dependiendo del offset anterior
		Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
    }

}
