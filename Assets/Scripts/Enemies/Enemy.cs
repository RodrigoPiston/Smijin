using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 2f; 
    [SerializeField] protected int soulsDrop = 1;
    [SerializeField] protected float detectionRange = 5f;
    [SerializeField] protected float attackRange = 5f;
    [SerializeField] protected int hp;
    [SerializeField] protected CharacterStatus characterStatus;
    //[SerializeField] protected string wayPointContainerName;

    // -- Se declaran los waypoints
    Transform[] wayPoints;
    public string wayPointName;

    private int currentIndex = 0;
    private int minDistance = 1;
    private bool goBack;
    //private float rotationSpeed = 10;

    protected bool isGrounded;
    protected float vSpeed;
    protected Vector3 moveDirection;
    protected Animator animator; 
    protected GameObject player;
    protected CharacterController crController; 
    protected float velocityZ; 
    protected float velocityX;
    private float gravity = -9.8f;

    void Awake()
    {
        if (this.gameObject.name != "CegadorAlmas") 
        {
            wayPointName = GetComponentInParent<LowEnemyGenerator>().GetWayPointName();
            WayPointMovement waypointContainer = GameObject.Find(wayPointName).gameObject.GetComponent<WayPointMovement>();
            wayPoints = waypointContainer.GetWayPoints(); 
        }
    }

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
            //Debug.Log($"{this.GetType()} atacando a player");
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

    public virtual void WayPoint_Movement()
    {
        Vector3 deltaVector = wayPoints[currentIndex].transform.position - transform.position;
        
        moveDirection = deltaVector.normalized;
 
        crController.Move(moveDirection * speed * Time.deltaTime);

        // -- Hace mirar al prefab hacia la dirección del waypoint
        transform.LookAt(wayPoints[currentIndex]);

        if (deltaVector.magnitude <= minDistance)
        {
            if (currentIndex >= wayPoints.Length - 1)
            {
                goBack = true;
            }
            else if (currentIndex <= 0)
            {
                goBack = false;
            }

            if (goBack) 
            {
                currentIndex--;
            }
            else
            {
                currentIndex++;
            }
        }
    }
}
