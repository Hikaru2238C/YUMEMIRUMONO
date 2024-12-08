using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogNarrativeUI : MonoBehaviour
{
    private string narrative;
    [SerializeField] private TextMeshProUGUI narrativeTextObject;

    public void setText(string text)
    {
        this.narrative = text;
        this.narrativeTextObject.SetText(this.narrative);
    }
}
