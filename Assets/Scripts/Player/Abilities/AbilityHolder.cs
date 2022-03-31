using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AbilityState{ READY, ACTIVE, COOLDOWN}

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;

    AbilityState state = AbilityState.READY;
    public KeyCode key;
    public bool execute = false;

    public void Update()
    {
        switch (state)
        {
            case AbilityState.READY:
                if(Input.GetKeyDown(key) || execute){
                    ability.Activate(gameObject.transform.parent.gameObject);
                    state = AbilityState.ACTIVE;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.ACTIVE:
                if(activeTime > 0){
                    activeTime -= Time.deltaTime;
                }else{
                    ability.BeginCooldown(gameObject.transform.parent.gameObject);
                    state = AbilityState.COOLDOWN;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.COOLDOWN:
                if(cooldownTime > 0){
                    cooldownTime -= Time.deltaTime;
                }else{
                    state = AbilityState.READY;
                }
                break;
        }
    }
}
