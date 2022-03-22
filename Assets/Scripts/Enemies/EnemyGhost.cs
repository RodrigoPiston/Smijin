using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    
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
