using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
	[SerializeField] public GameObject effectOnHit ;
	[SerializeField] public  float effectDuration = 2f ;

    private void Start()
    {

    }

    private float timePass;
	private float maxTimeProjectile = 5;
	private void OnCollisionEnter(Collision other) {
		
		if(other.gameObject.CompareTag("Enemy")){
			GameManager.instancia.EnemiesKilled();
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
