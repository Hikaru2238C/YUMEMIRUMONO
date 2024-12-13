using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetButtonID : MonoBehaviour
{
    public string ID { get; private set; }

    public void SetID(string id)
    {
        ID = id;
        Debug.Log($"IDが設定されました: {ID}");
        this.gameObject.GetComponentInChildren<TMP_Text>().text = id;
    }
}
