using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] public float speed = 6f;
    [SerializeField] float angleRotation = 45;
    [SerializeField] float turnSmoothTime = 0.1f;
<<<<<<< HEAD
    [SerializeField] float yMove = 0.1f;

=======
>>>>>>> parent of 964786e (Se arreglo la gravedaa)
    private CharacterController crPlayer;
    private Vector3 target;
    private Vector3 moveDirection;
	private Animator animator;
    private Ray ray;
<<<<<<< HEAD
    private CinemachineComponentBase componentBase;

    private float gravity = -9.8f;
    private float velocityZ;
    private float vSpeed;
    private float velocityX;
    private float maxZoomOut = 18;
    private float maxZoomIn = 5;
    private float zoom = 13;

    private int shotAnimation;
    private bool groundedPlayer;

    private void Awake() {
=======
    private float gravity = 9.8f;
    private float velocityZ;
    private float vSpeed;
    private float velocityX;
    void Start(){
>>>>>>> parent of 964786e (Se arreglo la gravedaa)
        crPlayer = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
        shotAnimation = Animator.StringToHash("Shoot_01");
        componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    } 

    private void Update()
    {
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
            Debug.Log($"scrollWheel: {scrollWheel} zoom:{zoom}");
        }
        if (componentBase is CinemachineFramingTransposer){
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = zoom ; 
        }
    }

    private void ApplyGravity()
    {
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
