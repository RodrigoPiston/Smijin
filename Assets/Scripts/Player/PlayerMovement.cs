﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 6f;
    [SerializeField] float angleRotation = 45;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float yMove = 0.1f;

    private Camera cameraPlayer;
    private CinemachineVirtualCamera virtualCamera;
    private CharacterController crPlayer;
    private Vector3 target;
    private Vector3 moveDirection;
	private Animator animator;
    private Ray ray;
    private CinemachineComponentBase componentBase;

    private float gravity = -9.8f;
    private float velocityZ;
    private float vSpeed;
    private float velocityX;
    private float maxZoomOut = 18;
    private float maxZoomIn = 5;
    private float zoom = 13;

    private bool groundedPlayer;

    private void Awake() {
        virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cameraPlayer  = GameObject.Find("IsometricCamera").GetComponent<Camera>();
        crPlayer = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
        componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    } 

    public void Start(){
        if (GameManager.instancia.lastSavePoint != 0)
        {
            transform.position = FindObjectOfType<SavePointsManager>().GetSavePoint(GameManager.instancia.lastSavePoint).position;
        }
    }

    private void Update()
    {
        groundedPlayer = crPlayer.isGrounded;
        if (groundedPlayer && moveDirection.y < 0)
        {
            vSpeed = 0f;
        }

        Rotate();
        Animate();
        ApplyGravity();
        Move();
        ZoomCamera();
    }

    private void ZoomCamera()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel") * -1;
        if ((scrollWheel < 0 && zoom > maxZoomIn ) || (scrollWheel > 0 &&  zoom < maxZoomOut ) ) // forward
        {
            zoom += scrollWheel * 10;
        }
        if (componentBase is CinemachineFramingTransposer){
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = zoom ; 
        }
    }

    private void ApplyGravity()
    {
        vSpeed += gravity * Time.deltaTime;
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

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        moveDirection.y += vSpeed;
        if (moveDirection.magnitude >= 0.1f) 
        {
            // -- Se corrije la dirección del player con la rotación de la camara para que respete el horizontal/vertical
            moveDirection = Quaternion.Euler(0, cameraPlayer.gameObject.transform.eulerAngles.y, 0) * moveDirection;
            moveDirection.Normalize();
        }
        crPlayer.Move(moveDirection * speed * Time.deltaTime);        
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
