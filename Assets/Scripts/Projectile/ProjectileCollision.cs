using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
	[SerializeField] public GameObject effectOnHit ;
	[SerializeField] public  float effectDuration = 2f ;

	private float timePass;
	private float maxTimeProjectile = 5;
	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject.name);
		if(other.gameObject.CompareTag("Enemy")){
			Destroy(other.gameObject);
		}
	}

	private void Update()
	{
		timePass += Time.deltaTime;
        if (timePass > maxTimeProjectile)
        {
			Destroy(gameObject);
			timePass = 0;
        }
	}

}
