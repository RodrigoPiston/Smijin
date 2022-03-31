using UnityEngine;
using Cinemachine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float maxZoomOut = 18;
    [SerializeField] private float maxZoomIn = 5;
    [SerializeField] private float zoom = 13;
    [SerializeField] private GameObject trailOnDash;
    [SerializeField] public GameObject trailPoint;

    private GameObject trailOnDashInstance;

    private Camera cameraPlayer;
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineComponentBase componentBase;
    private CharacterController crPlayer; 
    private Vector3 target;
    private Vector3 moveDirection;
	private Animator animator;
    private Ray ray;
    private float gravity = -9.8f;
    private float velocityZ;
    private float velocityX;
    private float vSpeed;
    private bool groundedPlayer;
    private float normalSpeed;

    private void Awake() {
        try{
            virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cameraPlayer  = GameObject.Find("IsometricCamera").GetComponent<Camera>();
        crPlayer = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
        componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        trailPoint = GameObject.Find("TrailPoint");

        trailOnDashInstance = Instantiate(trailOnDash, 
                        trailPoint.gameObject.transform.position, 
                        trailPoint.gameObject.transform.rotation) as GameObject;
        trailOnDashInstance.transform.parent = trailPoint.transform;
        trailOnDashInstance.gameObject.SetActive(false);
        }catch(Exception e){

        }
    } 

    void Start(){
        if (GameManager.instancia.lastSP != 0)
        {
            transform.position = FindObjectOfType<SavePointsManager>().GetSavePoint(GameManager.instancia.lastSP).position;
        }
        normalSpeed = speed;
    }

    void Update()
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
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject score = GetComponent<InventoryManager>().GetInventoryOne();
            score.SetActive(true);
        }*/
    }

    private void ApplyGravity()
    {
        vSpeed += gravity *Time.deltaTime;
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

    public Vector3 GetMoveDirection(){
        return moveDirection;
    }

    public float GetSpeed(){
        return speed;
    }

    public void SetSpeed(float newSpeed){
        speed = newSpeed;
    }

    public float GetNormalSpeed(){
        return normalSpeed;
    }

    public void SetTrailDashState(bool state){
        trailOnDashInstance.gameObject.SetActive(state);
    }

}
