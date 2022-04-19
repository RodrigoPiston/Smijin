using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPC : MonoBehaviour
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
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNpc();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName(); 
        }
        else
        { 
            this.gameObject.GetComponent<NPC>().enabled = false;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
