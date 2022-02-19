using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	private void OnCollisionEnter(Collision other) {
		Debug.Log($"{other.gameObject.tag}");
		
		
		if(other.gameObject.CompareTag("Enemy")){
			this.GetComponentInParent<PlayerManager>().Hurt(10);
		}else if(other.gameObject.CompareTag("Healing")){
			this.GetComponentInParent<PlayerManager>().Heal(10);
		}
	}
}
