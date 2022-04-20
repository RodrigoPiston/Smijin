using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC5 : MonoBehaviour
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
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(npcCharacter.position);
        pos.y += 175;
        chatBackground.position = pos;
    }

    private void OnTriggerStay(Collider other)  
    {

        this.gameObject.GetComponent<NPC5>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNpc();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<NPC5>().enabled = true;
            dialogueSystem.Names = Name; 
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
            GameManager.instancia.Evento2();
        }
        else
        {
            this.gameObject.GetComponent<NPC5>().enabled = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC5>().enabled = false;
    }
}
