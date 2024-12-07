using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSelectManager : MonoBehaviour
{
    [SerializeField] GateButtonID gateButtonID;
    [SerializeField] GateIDData gateIDData;
    public void LaunchQuest()
    {
        Debug.Log(gateButtonID.ID);
        gateIDData.questID = gateButtonID.ID;
        if (gateButtonID.ID.StartsWith("バトル"))
        {
            SceneManager.LoadScene("Battle");
        }
        else
        {
            SceneManager.LoadScene("Story");
        }
    }
}
