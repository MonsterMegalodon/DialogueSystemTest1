using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class MultiDialogueManager : MonoBehaviour
{
    public NPC npc;

    private bool isTalking = false;

    private float distance;
    private float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueText;
    public Text playerResonseText;

    void Start()
    {
        dialogueUI.SetActive(false);    
    }

    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true) 
            {
                EndDialogue();
            }
        }
    }

    private void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueText.text = npc.PlayerDialogue[0];
    }

    private void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

    }

}
