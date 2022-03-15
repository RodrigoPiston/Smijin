using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 direction = new Vector3(0, 0, 1);
    [SerializeField] float speed = 2f;

    // -- Se agregan variables para emitir raycast 
    //[SerializeField] GameObject shootPoint;
    //private float distanceRay = 10f;

    //[SerializeField] float offsetX = 20f;

    //[SerializeField] bool isLeft = true;
    private GameObject player;

    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        LookAtPlayer();
        MoveTowards();
        Animate();
    }

    private void Animate()
    { 
        animator.SetBool("Walk", true); 
    }

    private void MoveTowards()
    {
        Vector3 direction = (player.transform.position - transform.position);
        if (direction.magnitude > 1)
        {
            transform.position += speed * direction.normalized * Time.deltaTime; 
        }
    }

    private void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = newRotation;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 puntob = shootPoint.transform.TransformDirection(Vector3.forward) * distanceRay;
        Gizmos.DrawRay(shootPoint.transform.position, puntob);
    }*/

}
