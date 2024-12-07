using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuestID : MonoBehaviour
{
    [SerializeField] private GateIDData idData;

    private void Start()
    {
        Debug.Log($"持ち越されたID: {idData.questID}");
    }
}

