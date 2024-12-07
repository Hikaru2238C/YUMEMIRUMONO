using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateButtonID : MonoBehaviour
{
    public string ID { get; private set; }

    public void SetID(string id)
    {
        ID = id;
        Debug.Log($"IDÇ™ê›íËÇ≥ÇÍÇ‹ÇµÇΩ: {ID}");
        this.gameObject.GetComponentInChildren<TMP_Text>().text = id;
    }
}
