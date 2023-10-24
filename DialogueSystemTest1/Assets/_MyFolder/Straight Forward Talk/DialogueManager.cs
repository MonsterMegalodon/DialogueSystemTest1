using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueSegment
    {
        internal static int Length;
        public string SpeakerText; //Store Speaker of Segment

        [TextArea]
        public string DialogueToPrint;  //Dialogue text
        public bool Skippable;          //To Skip

        [Range(1f, 25f)]
        public float LettersPerSecond;  //Speed of what the dialogue will print
    }

    [SerializeField]
    private DialogueSegment[] DialogueSegments;     //Dialogue Squence
    [Space]
    [SerializeField] private TMP_Text SpeakerText;
    [SerializeField] private TMP_Text TalkingText;

    private int DialogueIndex;
    private bool PlayingDialogue;
    private bool Skip;

    void Start()
    {
        StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex]));
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            if (DialogueIndex == DialogueSegment.Length)
            {
                enabled = false;
                return;
            }

            if (!PlayingDialogue)
            {
                StartCoroutine(PlayDialogue(DialogueSegments[DialogueIndex]));
            }
            else 
            {
                if (DialogueSegments[DialogueIndex].Skippable)
                {
                    Skip = true;
                }
            }
        }
    }

    private IEnumerator PlayDialogue(DialogueSegment segment) 
    {
        PlayingDialogue = true;

        TalkingText.SetText(string.Empty);
        SpeakerText.SetText(segment.SpeakerText);

        float delay = 1f / segment.LettersPerSecond;
        for (int i = 0; i < segment.DialogueToPrint.Length; i++) 
        {
            if (Skip)
            {
                TalkingText.SetText(segment.DialogueToPrint);
                Skip = false;
                break;
            }

            string chunkToAdd = string.Empty;
            chunkToAdd += segment.DialogueToPrint[i];
            if (segment.DialogueToPrint[i] == ' ' && i < segment.DialogueToPrint.Length - 1) 
            {
                chunkToAdd = segment.DialogueToPrint.Substring(i, 2);
                i++;
            }

            TalkingText.text += chunkToAdd;
            yield return new WaitForSeconds(delay);
        }

        PlayingDialogue = false;
        DialogueIndex++;
    }
}
