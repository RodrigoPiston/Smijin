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
		Debug.Log(other.gameObject.name);
		if(other.gameObject.CompareTag("Enemy")){
			//var expl = Instantiate(effectOnHit, transform.position, Quaternion.identity);
			// only arrows accepted 
			//Destroy(expl,effectDuration); // delete the explosion after 3 seconds
			Destroy(other.gameObject);
			Destroy(gameObject);
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
