using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject //MonoBehaviour
{
    public string name;
    [TextArea(3, 15)]

    public string[] NPCDialogue;
    [TextArea(3, 15)]

    public string[] PlayerDialogue;
}
