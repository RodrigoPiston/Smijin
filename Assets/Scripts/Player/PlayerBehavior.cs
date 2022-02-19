using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //Start is called before the first frame update
    [Header("Arrow")]

    [SerializeField] GameObject arrowPrefab;

    [SerializeField] GameObject shootPoint;

    [SerializeField] float cooldown = 0.4f;
    [SerializeField] float arrowPower = 20f;
    private bool canShoot = true;
    private float timePass = 0;

    private GameObject newParentObject;
    private float holdDownStartTime;

    // Start is called before the first frame update
    void Start()
    {
        newParentObject = GameObject.Find("DynamicArrows");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ShootArrow();
    }

    private void ShootArrow()
    {

        //SI APRIETO E
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
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

    private void InstantiateNewArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab, shootPoint.transform.position, shootPoint.transform.rotation);// PROYECTILES
        newArrow.AddComponent<Rigidbody>();
        newArrow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        newArrow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowPower, ForceMode.VelocityChange);
        if (newParentObject != null)
        {
            newArrow.transform.parent = newParentObject.transform;
        }
    }
}
