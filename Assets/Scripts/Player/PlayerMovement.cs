using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] public float speed = 6f;
    [SerializeField] float angleRotation = 45;
    [SerializeField] float turnSmoothTime = 0.1f;
    private CharacterController crPlayer;
    private Vector3 target;
    private Vector3 moveDirection;
	private Animator animator;
    private Ray ray;
    private float gravity = 9.85f;
    private float velocityZ;
    private float velocityX;
    void Start(){
        crPlayer = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();
        ApplyGravity();
        Animate();
    }

    private void ApplyGravity()
    {
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private void Animate()
    {
        velocityZ = Vector3.Dot(moveDirection.normalized, transform.forward);
        velocityX = Vector3.Dot(moveDirection.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            // -- Se corrije la dirección del player con la rotación de la camara para que respete el horizontal/vertical
            moveDirection = Quaternion.Euler(0, cameraPlayer.gameObject.transform.eulerAngles.y, 0) * moveDirection;
            moveDirection.Normalize();
            crPlayer.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}
