using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    private float minPlayerDistance = 16f, currPlayerDistance;

    void Start()
    {
        this.player = GameObject.Find("Player");
        this.animator = GetComponent<Animator>();
        this.crController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckIfGrounded();

        Vector3 v3PlayerDistance = player.transform.position - transform.position;
        currPlayerDistance = v3PlayerDistance.magnitude;

        if (currPlayerDistance<= minPlayerDistance)
        {
            LookAtPlayer();
            Move();
            Attack();
        }
        else
        {   
            base.WayPoint_Movement();
        }
        Animate();        
    }

    public override void CheckIfGrounded()
    {
        base.CheckIfGrounded();
    }

    public override void Animate()
    {
        base.Animate();
    }

    public override void Attack()
    {
        base.Attack();
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
        base.Move();
    }
}
