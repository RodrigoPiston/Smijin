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

	private Vector3 movementVector;
	private Vector3 targetVector;
	private Vector3 target;
	private bool isRunning;

	private Ray ray;
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();

	}
	void Update()
    {
        targetVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementVector = MoveTowardTarget(targetVector);

        //rotateTowardMouse = Input.GetKey(KeyCode.Mouse0);
        if (!rotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if(rotateTowardMouse){
            target = RotateFromMouseVector();
        }

        CheckAnimatorState();
    }

    private void CheckAnimatorState()
    {
        isRunning = targetVector != Vector3.zero;
  //      animator.SetBool("isRunning", isRunning);
        if(targetVector != Vector3.zero && movementVector != Vector3.zero)
            Debug.Log($"targetVector: {targetVector} movementVector:{movementVector} target:{target}");
/*
        if(targetVector.z < 0 && movementVector.z < 0){
            animator.SetBool("isRunningBackwards", true);
        }else{
            animator.SetBool("isRunningBackwards", false);
        }*/

        animator.SetFloat("xMov", targetVector.x);
        animator.SetFloat("zMov", targetVector.z);
        animator.SetFloat("xSeePoint", target.normalized.x);
        animator.SetFloat("zSeePoint", target.normalized.z);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //SI APRIETO W
        }
        if(isRunning){
            //SI APRIETO A
            if (Input.GetKey(KeyCode.W) && target.normalized.x < 0)
            {
                animator.Play("RunForwards");
            }else{
                animator.Play("RunBackwards");
            }
        }
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

    private Vector3 RotateFromMouseVector()
    {
        ray = cameraPlayer.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
            return target;
        }
        return Vector3.zero;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
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
