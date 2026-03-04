using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    bool inDialogue = false;
    bool isTyping = false;
    Queue<SO_Dialogue.Info> dialogueQueue;
    string wholeDialogue;
    [SerializeField] float typingSpeed = 0.1f;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject dialogueBox;
    GameObject NPC;


    //Singleton command
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else Instance = this;

        //Glömde alltså initialisera denna, häftigt!
        dialogueQueue = new Queue<SO_Dialogue.Info>(); 
    }

    void OnInteract()
    {
        if (inDialogue) 
            DequeueDialogue();
    }

    private void EndDialogue()
    {
        inDialogue = false;
        dialogueBox.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }

    private void CompleteText()
    {
        dialogueText.text = wholeDialogue;
        //isTyping = false;
    }

    public void QueueDialogue(SO_Dialogue dialogue)
    {
        if (inDialogue) return;

        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach (SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }

    private void DequeueDialogue()
    {
        if (isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }
        if (dialogueQueue.Count <= 0)
        {
            EndDialogue();
            return;
        }

        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        wholeDialogue = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTyping = true;
        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(typingSpeed);
            dialogueText.text += c;
        }
        //wholeDialogue = dialogueText.text;
        isTyping = false;
    }
}
