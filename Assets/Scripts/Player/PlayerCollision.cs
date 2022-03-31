using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour 
{
	private PlayerStatusManager playerStatusManager;

	[SerializeField] private UnityEvent hitEvent; 

	private void Start() {
	}
	private void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log($"{hit.gameObject.tag}");
		
		if(hit.gameObject.CompareTag("Enemy")){
			PlayerStatusManager.instance.UpdateCharacterStatusLife(-1);
			hitEvent?.Invoke();
		}else if(hit.gameObject.CompareTag("Healing")){
			PlayerStatusManager.instance.UpdateCharacterStatusLife(1);
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
