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

        if (!rotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (rotateTowardMouse)
        {
            RotateFromMouseVector();
        }
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
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = movementSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, cameraPlayer.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
		var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;

        return targetVector;
    }


}
