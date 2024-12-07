using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuestID : MonoBehaviour
{
    [SerializeField] private GateIDData idData;

    private void Start()
    {
        Debug.Log($"‚¿‰z‚³‚ê‚½ID: {idData.questID}");
    }
}

