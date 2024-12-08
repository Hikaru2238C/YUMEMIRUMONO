using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogDialogueUI : MonoBehaviour
{
    private string characterName;
    private string dialogue;
    [SerializeField] private TextMeshProUGUI characterTMP;
    [SerializeField] private TextMeshProUGUI dialogueTMP;

    public void setText(string characterText, string dialogueText)
    {
        this.characterName = characterText;
        this.characterTMP.SetText(this.characterName);
        this.dialogue = dialogueText;
        this.dialogueTMP.SetText(this.dialogue);
    }
}
