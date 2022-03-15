using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
	[SerializeField] public GameObject effectOnHit ;
	[SerializeField] public  float effectDuration = 2f ;

	private float timePass;
	private float maxTimeArrow = 5;
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Enemy")){
			//var expl = Instantiate(effectOnHit, transform.position, Quaternion.identity);
			//Destroy(expl,effectDuration); // delete the explosion after 3 seconds
			Destroy(other.gameObject);
			Destroy(gameObject);
		}else{
        	GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        	GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			Debug.Log(other.gameObject.name);
		}
	}

	private void Update()
	{
		timePass += Time.deltaTime;
        if (timePass > maxTimeArrow)
        {
			Destroy(gameObject);
			timePass = 0;
        }
	}

}
