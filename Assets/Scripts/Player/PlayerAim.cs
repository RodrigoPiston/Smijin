using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    
    [Header("GUI")]
    private float windowDpi;

    [Header("Projectiles")]
    [SerializeField] GameObject[] projectiles;

   // [Header("Projectile")]
   // [SerializeField] GameObject projectilePrefab;

    [SerializeField] private GameObject shootPoint;
    [SerializeField] private float MaxLength;
    [SerializeField] private float cooldown = 0.4f;
    [SerializeField] private float arrowPower = 20f;
    private bool canShoot = true; 
    private float timePass = 0;
    private float distanceRay = 10f;
    private float buttonSaver = 0f;
    private int projectile;

    private GameObject newParentObject; 
    private float holdDownStartTime;
    private Ray RayMouse;
    private Vector3 direction;
    private Quaternion rotation;
    void Start()
    {
        newParentObject = GameObject.Find("DynamicArrows");
  
        if (Screen.dpi < 1) windowDpi = 1;
        if (Screen.dpi < 200) windowDpi = 1;
        else windowDpi = Screen.dpi / 200f;
        Counter(0);
    }

    void Update()
    {
        //To change projectiles
        ChangeProjectiles();
        ShootArrow();
    }

    private void ChangeProjectiles()
    {
        if ((Input.GetKey(KeyCode.Q)) && buttonSaver >= 0.4f)// left button
        {
            buttonSaver = 0f;
            Counter(-1);
        }
        if ((Input.GetKey(KeyCode.E)) && buttonSaver >= 0.4f)// right button
        {
            buttonSaver = 0f;
            Counter(+1);
        }
        buttonSaver += Time.deltaTime;
    }

    //GUI Text
    void OnGUI()
    {
        //GUI.Label(new Rect(10 * windowDpi, 65 * windowDpi, 400 * windowDpi, 20 * windowDpi), "Use the keyboard buttons Q and E to change projectiles!");
    }

    private void ShootArrow()
    {

        //SI APRIETO E
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            //emitirRaycast();
            holdDownStartTime = Time.time;
            InstantiateNewArrow();
            canShoot = false;
        }

        if (!canShoot)
        {
            timePass += Time.deltaTime;
        }

        if (timePass > cooldown)
        {
            timePass = 0;
            canShoot = true;
        }
    }

    void Counter(int count)
    {
        projectile += count;
        if (projectile > projectiles.Length - 1)
        {
            projectile = 0;
        }
        else if (projectile < 0)
        {
            projectile = projectiles.Length - 1;
        }
    }

    private void InstantiateNewArrow()
    {
        Instantiate(projectiles[projectile], shootPoint.transform.position, shootPoint.transform.rotation);
    }

    private void OnDrawGizmos() 
    {
        if (canShoot)
        {
            Gizmos.color = Color.blue;
            Vector3 puntob = shootPoint.transform.TransformDirection(Vector3.forward) * distanceRay;
            Gizmos.DrawRay(shootPoint.transform.position, puntob);
        }
    }
}
