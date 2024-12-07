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
        Debug.Log($"ID���ݒ肳��܂���: {ID}");
        this.gameObject.GetComponentInChildren<TMP_Text>().text = id;
    }
}
