using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.CompareTag("Enemy")){
			this.GetComponent<PlayerManager>().Hurt(10 * Time.deltaTime);
		}else if(hit.gameObject.CompareTag("Healing")){
			this.GetComponent<PlayerManager>().Heal(0.4f);
		}
	}

    private void OnTriggerEnter(Collider other)
    {

		if (other.gameObject.CompareTag("Score"))
		{
			// -- No se destruye ya que si queremos utilizar los gameobject en memoria no se guardan xd
			GameObject score = other.gameObject; 
			score.SetActive(false); 
			GameManager.instancia.partsObtained++;
			//GetComponent<InventoryManager>().AddInventoryOne(score);  
		}

		if (other.gameObject.CompareTag("SavePoint"))
		{
			SavePointsManager managerSP = other.transform.parent.GetComponent<SavePointsManager>();
			managerSP.FindSavePoint(other.name); 
		}
	}
}
