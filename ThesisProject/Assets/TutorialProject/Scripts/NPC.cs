using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;

public class NPC : MonoBehaviour, F_IInteractable
{
    [SerializeField] List<SO_Dialogue> dialogueList = new();
    bool randomDialogue = false;
    //Unity.Mathematics.Random rnd = new Unity.Mathematics.Random((uint)DateTime.Now.Ticks);
    int index = 0;
    public void Interact()
    {
        //RepeatDialogue();

        //RandomDialogue();

        ShowLastDialogue();
        
    }
    /// <summary>
    /// Visar all dialog i ordning, och börjar sedan om
    /// </summary>
    void RepeatDialogue()
    {
        DialogueManager.Instance.QueueDialogue(dialogueList[index]);
        index++;
        if (index == dialogueList.Count)
            index = 0;
    }

    /// <summary>
    /// Visar endast sista dialogen efter att all dialog redan visats en gång
    /// </summary>
    void ShowLastDialogue()
    {
        DialogueManager.Instance.QueueDialogue(dialogueList[index]);

        if (index < dialogueList.Count - 1)
            index++;

        //for (int i = 0; i <= dialogueList.Count; i++)
        //{
        //    DialogueManager.Instance.QueueDialogue(dialogueList[i]);
        //    if (i == dialogueList.Count - 1)
        //    {
        //        i = 0;
        //    }
        //}
    }

    /// <summary>
    /// slumpar mellan två dialoger
    /// </summary>
    void RandomDialogue()
    {
        int rnd = UnityEngine.Random.Range(0, 100);
        if (rnd <= 90)
            index = 0;
        else index = 1;

        DialogueManager.Instance.QueueDialogue(dialogueList[index]);
    }


}
