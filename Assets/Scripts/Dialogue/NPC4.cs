using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC4 : MonoBehaviour
{
    public Transform chatBackground;
    public Transform npcCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
        //gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(npcCharacter.position);
        pos.y += 175;
        chatBackground.position = pos;
    }

    private void OnTriggerStay(Collider other)
    {
        if (GameManager.instancia.evento3 && (other.gameObject.tag == "Player"))
        {
            this.gameObject.GetComponent<NPC4>().enabled = true; 
            FindObjectOfType<DialogueSystem>().EnterRangeOfNpc();

            if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
            {               
                this.gameObject.GetComponent<NPC4>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
            }
            else
            {
                this.gameObject.GetComponent<NPC4>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC4>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponent<EnemyHuman>().enabled = true;

    }
}
