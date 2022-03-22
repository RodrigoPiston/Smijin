using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblin : Enemy
{
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.animator = GetComponent<Animator>();
        this.crController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckIfGrounded();
        LookAtPlayer();
        Move();
        Animate();
        Attack();
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
