using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
	[SerializeField] public GameObject effectOnHit ;
	[SerializeField] public  float effectDuration = 2f ;
	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject.name);
		if(!other.gameObject.name.Equals("Player")){
			//var expl = Instantiate(effectOnHit, transform.position, Quaternion.identity);
			// only arrows accepted 
			//Destroy(expl,effectDuration); // delete the explosion after 3 seconds
			Destroy(gameObject);
		}
	}

}
