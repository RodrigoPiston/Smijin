using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayer;
	
    [SerializeField] private bool rotateTowardMouse;

    [SerializeField] private float movementSpeed;
    
    [SerializeField] private float rotationSpeed;
 	private Rigidbody rb;
	private Animator animator;

    private float cameraAxisX;


    private Vector3 movementVector;
	private Vector3 targetVector;
	private Vector3 target;
	private bool isRunning;

	private Ray ray;

    private float mouseX;
    private float mouseY;
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>(); 

	}
	void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 

        targetVector = new Vector3(horizontalInput, 0, verticalInput); 
        targetVector.Normalize();

        movementVector = MoveTowardTarget(targetVector);

        if (targetVector != Vector3.zero)
        {
            transform.forward = movementVector;
        }

        /*//rotateTowardMouse = Input.GetKey(KeyCode.Mouse0);
        if (!rotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if(rotateTowardMouse){
            RotateFromMouseVector();
        }*/

        CheckAnimatorState();
    }

    private void CheckAnimatorState()
    {
        // get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // discard y
        mousePos = new Vector3(mousePos.x, 0, mousePos.z);
  //      animator.SetBool("isRunning", isRunning);
        //Debug.Log($"targetVector: {targetVector} mouse:{mousePos} ");


/*
        if(targetVector.z < 0 && movementVector.z < 0){
            animator.SetBool("isRunningBackwards", true);
        }else{
            animator.SetBool("isRunningBackwards", false);
        }*/
        //isRunning = targetVector != Vector3.zero;

        //animator.SetFloat("xMov", targetVector.x);
        //animator.SetFloat("zMov", targetVector.z);
        //animator.SetFloat("xSeePoint", movementVector.normalized.x);
        //animator.SetFloat("zSeePoint", movementVector.normalized.z);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRunning", true); 
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
            {
                target = hitInfo.point;
                target.y = transform.position.y;
                transform.LookAt(target);
            }
        }

        /*if(isRunning){
            //SI APRIETO A
            if (Input.GetKey(KeyCode.W) && movementVector.normalized.x < 0)
            {
                animator.Play("RunForwards");
            }else{
                animator.Play("RunBackwards");
            }
        }*/
        /*
        //SI APRIETO D
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }

        // -xMov | -xSeePoint: RunBackwards
        if(targetVector.x < 0 && target.normalized.x < 0){
            animator.SetBool("isRunningBackwards", true);
            animator.SetBool("isRunning", false);
        // xMov  | xSeePoint: Run
        }else if(targetVector.x > 0 && target.normalized.x > 0){
            animator.SetBool("isRunning", true);
            animator.SetBool("isRunningBackwards", false);
        }
        
        // -zMov | -zSeePoint: RunBackwards
        if(targetVector.z < 0 && target.normalized.z < 0){
            animator.SetBool("isRunningBackwards", true);
            animator.SetBool("isRunning", false);
        // zMov  | zSeePoint: Run
        }else if(targetVector.z > 0 && target.normalized.z > 0){
            animator.SetBool("isRunningBackwards", false);
            animator.SetBool("isRunning", true);
        }*/

//        isRunning = targetVector != Vector3.zero;
  //      animator.SetBool("isRunning", isRunning);
    }

    private void RotateFromMouseVector()
    {
        ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        /*
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);*/
        
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        isRunning = true;
        var speed = movementSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, cameraPlayer.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
		var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;

        return targetVector;
    }


}
