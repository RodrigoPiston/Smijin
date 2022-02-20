using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayer;
	
    [SerializeField] private float movementSpeed;
    
	private Animator animator;
 	private Rigidbody rb;
    private Vector3 movementVector;
	private Vector3 targetVector;
	private Vector3 target;
	private bool isRunning;
	private Ray ray;
    private float mouseX;
    private float mouseY;
    Vector2 mousePosFromCenter; 

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
        RotateFromMouseVector();

        CheckAnimatorState();
    }

    private void CheckAnimatorState()
    {
        mousePosFromCenter = new Vector2(mouseX - Screen.width/2, Screen.height/2 - mouseY).normalized;
        
        Debug.Log($"mousePosFromCenter:{mousePosFromCenter}");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if ((Input.GetKey(KeyCode.S) && mousePosFromCenter.y < 0) || (Input.GetKey(KeyCode.W) && mousePosFromCenter.y > 0)
                || (Input.GetKey(KeyCode.D) && mousePosFromCenter.x < 0) || (Input.GetKey(KeyCode.A) && mousePosFromCenter.x > 0)
            )
            {
                animator.SetBool("isRunningBackwards", true);
            }
            else
            {
                animator.SetBool("isRunningBackwards", false);
            }
            ShootAnim(1,true);
        }
        else
        {
            ShootAnim(0,false);
            animator.SetBool("isRunningBackwards", false); 
        }

        if(!animator.GetBool("isRunningBackwards")){
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isRunning", true); 
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    private void ShootAnim(int weight,bool value)
    {
        animator.SetLayerWeight(animator.GetLayerIndex("UpperBodyMovement"), weight);
        animator.SetBool("isShotting", value);
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
