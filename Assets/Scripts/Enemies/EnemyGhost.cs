using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    [SerializeField] private AbilityHolder ability;
    
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.crController = GetComponent<CharacterController>();
    }

    void Update()
    {
        LookAtPlayer();
        Move();
        Attack();
    }

    public override void Animate()
    {
        base.Animate();
    }

    public override void Attack()
    {
        Debug.Log("Atacando al player");
        //ability.execute = true;
    }

    public override void Deffend()
    {
        base.Deffend();
    }

    public override void LookAtPlayer()
    {
        base.LookAtPlayer();
    }

    public override void Move()
    {
        moveDirection = (player.transform.position - transform.position);
        if (moveDirection.magnitude > 10 && moveDirection.magnitude < detectionRange)
        {
            crController.Move(speed * moveDirection.normalized * Time.deltaTime);
        }else if(moveDirection.magnitude > 10 && moveDirection.magnitude < 11){
            Attack();
        }
    }

}
