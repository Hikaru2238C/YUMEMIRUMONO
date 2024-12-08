using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Log
{
    private string characterName = "";
    private string dialogue = "";
    public Log(string characterName, string dialogue)
    {
        this.characterName = characterName;
        this.dialogue = dialogue;
    }

    public void setText(string characterName, string dialogue)
    {
        this.characterName = characterName;
        this.dialogue = dialogue;
    }

    public string getCharacterName()
    {
        return characterName;
    }

    public string getDialogue()
    {
        return dialogue;
    }
}
