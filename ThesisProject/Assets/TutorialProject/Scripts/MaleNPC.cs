using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleNPC : MonoBehaviour, F_IInteractable
{
    [SerializeField] List<SO_Dialogue> dialogueList = new();
    
    public void Interact()
    {
        DialogueManager.Instance.QueueDialogue(dialogueList[0]);
        
    }
}
