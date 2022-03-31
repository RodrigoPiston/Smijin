using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected int soulsDrop = 1;
    [SerializeField] protected float detectionRange = 10f;
    [SerializeField] protected float attackRange = 5f;
    [SerializeField] protected CharacterStatus characterStatus;

    protected bool isGrounded;
    protected float vSpeed;
    protected Vector3 moveDirection;
    protected Animator animator; 
    protected GameObject player;
    protected CharacterController crController;
    protected float velocityZ;
    protected float velocityX;
    private float gravity = -9.8f;
  
    public virtual void Deffend(){}
    
    public virtual void Move(){
        moveDirection = (player.transform.position - transform.position);
        if (moveDirection.magnitude > 1 && moveDirection.magnitude < detectionRange)
        {
            crController.Move(speed * moveDirection.normalized * Time.deltaTime);
        }
    }

    public virtual void LookAtPlayer(){
        if (moveDirection.magnitude > 1 && moveDirection.magnitude < detectionRange)
        {
            Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = newRotation;
        }
    }

    public virtual void Attack(){
        moveDirection = (player.transform.position - transform.position);
        if (moveDirection.magnitude < this.attackRange){
            Debug.Log($"{this.GetType()} atacando a player");
        }
    }

    public virtual void Animate(){
        velocityZ = Vector3.Dot(moveDirection.normalized, transform.forward);
        velocityX = Vector3.Dot(moveDirection.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }

    public virtual void CheckIfGrounded(){
        this.isGrounded = this.crController.isGrounded;
        if (this.isGrounded && moveDirection.y < 0)
        {
            vSpeed = 0f;
        }
    }

    public virtual void ApplyGravity()
    {
        vSpeed += gravity *Time.deltaTime;
    }
}
