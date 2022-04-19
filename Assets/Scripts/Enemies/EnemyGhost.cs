using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    [SerializeField] private AbilityHolder ability;
    [SerializeField] private float minPlayerDistance = 16f;
    private float currPlayerDistance;

    void Start()
    {
        this.player = GameObject.Find("Player");
        this.crController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 v3PlayerDistance = player.transform.position - transform.position;
        currPlayerDistance = v3PlayerDistance.magnitude;

        if (currPlayerDistance <= minPlayerDistance)
        {
            LookAtPlayer();
            Move();
            Attack();
        }
        else
        {
            base.WayPoint_Movement();
        }
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
        if (moveDirection.magnitude > 1 && moveDirection.magnitude < detectionRange)
        {
            crController.Move(speed * moveDirection.normalized * Time.deltaTime);
        }
        else if (moveDirection.magnitude > 10 && moveDirection.magnitude < 11)
        {
            Attack(); 
        }
    }

}
